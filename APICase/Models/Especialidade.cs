using System;
using System.Collections.Generic;

#nullable disable

namespace APICase.Models
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public int Id { get; set; }
        public string Categoria { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
