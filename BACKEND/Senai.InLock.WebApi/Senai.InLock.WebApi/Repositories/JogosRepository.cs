using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogosRepository
    {
        public List<Jogos> Listar()
        {
            using (InLockContext ctx = new InLockContext())
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

        public void Cadastrar(Jogos novoJogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(novoJogo);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Jogos jogoModificado)
        {
            using(InLockContext ctx = new InLockContext())
            {
                Jogos jogoEncontrado = ctx.Jogos.FirstOrDefault(x => x.JogoId == jogoModificado.JogoId);
                if(jogoEncontrado == null)
                {
                    throw new Exception();
                }
            }
        }
    }
}
