using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace tpmodul10_1302220105.Controllers
{
    public class Mahasiswa
    {
        public string nama
        {
            get;
            set;
        }
        public string NIM
        {
            get;
            set;
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswa = new List<Mahasiswa> {
            new Mahasiswa {
                nama = "Mahesa Athaya Zain", NIM = "1302220105"
            },
            new Mahasiswa {
                nama = "Raphael Permana Barus", NIM = "1302220140"
            },
            new Mahasiswa {
                nama = "Haikal Risnandar", NIM = "1302221050"
            },
            new Mahasiswa {
                nama = "Fersya Zufar", NIM = "1302223090"
            },
            new Mahasiswa {
                nama = "Darryl Frizangelo Rambi", NIM = "1302223154"
            },
            new Mahasiswa {
                nama = "Dafa Raimi Suandi", NIM = "1302223156"
            }
        };

        [HttpGet]
        public IActionResult GetMahasiswa()
        {
            return Ok(mahasiswa);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= mahasiswa.Count)
            {
                return NotFound("Indeks mahasiswa tidak valid");
            }

            return Ok(mahasiswa[id]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Mahasiswa input)
        {
            Mahasiswa newMahasiswa = new Mahasiswa
            {
                nama = input.nama,
                NIM = input.NIM
            };

            mahasiswa.Add(newMahasiswa);

            return CreatedAtAction(nameof(Get), new
            {
                id = mahasiswa.IndexOf(newMahasiswa)
            }, newMahasiswa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= mahasiswa.Count)
            {
                return NotFound("Indeks mahasiswa tidak valid");
            }

            mahasiswa.RemoveAt(id);

            return NoContent();
        }
    }
}