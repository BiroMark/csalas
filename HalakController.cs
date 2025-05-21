using HalakApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HalakApi.Controllers
{
    [Route("Halak")]
    [ApiController]
    public class HalakController : ControllerBase
    {

        [HttpGet("FajMeretTo")]
        public ActionResult GetAllFajMeretTo()
        {
            try
            {
                List<HalakDto> lista = new List<HalakDto>();

                using (var context = new HalakContext())
                {
                    var tavak = context.Tavaks.Include(h => h.Halaks).ToList();

                    foreach (var to in tavak)
                    {
                        foreach (var hal in to.Halaks)
                        {
                            var result = new HalakDto
                            {
                                Faj = hal.Faj,
                                MeretCm = hal.MeretCm,
                                Helyszin = to.Nev
                            };

                            lista.Add(result);
                        }
                    }

                    return StatusCode(200, lista);
                }
            }
            catch (Exception e)
            {

                return StatusCode(400, new { meassage = e.Message });
            }

        }

        [HttpPost]
        public ActionResult PostHalak(Halak halak)
        {
            using (var context = new HalakContext())
            {
                try
                {
                    if (halak == null)
                    {
                        return StatusCode(400, new { message = "Üres objektum!" });
                    }

                    var newHal = new Halak
                    {
                        Nev = halak.Nev,
                        Faj = halak.Faj,
                        MeretCm = halak.MeretCm
                    };

                    context.Halaks.Add(newHal);
                    context.SaveChanges();

                    return StatusCode(200, newHal);
                }
                catch (Exception e)
                {

                    return StatusCode(400, new { meassage = e.Message });
                }
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutHalak(int id, Halak halak)
        {
            try
            {
                using (var context = new HalakContext())
                {
                    var hal = await context.Halaks.FirstOrDefaultAsync(h => h.Id == id);

                    if (hal == null)
                    {
                        return StatusCode(404, new { message = "Nincs ilyen azonosító!" });
                    }

                    hal.Nev = halak.Nev;
                    hal.MeretCm = halak.MeretCm;
                    hal.Faj = halak.Faj;

                    context.Halaks.Update(hal);
                    await context.SaveChangesAsync();

                    return StatusCode(200, new { message = "Sikeres módosítás!" });
                }
            }
            catch (Exception e)
            {

                return StatusCode(400, new { meassage = e.Message });
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHal(int id)
        {
            try
            {
                using (var context = new HalakContext())
                {
                    var hal = await context.Halaks.FirstOrDefaultAsync(h => h.Id == id);

                    if (hal == null)
                    {
                        return StatusCode(404, new { message = "Nincs ilyen azonosító!" });
                    }

                    context.Halaks.Remove(hal);
                    await context.SaveChangesAsync();

                    return StatusCode(200, new { message = "Sikeres törlés!" });
                }
            }
            catch (Exception e)
            {

                return StatusCode(400, new { meassage = e.Message });
            }

        }


    }
}
