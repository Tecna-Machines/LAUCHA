using LAUCHA.domain.interfaces.IServices;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Runtime.Versioning;

namespace LAUCHA.infrastructure.Services.Marcas
{
    internal class AccesDatabaseService
    {
        private readonly string _connectionString;

        public AccesDatabaseService(string networkSource,
                                    string connectionString)
        {
            _connectionString = connectionString;
        }


        public List<Marca> GetUserMarcas(string dni,DateTime fechaInicio,DateTime fechaFin)
        {

                var marcas = new List<Marca>();


                    using (var connection = new OdbcConnection(_connectionString))
                    {
                        connection.Open();

                    string query = @"
        SELECT marcas.IdPersonal, marcas.nombre_completo, marcas.ingreso, marcas.egreso, 
               marcas.DebeEntrar, 
               IIf(IsNull([marcas]![ingreso])=False,IIf(TimeValue([marcas]![ingreso])>([marcas]![DebeEntrar]+0.010416),'Tarde','A tiempo'),'Sin Ingreso') AS Tarde,
               Hour([marcas]![egreso]-[marcas]![ingreso]) AS [HsTrabajadas], 
               datos_personal.Area
        FROM marcas 
        INNER JOIN datos_personal 
        ON marcas.IdPersonal = datos_personal.ID
        WHERE datos_personal.activo = Yes
        AND datos_personal.dni = @dni 
        AND marcas.ingreso BETWEEN @fechaInicio AND @fechaFin
        ORDER BY marcas.ingreso;";

                    using (var command = new OdbcCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@dni", dni);
                            command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                            command.Parameters.AddWithValue("@fechaFin", fechaFin);

                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var egreso = DateTime.MinValue;
                                    var ingreso = DateTime.MinValue;
                                    var debeEntrar = DateTime.MinValue.TimeOfDay;

                                 if(!reader.IsDBNull(3)) { egreso = reader.GetDateTime(3); }
      
                                 if(!reader.IsDBNull(2)){ ingreso = reader.GetDateTime(2);}

                                 if(!reader.IsDBNull(4)){debeEntrar = reader.GetDateTime(4).TimeOfDay;}

                                    TimeSpan diferencia = egreso - ingreso;
                                    double hsTrabajadasDecimal = diferencia.TotalHours;

                                    if (diferencia.Hours < 0){ diferencia = new TimeSpan(0);}

                                    var marca = new Marca
                                    {
                                        IdPersonal = reader.GetInt32(0).ToString(),
                                        NombreCompleto = reader.GetString(1),
                                        Ingreso = ingreso,
                                        Egreso = egreso,
                                        DebeEntrar = debeEntrar,
                                        Tarde = reader.GetString(5),
                                        HsTrabajadas = Math.Round(hsTrabajadasDecimal, 2),
                                        Area = reader.GetString(7)
                                    };

                                    marcas.Add(marca);
                                }
                            }
                        }
                    }
                

            //ignora los egresos ,cuya fecha es 00/00/0000
            return marcas.Where(m => m.Egreso != DateTime.MinValue).ToList();
        }

        public List<Marca> GetMarcas(DateTime fechaInicio, DateTime fechaFin)
        {
            var marcas = new List<Marca>();

                using (var connection = new OdbcConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                    SELECT marcas.IdPersonal, marcas.nombre_completo, marcas.ingreso, marcas.egreso, 
                           marcas.DebeEntrar, 
                           IIf(IsNull([marcas]![ingreso])=False,IIf(TimeValue([marcas]![ingreso])>([marcas]![DebeEntrar]+0.010416),'Tarde','A tiempo'),'Sin Ingreso') AS Tarde,
                           Hour([marcas]![egreso]-[marcas]![ingreso]) AS [HsTrabajadas], 
                           datos_personal.Area
                    FROM marcas 
                    INNER JOIN datos_personal 
                    ON marcas.IdPersonal = datos_personal.ID
                    WHERE (((datos_personal.activo)=Yes)) 
                    AND marcas.ingreso BETWEEN @fechaInicio AND @fechaFin
                    ORDER BY marcas.ingreso;";

                    using (var command = new OdbcCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                        command.Parameters.AddWithValue("@fechaFin", fechaFin);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var egreso = DateTime.MinValue;
                                var ingreso = DateTime.MinValue;
                                var debeEntrar = DateTime.MinValue.TimeOfDay;

                                Int16 hsTrabajadas = 0;

                                if (!reader.IsDBNull(3))
                                {
                                    egreso = reader.GetDateTime(3);
                                }

                                if (!reader.IsDBNull(2))
                                {
                                    ingreso = reader.GetDateTime(2);
                                }

                                if (!reader.IsDBNull(6))
                                {
                                    hsTrabajadas = reader.GetInt16(6);
                                }

                                if (!reader.IsDBNull(4))
                                {
                                    debeEntrar = reader.GetDateTime(4).TimeOfDay;
                                }

                                TimeSpan diferencia = egreso - ingreso;

                                if (diferencia.Hours < 0) { diferencia = new TimeSpan(0); }

                                var marca = new Marca
                                {
                                    IdPersonal = reader.GetInt32(0).ToString(),
                                    NombreCompleto = reader.GetString(1),
                                    Ingreso = ingreso,
                                    Egreso = egreso,
                                    DebeEntrar = debeEntrar,
                                    Tarde = reader.GetString(5),
                                    HsTrabajadas = Math.Round(diferencia.TotalHours, 2),
                                    Area = reader.GetString(7)
                                };

                                marcas.Add(marca);
                            }
                        }
                    }
                }
            
            return marcas;
        }
    }
}
