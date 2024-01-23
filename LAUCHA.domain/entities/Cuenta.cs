﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.domain.entities
{
     public class Cuenta
    {
        public string NumeroCuenta { get; set; } = null!;
        public bool estadoCuenta { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string DniEmpleado { get; set; } = null!;
        public Empleado Empleado { get; set; } = null!;
        public ICollection<Transaccion> Transacciones { get; set; } = null!;
        public ICollection<Credito> Creditos { get; set; } = null!;
        public IList<DescuentoFijoPorCuenta> DescuentosFijosPorCuenta { get; set; } = null!;
    }
}