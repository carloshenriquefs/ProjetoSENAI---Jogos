using System;
using System.Collections.Generic;

namespace Senai_TesteORM.Domains
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdTipoUsuario { get; set; } // aCEITA VALORES NULOS

        public TipoUsuarios IdTipoUsuarioNavigation { get; set; }
    }
}
