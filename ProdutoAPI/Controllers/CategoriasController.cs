using ProdutoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProdutoAPI.Controllers
{
    public class CategoriasController : Controller
    {
        public IActionResult Index()
        {
            MongoDbContext dbContext = new MongoDbContext();

            List<CategoriaProduto> listaCategoria = dbContext.Categorias.Find(m => true).ToList();

            ViewBag.ListaCategorias = listaCategoria;

            return View(listaCategoria);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            MongoDbContext dbContext = new MongoDbContext();
            var entity = dbContext.Categorias.Find(m => m.Id == id).FirstOrDefault();

            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(CategoriaProduto entity)
        {
            MongoDbContext dbContext = new MongoDbContext();

            dbContext.Categorias.ReplaceOne(m => m.Id == entity.Id, entity);

            return RedirectToAction("Index", "Categorias");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoriaProduto entity)
        {
            MongoDbContext dbContext = new MongoDbContext();

            entity.Id = Guid.NewGuid();

            dbContext.Categorias.InsertOne(entity);

            return RedirectToAction("Index", "Categorias");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            MongoDbContext dbContext = new MongoDbContext();

            dbContext.Categorias.DeleteOne(m => m.Id == id);

            return RedirectToAction("Index", "Categorias");
        }
    }
}
