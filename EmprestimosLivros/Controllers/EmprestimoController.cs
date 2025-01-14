﻿using EmprestimosLivros.Data;
using EmprestimosLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimosLivros.Controllers
{
    public class EmprestimoController : Controller
    {

        readonly private ApplicationDbContext _db;

        public EmprestimoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos;

            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null) 
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpGet]

        public IActionResult Excluir(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimos)
        {
            if (ModelState.IsValid) 
            {
                
                emprestimos.dataUltimaAtualizacao = emprestimos.dataUltimaAtualizacao.ToUniversalTime();


                _db.Emprestimos.Add(emprestimos);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();

        }

        [HttpPost]

        public IActionResult Editar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                emprestimo.dataUltimaAtualizacao = emprestimo.dataUltimaAtualizacao.ToUniversalTime();

                _db.Emprestimos.Update(emprestimo);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(emprestimo);
        }

        [HttpPost]

        public IActionResult Excluir(EmprestimosModel emprestimo)
        { 
            if(emprestimo == null)
            {
                return NotFound();
            }

            emprestimo.dataUltimaAtualizacao = emprestimo.dataUltimaAtualizacao.ToUniversalTime();

            _db.Emprestimos.Remove(emprestimo);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
