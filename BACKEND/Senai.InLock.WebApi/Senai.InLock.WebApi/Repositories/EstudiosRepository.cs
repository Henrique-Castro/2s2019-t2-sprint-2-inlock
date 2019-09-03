using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudiosRepository
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

        public Estudios BuscarPorId(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.FirstOrDefault(x => x.EstudioId == id);
            }
        }
        

        public void Cadastrar(Estudios novoEstudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Add(novoEstudio);
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

        public void Atualizar(Estudios estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Estudios EstudioBuscado = ctx.Estudios.FirstOrDefault(x => x.EstudioId == estudio.EstudioId);

                EstudioBuscado.NomeEstudio = estudio.NomeEstudio;
                EstudioBuscado.PaisOrigem = estudio.PaisOrigem;
                EstudioBuscado.DataCriacao = estudio.DataCriacao;
                EstudioBuscado.UsuarioId = estudio.UsuarioId;

                ctx.Estudios.Update(EstudioBuscado);

                ctx.SaveChanges();
            }
        }

        public List<Estudios> ListarEstudiosJogos()
        {
            using(InLockContext ctx = new InLockContext())
            {
                JogosRepository JogosRepository = new JogosRepository();
                List<Jogos> listaDeJogos = JogosRepository.Listar();
                return ctx.Estudios.Include(x => x.Jogos).Where(x => x.EstudioId == listaDeJogos.Single().EstudioId).ToList();
            }
        }
    }
}
