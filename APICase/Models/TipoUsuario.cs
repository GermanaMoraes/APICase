using System;
using System.Collections.Generic;

#nullable disable

namespace APICase.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
