using Senai_TesteORM.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_TesteORM
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();

        public List<Estudio> Listar()
        {
            return ctx.Estudio.ToList();
        }

        public Estudio BuscarPorId(int id)
        {
            return ctx.Estudio.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudio novoEstudio)
        {
            ctx.Estudio.Add(novoEstudio);

            ctx.SaveChanges();
        }

        public void Atualizar(int id, Estudio estudioAtualizado)
        {
            Estudio estudioBuscado = new Estudio();

            estudioBuscado = ctx.Estudio.FirstOrDefault(e => e.IdEstudio == id);

            estudioBuscado.IdEstudio = estudioAtualizado.IdEstudio;
            estudioBuscado.NomeEstudio = estudioAtualizado.NomeEstudio;
            estudioBuscado.Jogos = estudioAtualizado.Jogos;

            ctx.Estudio.Update(estudioBuscado);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Estudio estudio = new Estudio();

            estudio = ctx.Estudio.FirstOrDefault(e => e.IdEstudio == id);

            ctx.Estudio.Remove(estudio);
            ctx.SaveChanges();
        }
        public List<Estudio> ListarEstudioPorJogos()
        {
            throw new NotImplementedException();
        }
    }
}
