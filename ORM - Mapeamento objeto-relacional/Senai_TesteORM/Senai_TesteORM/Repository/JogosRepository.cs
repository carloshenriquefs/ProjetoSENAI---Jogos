using Senai_TesteORM.Domains;
using Senai_TesteORM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_TesteORM.Repository
{
    public class JogosRepository : IJogosRepository
    {
        InLockContext ctx = new InLockContext();

        public List<Jogos> Listar()
        {
            return ctx.Jogos.ToList();
        }

        public void Atualizar(int id, Jogos jogoAtualizado)
        {
            Jogos jogoBuscado = new Jogos();

            jogoBuscado = ctx.Jogos.FirstOrDefault(e => e.IdJogo == id);

            jogoBuscado.IdJogo = jogoAtualizado.IdJogo;
            jogoBuscado.NomeJogo = jogoAtualizado.NomeJogo;
            jogoBuscado.Descricao = jogoAtualizado.Descricao;
            jogoBuscado.DataLancamento = jogoAtualizado.DataLancamento;
            jogoBuscado.Valor = jogoAtualizado.Valor;
            jogoBuscado.IdEstudio = jogoAtualizado.IdEstudio;
            jogoBuscado.IdEstudioNavigation = jogoAtualizado.IdEstudioNavigation;

            ctx.Jogos.Update(jogoBuscado);
            ctx.SaveChanges();

        }

        public Jogos BuscarPorId(int id)
        {
            return ctx.Jogos.FirstOrDefault(e => e.IdJogo == id);
        }

        public void Cadastrar(Jogos novoJogo)
        {
            ctx.Jogos.Add(novoJogo);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Jogos jogos = new Jogos();

            jogos = ctx.Jogos.FirstOrDefault(e => e.IdJogo == id);

            ctx.Jogos.Remove(jogos);
            ctx.SaveChanges();
        }

        public List<Jogos> ListarEstudio(int id)
        {
            throw new NotImplementedException();
        }
    }
}
