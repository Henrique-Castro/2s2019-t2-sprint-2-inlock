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
    public class EstudiosController : ControllerBase
    {
        EstudioRepository estudioRepository = new EstudioRepository();


        //listar

        [HttpGet]
        public IActionResult listar()
        {
            return Ok(estudioRepository.Listar());
        }





        //BuscarPorId

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Estudios estudios = estudioRepository.BuscarPorId(id);

            return Ok(estudios);
        }





        //Cadastar

        [HttpPost]
        public IActionResult Cadastrar(Estudios estudio)
        {
            try
            {
                estudioRepository.cadastrar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Ocorreu um erro na execução:" + ex.Message });
            };
        }



        //Deletar
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            estudioRepository.deletar(id);
            return Ok();
        }




        //Atualizar
        [HttpPut]
        public IActionResult Atualizar(Estudios estudio)
        {
            try
            {
                Estudios estudioBuscado = estudioRepository.BuscarPorId(estudio.EstudioId);
                if (estudioBuscado ==null)
                {
                    return NotFound();
                }
                estudioRepository.Atualizar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Ocorreu um erro na execução" + ex.Message });
            }
        }

    }
}