using Senai_TesteORM.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_TesteORM
{
    public class EstudioRepository : IEstudioRepository
    {


        public Estudio BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(IEstudioRepository novoEstudio)
        {
            throw new NotImplementedException();
        }

        public List<Estudio> Listar()
        {
            return ctx.Estudio.ToList();
        }
    }
}
