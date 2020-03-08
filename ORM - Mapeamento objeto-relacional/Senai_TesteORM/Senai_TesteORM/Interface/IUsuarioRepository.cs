using Senai_TesteORM.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_TesteORM.Interface
{
    interface IUsuarioRepository
    {
        List<Usuarios> Listar();

        Usuarios BuscarPorId(int id);

        void Cadastrar(Usuarios novoUsuario);

        void Atualizar(int id, Usuarios usuarioAtualizado);

        void Deletar(int id);
        void Atualizar(Usuarios usuarioAtualizado);
    }
}
