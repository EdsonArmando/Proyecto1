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

        public string Nombre { get => nombre; set => nombre = value; }
        public string Url { get => url; set => url = value; }

        public Path(string nombre, string url) {
            this.nombre = nombre;
            this.url = url;
        }

    }
}
