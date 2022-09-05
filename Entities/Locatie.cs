using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2.Entities
{
    public class Locatie
    {
        public string Id { get; set; }
        public string TanarId { get; set; }
        public string Oras { get; set; }
        public string Tara { get; set; }
        public virtual Tanar Tineri { get; set; }

    }
}
