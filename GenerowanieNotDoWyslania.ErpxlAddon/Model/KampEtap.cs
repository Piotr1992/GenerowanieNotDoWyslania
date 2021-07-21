using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerowanieNotDoWyslania.ErpxlAddon.Model
{
    class KampEtap:T2S_GetKampNagEtapyResult
    {
        public override string ToString()
        {
            return Kod;
        }
        public int Numer { get; set; }
    }
}
