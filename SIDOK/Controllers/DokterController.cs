using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SIDOK.Core.Models;
using SIDOK.Service.Interface;

namespace SIDOK.Controllers
{
    public class DokterController : Controller
    {
        private readonly IService _service;

        private List<SelectListItem> gender = new List<SelectListItem>();

        public DokterController(IService service)
        {
            _service = service;
            gender.Add(new SelectListItem { Text = "Laki-laki", Value = "1" });
            gender.Add(new SelectListItem { Text = "Perempuan", Value = "2" });
        }

        // GET: DokterController
        public async Task<ActionResult> Index()
        {
            ViewBag.gender = gender;
            try
            {
                var dokters = await _service.Dokter.GetDokters();
                return View(dokters);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: DokterController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var dokter = await _service.Dokter.GetDokter(id);

                return View(dokter);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: DokterController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.gender = gender;

            try
            {
                var spesialisasi = await _service.Spesialisasi.GetSpesialisasi();
                ViewBag.spesialisasi = spesialisasi;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return View();
        }

        // POST: DokterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Dokter dokter, int id_Spesialisasi)
        {
            
            try
            {
                var id_dokter = await _service.Dokter.CreateDokter(dokter);

                await _service.Spesialisasi.CreateSpesialisasiDokter(id_dokter, id_Spesialisasi);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: DokterController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.gender = gender;

            try
            {
                var dokter = await _service.Dokter.GetDokter(id);
                if (dokter == null)
                    return NotFound();

                var spesialisasi = await _service.Spesialisasi.GetSpesialisasi();
                ViewBag.spesialisasi = spesialisasi;

                return View(dokter);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: DokterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Dokter dokter)
        {
            try
            {
                await _service.Dokter.UpdateDokter(id, dokter);
                await _service.Spesialisasi.UpdateSpesialisasiDokter(id, dokter.Spesialisasi.Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: DokterController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var dokter = await _service.Dokter.GetDokter(id);
                if (dokter == null)
                    return NotFound();

                return View(dokter);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: DokterController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _service.Dokter.DeleteDokter(id);
                await _service.Spesialisasi.DeleteSpesialisasiDokter(id);
                await _service.JadwalJaga.DeleteJadwalByDokter(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        public async Task<ActionResult> CreateJadwalJaga(int id)
        {
            try
            {
                var jadwalJaga = new JadwalJagaForCreateDto();

                var dokter = await _service.Dokter.GetDokter(id);
                if (dokter == null) 
                    return NotFound();

                jadwalJaga.Dokter = dokter;

                var poli = await _service.Poli.GetAllPoli();
                ViewBag.poli = poli;

                return View(jadwalJaga);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateJadwalJaga(JadwalJagaForCreateDto jadwal)
        {
            try
            {
                await _service.JadwalJaga.CreateJadwal(jadwal);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //public async Task<ActionResult> Search()
        //{
        //    try
        //    {
        //        var spesialisasi = await _service.Spesialisasi.GetSpesialisasi();
        //        ViewBag.spesialisasi = spesialisasi;

        //        var poli = await _service.Poli.GetAllPoli();
        //        ViewBag.poli = poli;

        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        public async Task<ActionResult> Search(int id_spesialisasi, int id_poli)
        {
            try
            {
                var spesialisasi = await _service.Spesialisasi.GetSpesialisasi();
                ViewBag.spesialisasi = spesialisasi;

                var poli = await _service.Poli.GetAllPoli();
                ViewBag.poli = poli;

                
                if (id_spesialisasi != 0 && id_poli != 0)
                {
                    var result = await _service.Dokter.SearchDokter(id_spesialisasi, id_poli);
                    return View(result);
                }
                else
                {

                    var result = new List<Dokter>();
                    return View(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
