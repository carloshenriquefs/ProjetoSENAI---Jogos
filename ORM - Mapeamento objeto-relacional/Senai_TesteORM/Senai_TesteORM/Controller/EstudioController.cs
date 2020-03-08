using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_TesteORM.Domains;

namespace Senai_TesteORM.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private IEstudioRepository _estudioRepository;

        /// <summary>
        /// 
        /// </summary>
        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estudioRepository.Listar());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_estudioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoEstudio"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Estudio novoEstudio)
        {
            _estudioRepository.Cadastrar(novoEstudio);

            return StatusCode(201);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="estudioAtualizado"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Estudio estudioAtualizado)
        {
            Estudio estudioBuscado = _estudioRepository.BuscarPorId(id);

            if(estudioBuscado != null)
            {
                try
                {
                    _estudioRepository.Atualizar(id, estudioBuscado);

                    return NoContent();
                }
                catch(Exception erro)
                {
                    return BadRequest(erro);
                }
            }

                return NotFound
                    ( 
                      new
                      {
                          mensagem = "Tipo de usuario não encontrado",
                          erro = true
                      }

                    );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Estudio estudioBuscado = _estudioRepository.BuscarPorId(id);

            if(estudioBuscado != null)
            {
                _estudioRepository.Deletar(id);

                return Ok($"O tipo de estudio {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum tipo de estudio foi encontrado");
        }

    }
}