using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dtos
{
    public class DtoTienda
    {
        public Guid IdTienda { get; set; }
        public string sucursal { get; set; }
        public string CodigoPostal { get; set; }
        public string Estado { get; set; }
        public string DelegacionMunicipio { get; set; }
        public string CalleNum { get; set; }

        public DtoTienda(Guid idTienda, string sucursal, string codigoPostal, string estado, string delegacionMunicipio, string calleNum)
        {
            IdTienda = idTienda;
            this.sucursal = sucursal;
            CodigoPostal = codigoPostal;
            Estado = estado;
            DelegacionMunicipio = delegacionMunicipio;
            CalleNum = calleNum;
        }
    }
}
