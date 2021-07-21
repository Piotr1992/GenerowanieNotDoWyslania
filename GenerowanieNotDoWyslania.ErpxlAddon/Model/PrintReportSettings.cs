using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerowanieNotDoWyslania.ErpxlAddon.Model
{
    public class PrintReportSettings
    {
        public int Zrodlo { get; set; }
        public int Wydruk { get; set; }
        public int Format { get; set; }
        public string FiltrSQL { get; set; }
        public string FileName { get; set; }
        public string Nazwa { get; set; }
        public override string ToString()
        {
            return Nazwa;
        }
    }
}
