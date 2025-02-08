using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Disco
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public int Cant_Canciones { get; set; }
        public string Url_Imagen { get; set; }
        public Estilo Estilo_Disco { get; set; }
        public Tipo Tipo_Disco { get; set; }

    }
}
