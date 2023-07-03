using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIDOK.Core.Models;
using SIDOK.Service.Interface;

namespace SIDOK.Controllers
{
    public class PoliController : Controller
    {
        private readonly IService _service;

        public PoliController(IService service)
        {
            _service = service;
        }
        // GET: PoliController
        public async Task<ActionResult> Index()
        {
            try
            {
                var poli = await _service.Poli.GetAllPoli();

                return View(poli);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: PoliController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var poli = await _service.Poli.GetPoliDetails(id);

                if (poli == null)
                    return NotFound();

                return View(poli);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: PoliController/Create
        public async Task<ActionResult> Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: PoliController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PoliForCreateDto poli)
        {
            try
            {
                await _service.Poli.CreatePoli(poli);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: PoliController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var poli = await _service.Poli.GetPoli(id);

                var poliCreate = new PoliForCreateDto();

                poliCreate.Nama = poli.Nama;
                poliCreate.Lokasi = poli.Lokasi;

                return View(poliCreate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: PoliController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PoliForCreateDto poli)
        {
            try
            {
                await _service.Poli.UpdatePoli(id, poli);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: PoliController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var poli = await _service.Poli.GetPoli(id);

                if (poli == null)
                    return NotFound();

                return View(poli);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: PoliController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _service.JadwalJaga.DeleteJadwalByPoli(id);
                await _service.Poli.DeletePoli(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex?.Message);
            }
        }
    }
}
