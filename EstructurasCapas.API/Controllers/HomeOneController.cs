﻿using Diplomado_EstructuraCapas.Dominio.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EstructurasCapas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeOneController : ControllerBase
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
