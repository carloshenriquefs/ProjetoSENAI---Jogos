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
    public class TipoUsuarioController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private ITipoUsuarioRepository _tipoUsuarioRepository;

        /// <summary>
        /// 
        /// </summary>
        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(TipoUsuarios novoTipoUsuario)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuarios tipoUsuarioAtualizado)
        {
            _tipoUsuarioRepository.Atualizar(tipoUsuarioAtualizado); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoUsuarios tipoUsuarioBuscado = _tipoUsuarioRepository.BuscaPorId(id);

            if(tipoUsuarioBuscado != null)
            {
                _tipoUsuarioRepository.Deletar(id);

                return Ok($"O tipo de usuario {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum tipo de usuario foi encontrado!");

        }
    }
}