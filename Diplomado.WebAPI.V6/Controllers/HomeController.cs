using Diplomado_EstructuraCapas.Dominio.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Diplomado.WebAPI.V6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("[Action]")]
        public string ObtenerEstudiantes()
        {
            EstudiantesServices services = new EstudiantesServices();
            return JsonConvert.SerializeObject(services.ObtenerEstudiantes());
        }
    }
}
