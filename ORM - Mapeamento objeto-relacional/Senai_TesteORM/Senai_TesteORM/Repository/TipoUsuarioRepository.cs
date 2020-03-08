using Senai_TesteORM.Domains;
using Senai_TesteORM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_TesteORM.Repository
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {

        InLockContext ctx = new InLockContext();

        public List<TipoUsuarios> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }

        public TipoUsuarios BuscaPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuarios novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Atualizar(int id, TipoUsuarios tipoUsuarioAtualizado)
        {
            TipoUsuarios tipoUsuarioBuscado = new TipoUsuarios();

            tipoUsuarioBuscado.IdTipoUsuario = tipoUsuarioAtualizado.IdTipoUsuario;
            tipoUsuarioBuscado.Titulo = tipoUsuarioAtualizado.Titulo;
            tipoUsuarioBuscado.Usuarios = tipoUsuarioAtualizado.Usuarios;

            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);
            ctx.SaveChanges();

        }

        public void Deletar(int id)
        {
            TipoUsuarios tipoUsuario = new TipoUsuarios();

            tipoUsuario = ctx.TipoUsuarios.FirstOrDefault(e => e.IdTipoUsuario == id);

            ctx.TipoUsuarios.Remove(tipoUsuario);
            ctx.SaveChanges();
        }

    }
}
