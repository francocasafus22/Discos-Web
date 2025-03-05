﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{

    public enum TipoUsuario
    {
        NORMAL = 1,
        ADMIN = 2
    }

    public class Usuario
    {

        public int Id { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Mail { get; set; }
        public string ImagenURL { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

    }
}
