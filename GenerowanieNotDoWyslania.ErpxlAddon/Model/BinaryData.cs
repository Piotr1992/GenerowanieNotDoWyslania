using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerowanieNotDoWyslania.ErpxlAddon.Model
{
    class BinaryData
    {
        public string ShortName { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public System.Data.Linq.Binary Data { get; set; }

        public int? GidTyp { get; set; }

        public int? GidNumer { get; set; }

        public int? PK { get; set; }
    }
}
