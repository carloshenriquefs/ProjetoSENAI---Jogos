using Senai_TesteORM.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_TesteORM
{
    interface IEstudioRepository
    {
        List<Estudio> Listar();

        Estudio BuscarPorId(int id);

        void Cadastrar(Estudio novoEstudio);

        void Atualizar(int id, Estudio estudioAtualizado);

        void Deletar(int id);

        List<Estudio> ListarEstudioPorJogos();
        void Atualizar(Estudio estudioAtualizado);
    }
}
