using Senai_TesteORM.Domains;
using Senai_TesteORM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_TesteORM.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(int id, Usuarios usuarioAtualizado)
        {
            Usuarios usuarioBuscado = new Usuarios();

            usuarioBuscado = ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id);

            usuarioBuscado.IdUsuario = usuarioAtualizado.IdUsuario;
            usuarioBuscado.Email = usuarioAtualizado.Email;
            usuarioBuscado.Email = usuarioAtualizado.Senha;
            usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;

            ctx.Usuarios.Update(usuarioBuscado);
            ctx.SaveChanges();
        }

        public Usuarios BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Cadastrar(Usuarios novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuarios usuario = new Usuarios();

            usuario = ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id);

            ctx.Usuarios.Remove(usuario);
            ctx.SaveChanges();
        }

        public List<Usuarios> Listar()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
