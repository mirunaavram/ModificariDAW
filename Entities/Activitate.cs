using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2.Entities
{
    public class Activitate
    {
        public string Id { get; set; }
        public string Nume { get; set; }
        public string Categorie { get; set; }

        public int NrParticipanti { get; set; }
        public virtual ICollection<PerioadaActivitate> PerioadaActivitate { get; set; } //lista de perioade in care se desfasoara o activitate
        //o activitate se poate desfasura in: ianuarie,februarie
        public virtual ICollection<Tabela> TanarActivitate { get; set; }
    }
}
