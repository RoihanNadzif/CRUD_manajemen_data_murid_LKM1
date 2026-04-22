using LKM1_PAA.Models;
using Microsoft.AspNetCore.Mvc;

namespace LKM1_PAA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KelasController : ControllerBase
    {
        private readonly string _constr;

        public KelasController(IConfiguration configuration)
        {
            _constr = configuration.GetConnectionString("koneksi")!;
        }

        // GET /Kelas
        [HttpGet]
        public IActionResult Getsemuamurid()
        {
            try
            {
                KelasContext context = new KelasContext(_constr);
                List<Kelas> list = context.Listmurid();
                return Ok(new { status = "success", total = list.Count, data = list });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = ex.Message });
            }
        }

        // GET /Kelas/{id}
        [HttpGet("{id}")]
        public IActionResult GetKelasById(int id)
        {
            try
            {
                KelasContext context = new KelasContext(_constr);
                Kelas? kelas = context.getmuridid(id);
                if (kelas == null)
                    return NotFound(new { status = "error", message = $"Murid dengan id {id} tidak ditemukan" });
                return Ok(new { status = "success", data = kelas });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = ex.Message });
            }
        }

        // POST /Kelas
        [HttpPost]
        public IActionResult PostKelas([FromBody] Kelas kelas)
        {
            if (kelas == null)
                return BadRequest(new { status = "error", message = "Data murid tidak boleh kosong" });

            try
            {
                KelasContext context = new KelasContext(_constr);
                if (context.tambahmurid(kelas))
                    return StatusCode(201, new { status = "success", message = $"Murid '{kelas.nama}' berhasil ditambahkan" });

                return BadRequest(new { status = "error", message = $"Gagal menambahkan murid '{kelas.nama}'" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = ex.Message });
            }
        }

        // PUT /Kelas/{id}
        [HttpPut("{id}")]
        public IActionResult PutKelas(int id, [FromBody] Kelas kelas)
        {
            if (kelas == null)
                return BadRequest(new { status = "error", message = "Data murid tidak boleh kosong" });

            try
            {
                KelasContext context = new KelasContext(_constr);
                Kelas? existing = context.getmuridid(id);
                if (existing == null)
                    return NotFound(new { status = "error", message = $"Murid dengan id {id} tidak ditemukan" });

                if (context.updatemurid(id, kelas))
                    return Ok(new { status = "success", message = $"Murid '{kelas.nama}' berhasil diupdate" });

                return BadRequest(new { status = "error", message = $"Gagal mengupdate murid dengan id {id}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = ex.Message });
            }
        }

        // DELETE /Kelas/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteKelas(int id)
        {
            try
            {
                KelasContext context = new KelasContext(_constr);
                Kelas? existing = context.getmuridid(id);
                if (existing == null)
                    return NotFound(new { status = "error", message = $"Murid dengan id {id} tidak ditemukan" });

                if (context.hapusmurid(id))
                    return Ok(new { status = "success", message = $"Murid dengan id {id} berhasil dihapus" });

                return BadRequest(new { status = "error", message = $"Gagal menghapus murid dengan id {id}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = ex.Message });
            }
        }
    }
}
