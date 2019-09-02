using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {

        Jogos Jogos = new Jogos();
        //listar
        public List<Jogos> Listar()
        {
            using(InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.ToList();
            }
        }
        //listar por id
        public Jogos BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.FirstOrDefault(x => x.JogoId == id);


            }
        }
        //adicionar
        public void Cadastrar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }
        //atualizar
        public void Atualizar(Jogos jogo)
        {
            using(InLockContext ctx = new InLockContext())
            {
                Jogos jogoEncontrado = ctx.Jogos.FirstOrDefault(x => x.JogoId == jogo.JogoId);

                jogoEncontrado.NomeDoJogo = jogo.NomeDoJogo;

                ctx.Jogos.Update(jogoEncontrado);

                ctx.SaveChanges();
            }
        }
        //deletar
        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos jogoEncotrado = ctx.Jogos.Find(id);
                ctx.Jogos.Remove(jogoEncotrado);
                ctx.SaveChanges();
            }
        }
    }
}
