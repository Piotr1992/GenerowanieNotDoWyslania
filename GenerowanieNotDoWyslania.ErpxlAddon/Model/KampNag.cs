using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerowanieNotDoWyslania.ErpxlAddon.Model
{
    class KampNag:T2S_GetCrmKampNagResult
    {
        public override string ToString()
        {
            return Kod;
        }
    }
}
