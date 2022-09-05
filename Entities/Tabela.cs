using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2.Entities
{
    public class Tabela //tabela asociativa din relatia Many to Many intre Activitate si Tineri
    {
        public Guid IdTanar { get; set; }
        public virtual Tanar Tineri { get; set; }
        public string IdActivitate { get; set; }
        public virtual Activitate Activitate { get; set; }
        public int An { get; set; }
    }
}
