using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_TesteORM.Domains;
using Senai_TesteORM.Interface;
using Senai_TesteORM.Repository;

namespace Senai_TesteORM.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private IJogosRepository _jogoRepository;

        /// <summary>
        /// 
        /// </summary>
        public JogosController()
        {
            _jogoRepository = new JogosRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogoRepository.Listar());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_jogoRepository.BuscarPorId(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoJogos"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Jogos novoJogos)
        {
            _jogoRepository.Cadastrar(novoJogos);

            return StatusCode(201);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jogosAtualizado"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Jogos jogosAtualizado)
        {
            _jogoRepository.Atualizar(jogosAtualizado);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Jogos jogosBuscado = _jogoRepository.BuscarPorId(id);

            if(jogosBuscado != null)
            {
                _jogoRepository.Deletar(id);

                return Ok($"O tipo de jogo {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum tipo de jogo foi encontrado!");
        }




    }
}