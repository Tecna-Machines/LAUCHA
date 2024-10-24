﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
    public class PaginaRegistro<T> where T : class
    {
        public int indicePagina { get;set; }
        public int totalPaginas { get;set; }
        public int totalRegistros { get;set; }
        public List<T> Registros { get; set; } = null!;
    }
}
