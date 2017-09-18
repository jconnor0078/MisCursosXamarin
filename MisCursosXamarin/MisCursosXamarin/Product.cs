using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCursosXamarin
{
    class Product
    {
        public string nombre { get; set; }

        public string codigo { get; set; }

        public string precioCiento { get; set; }
        public string[] colores { get; set; }
        public string cantidad { get; set; }

        public string imagen { get; set; }

        public string precioMillar { get; set; }
        public JArray items { get; set; }
    }
}
