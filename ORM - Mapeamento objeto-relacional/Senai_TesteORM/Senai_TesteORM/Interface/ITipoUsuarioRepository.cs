using Senai_TesteORM.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_TesteORM.Interface
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuarios> Listar();

        TipoUsuarios BuscaPorId(int id);

        void Cadastrar(TipoUsuarios novoTipoUsuario);

        void Atualizar(int id, TipoUsuarios tipoUsuarioAtualizado);

        void Deletar(int id);
        void Atualizar(TipoUsuarios tipoUsuarioAtualizado);
    }
}
