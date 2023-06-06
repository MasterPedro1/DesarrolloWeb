using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pedre.Models;

namespace Pedre.Controllers
{
    public class ModeloController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        // Aquí obtienes los datos del modelo desde tu archivo C#
        Soda modelo = ObtenerDatosDelModelo();

        if (modelo == null)
        {
            return NotFound();
        }

        return Ok(modelo);
    }

    private Modelo ObtenerDatosDelModelo()
    {
        // Aquí implementa la lógica para obtener los datos del modelo desde tu archivo C#
        // Por ejemplo, puedes leer los datos de un archivo o acceder a una base de datos

        // Retorna los datos del modelo
        return new Soda
        {
            Id = 1,
            Nombre = "Ejemplo de modelo"
        };
    }
}
}
