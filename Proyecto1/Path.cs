using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Path
    {
        string nombre;
        string url;
        string anio;
        string mes;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Url { get => url; set => url = value; }
        public string Anio { get => anio; set => anio = value; }
        public string Mes { get => mes; set => mes = value; }

        public Path(string nombre, string url,string anio,string mes) {
            this.nombre = nombre;
            this.url = url;
            this.anio = anio;
            this.mes = mes;
        }

    }
}
