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
    public class EstudiosController : ControllerBase
    {
        EstudiosRepository estudiosRepository = new EstudiosRepository();


        //listar
        [Authorize]
        [HttpGet]
        public IActionResult listar()
        {
            return Ok(estudiosRepository.Listar());
        }

        [Authorize]
        [HttpGet("Jogos")]
        public IActionResult BuscarEstudiosJogos()
        {
            try
            {
                return Ok(estudiosRepository.ListarEstudiosJogos()); 
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(estudiosRepository.BuscarPorId(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //Cadastar
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Estudios estudio)
        {
            try
            {
                estudiosRepository.Cadastrar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Ocorreu um erro na execução:" + ex.Message });
            };
        }



        //Deletar
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            estudiosRepository.deletar(id);
            return Ok();
        }




        //Atualizar
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Estudios estudio)
        {
            try
            {
                Estudios estudioBuscado = estudiosRepository.BuscarPorId(id);
                if (estudioBuscado ==null)
                {
                    return NotFound();
                }
                estudio.EstudioId = id;
                estudiosRepository.Atualizar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}