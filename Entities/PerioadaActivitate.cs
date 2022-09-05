using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2.Entities
{
    public class PerioadaActivitate
    {
        public string Id { get; set; }
        public string Luna { get; set; }//ianuarie, febr etc
        public int An { get; set; } //anul pentru care tinem baza de date
        public virtual Activitate Activitate {get; set; }
    }
}
