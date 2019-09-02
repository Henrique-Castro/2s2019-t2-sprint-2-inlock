using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public Usuarios BuscarPorEmailSenha(LoginViewModel dadosLogin)
        {
            using(InLockContext ctx = new InLockContext())
            {
                return ctx.Usuarios.FirstOrDefault(x => x.Email.Equals(dadosLogin.Email) && x.Senha == dadosLogin.Senha);
            }
        }
    }
}
