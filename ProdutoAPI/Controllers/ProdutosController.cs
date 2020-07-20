using ProdutoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProdutoAPI.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            MongoDbContext dbContext = new MongoDbContext();

            List<Produto> listaProdutos = dbContext.Produtos.Find(m => true).ToList();

            return View(listaProdutos);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            MongoDbContext dbContext = new MongoDbContext();

            var entity = dbContext.Produtos.Find(m => m.Id == id).FirstOrDefault();

            List<CategoriaProduto> listaCategoria = dbContext.Categorias.Find(m => true).ToList();

            ViewBag.ListaCategorias = listaCategoria;

            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Produto entity)
        {
            MongoDbContext dbContext = new MongoDbContext();

            dbContext.Produtos.ReplaceOne(m => m.Id == entity.Id, entity);

            return RedirectToAction("Index", "Produtos");
        }

        [HttpGet]
        public IActionResult Add()
        {
            MongoDbContext dbContext = new MongoDbContext();

            List<CategoriaProduto> listaCategoria = dbContext.Categorias.Find(m => true).ToList();

            ViewBag.ListaCategorias = listaCategoria;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Produto entity)
        {
            MongoDbContext dbContext = new MongoDbContext();

            entity.Id = Guid.NewGuid();

            dbContext.Produtos.InsertOne(entity);
           
            return RedirectToAction("Index", "Produtos");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            MongoDbContext dbContext = new MongoDbContext();

            dbContext.Produtos.DeleteOne(m => m.Id == id);

            return RedirectToAction("Index", "Produtos");
        }

    }
}
