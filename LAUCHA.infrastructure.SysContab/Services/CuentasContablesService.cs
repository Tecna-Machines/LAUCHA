using LAUCHA.application.Common.ResultResponse;
using LAUCHA.application.Integrations.SysContab;
using LAUCHA.infrastructure.SysContab.Models;

namespace LAUCHA.infrastructure.SysContab.Services
{
    internal class CuentasContablesService : ICuentasContablesService
    {
        private readonly TecnaDb3Context _dbTecna;

        public CuentasContablesService(TecnaDb3Context dbTecna)
        {
            _dbTecna = dbTecna;
        }

        public Task<Result<IEnumerable<CuentaContableResponse>>> GetCuentasContables()
        {
            var cuentas = _dbTecna.Cuentas;

            var cuentasMap = cuentas.Select(MapCuenta);

            return Task.FromResult(Result.Success(cuentasMap));

        }

        private CuentaContableResponse MapCuenta(Cuenta c)
            => new(c.Id.ToString(), c.NombreCuenta, c.TipoCuenta);
    }
}
