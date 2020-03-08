using Senai_TesteORM.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_TesteORM.Interface
{
    interface IJogosRepository
    {
        List<Jogos> Listar();

        Jogos BuscarPorId(int id);

        void Cadastrar(Jogos novoJogo);

        void Atualizar(int id, Jogos jogoAtualizado);

        void Deletar(int id);

        List<Jogos> ListarEstudio(int id);
        void Atualizar(Jogos jogosAtualizado);
    }
}
