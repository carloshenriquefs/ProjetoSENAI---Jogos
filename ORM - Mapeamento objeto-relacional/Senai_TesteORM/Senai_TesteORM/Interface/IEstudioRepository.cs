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

        void Cadastrar(IEstudioRepository novoEstudio);

        Estudio BuscarPorId(int id);
    }
}
