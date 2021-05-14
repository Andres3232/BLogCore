using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogCore.AccesoDatos.Data;
using BlogCore.Models;
using BlogCore.AccesoDatos.Data.Repository;
using Microsoft.AspNetCore.Authorization;

namespace BlogCore.Areas.Admin.Controllers
{
    [Authorize]

    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public CategoriasController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        // GET: Admin/Categorias
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        //metodo para boton crear para q aparezca
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //metodo para boton crear para agregar categoria a la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Categoria.Add(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        //boton editar
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Categoria categoria = new Categoria();
            categoria = _contenedorTrabajo.Categoria.GeT(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        //metodo post para el edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Categoria.Update(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }


        #region LLAMADAS A LA API
        [HttpGet]

        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Categoria.GetAll()});
        }

        [HttpDelete]
        public IActionResult Delete( int id)
        {
            var objFromDb = _contenedorTrabajo.Categoria.GeT(id);
            if (objFromDb==null)
            {
                return Json(new { success = false, message = "Error borrado categoria" });//este massage es el que esta en el categoria.js
            }
            _contenedorTrabajo.Categoria.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "categoria borrada correctamente" });
        }

        #endregion






        
    }
}
