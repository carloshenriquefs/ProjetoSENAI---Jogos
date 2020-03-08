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
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _usuarioRepository que recebe metodos definidos na interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referencia aos metodos no repositorio
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }

        /// <summary>
        /// Busca um usuario atraves do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_usuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Usuarios novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um novo usuario atraves do ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuarioAtualizado"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuarios usuarioAtualizado)
        {
            _usuarioRepository.Atualizar(usuarioAtualizado);
        }

        /// <summary>
        /// Deleta o usuario atraves do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Usuarios usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if(usuarioBuscado != null)
            {
                _usuarioRepository.Deletar(id);

                return Ok($"O tipo de Usuario {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum tipo de jogo foi encontrado!");
        }
    }
}