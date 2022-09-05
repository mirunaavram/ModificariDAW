using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2.Entities
{
    public class Tanar 
    {
        public Guid Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        public DateTime DateOfBirth { get; set; }
        public virtual Locatie Locatie { get; set; }
        public virtual ICollection<Tabela> TanarActivitate { get; set; }
    }
}
