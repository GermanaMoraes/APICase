using System;
using System.Collections.Generic;

#nullable disable

namespace APICase.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int Id { get; set; }
        public string Carterinha { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool? Ativo { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
