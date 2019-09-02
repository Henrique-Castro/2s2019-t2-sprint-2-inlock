using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        JogoRepository JogoRepository = new JogoRepository();

        Jogos Jogos = new Jogos();

        //Listar
        [HttpGet]
        public IActionResult listar()
        {
            return Ok(JogoRepository.Listar());
        }
        //BuscarPorId
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Jogos jogo = JogoRepository.BuscarPorId(id);
            if (Jogos == null)
            {
                return NotFound();
            }
            return Ok(jogo);
        }
        //Deletar
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            JogoRepository.Deletar(id);
            return Ok();
        }

    }
}