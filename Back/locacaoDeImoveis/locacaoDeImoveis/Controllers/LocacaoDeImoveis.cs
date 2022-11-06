﻿using locacaoDeImoveis.DTO;
using Microsoft.AspNetCore.Cors;
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
  public class LocacaoDeImoveis : ControllerBase
  {


    private readonly ILogger<LocacaoDeImoveis> _logger;

    public LocacaoDeImoveis(ILogger<LocacaoDeImoveis> logger)
    {
      _logger = logger;
    }

    [EnableCors("Policy1")]
    [HttpGet("trazer")]
    public string Trazer()
    {
      var service = new Repository();
      var retorno = service.QuerySelectIAllmoveis();

      return retorno;
    }

    [EnableCors("AnotherPolicy")]
    [HttpPost("criar")]
    public int Criar([FromBody] imoveisDTO imovel)
    {
      var service = new Repository();

      var retorno = service.QueryInsertImovel(imovel);

      return retorno;
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
