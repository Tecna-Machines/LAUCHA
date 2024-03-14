using LAUCHA.domain.interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAUCHA.infrastructure.Services
{
    public class MarcasService : IMarcasService
    {
        private readonly string _connectionString;

        public MarcasService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public HorasPeriodo ConsularHorasPeriodo(string dni,DateTime desde, DateTime hasta)
        {
            string query = "SELECT marcas.IdPersonal, ingreso, egreso, Sum([egreso]-[ingreso])*24 AS horasComunes, " +
                           "(horasComunes - 9) AS horasExtras\r\nFROM marcas \r\nwhere idPersonal = 282 AND (ingreso " +
                           "BETWEEN #2024/01/01# And #2024/02/01#)\r\ngroup by IdPersonal, ingreso, egreso;";

            using (OdbcConnection connection = new OdbcConnection(_connectionString))
            {
                OdbcCommand command = new OdbcCommand(query, connection);
                connection.Open();
            }

                return new HorasPeriodo();
        }
    }
}
