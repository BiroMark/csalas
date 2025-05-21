using HalakApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HalakApi.Controllers
{
    [Route("Horgaszok")]
    [ApiController]
    public class HorgaszController : ControllerBase
    {
        [HttpGet("All")]
        public ActionResult GetALl()
        {
            try
            {
                using (var contex = new HalakContext())
                {
                    var horgaszok = contex.Horgaszoks.ToList();

                    if (horgaszok != null)
                    {
                        return StatusCode(200, horgaszok);
                    }

                    return StatusCode(400);
                }
            }
            catch (Exception e)
            {

                return StatusCode(400, new { message = e.Message });
            }


        }

        [HttpGet("ById/{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                using (var contex = new HalakContext())
                {
                    var horgasz = contex.Horgaszoks.FirstOrDefault(h => h.Id == id);

                    if (horgasz != null)
                    {
                        return StatusCode(200, horgasz);
                    }
                    else
                    {
                        return StatusCode(404);
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(400, new { message = e.Message });
            }
        }
    }
}
