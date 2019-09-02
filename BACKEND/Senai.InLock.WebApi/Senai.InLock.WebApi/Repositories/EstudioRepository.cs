using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository
    {
        Estudios estudios = new Estudios();

        //listar
        public List<Estudios> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.ToList();
            }
        }

        // buscar por id

        public Estudios BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.FirstOrDefault(x => x.EstudioId == id);
            }
        }
        //adicionar

        public void cadastrar(Estudios estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }


        //deletar

        public void deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Estudios estudioDeletar = ctx.Estudios.Find(id);
                ctx.Estudios.Remove(estudioDeletar);
                ctx.SaveChanges();
            }
        }



        //atualizar
        public void Atualizar(Estudios estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Estudios EstudioBuscado = ctx.Estudios.FirstOrDefault(x => x.EstudioId == estudio.EstudioId);

                EstudioBuscado.NomeEstudio = estudio.NomeEstudio;

                ctx.Estudios.Update(EstudioBuscado);

                ctx.SaveChanges();
            }
        }

    }
}

