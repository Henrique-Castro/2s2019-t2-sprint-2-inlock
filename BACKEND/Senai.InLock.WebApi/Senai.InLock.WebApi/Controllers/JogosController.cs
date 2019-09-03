using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        JogosRepository JogosRepository = new JogosRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(JogosRepository.Listar());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("Caros")]
        public IActionResult ListarMaisCaros()
        {
            try
            {
                return Ok(JogosRepository.ListarPorValor());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("Lancamentos")]
        public IActionResult ListarPorDataLancamento()
        {
            try
            {
                return Ok(JogosRepository.ListarPorLancamento());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Jogos novoJogos)
        {
            try
            {
                JogosRepository.Cadastrar(novoJogos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Jogos jogoModificado)
        {
            try
            {
                jogoModificado.JogoId = id;
                JogosRepository.Atualizar(jogoModificado);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
   
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Jogos jogo = JogosRepository.BuscarPorId(id);
            if (jogo == null)
            {
                return NotFound();
            }
            return Ok(jogo);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            JogosRepository.Deletar(id);
            return Ok();
        }
    }
}