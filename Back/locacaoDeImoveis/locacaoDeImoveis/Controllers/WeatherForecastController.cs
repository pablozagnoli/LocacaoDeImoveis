using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoDeImoveis.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {


    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
      _logger = logger;
    }

    [HttpGet("trazer")]
    public string Trazer()
    {
      var service = new Repository();
      var retorno = service.conectdbMySqlAsync();

      return retorno;
    }

    [HttpPost]
    public string Criar()
    {
      return "teste";
    }

    [HttpPut]
    public string Atualiza()
    {
      return "teste";
    }

    [HttpDelete]
    public string Deleta()
    {
      return "teste";
    }
  }
}
