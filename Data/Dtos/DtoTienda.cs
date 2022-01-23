using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dtos
{
    public class DtoTienda
    {
        public Guid IdTienda { get; set; }
        public string Sucursal { get; set; }
        public string CodigoPostal { get; set; }
        public string Estado { get; set; }

        public Guid IdUsuario { get; set; }
        public string DelegacionMunicipio { get; set; }
        public string CalleNum { get; set; }

        public DtoTienda(Guid idTienda, string sucursal, string codigoPostal, string estado, string delegacionMunicipio, string calleNum, Guid idUsuario)
        {
            IdUsuario = idUsuario;
            IdTienda = idTienda;
            Sucursal = sucursal;
            CodigoPostal = codigoPostal;
            Estado = estado;
            DelegacionMunicipio = delegacionMunicipio;
            CalleNum = calleNum;
        }

        public DtoTienda(Guid idTienda, string sucursal, string codigoPostal, string estado, string delegacionMunicipio, string calleNum)
        {

            IdTienda = idTienda;
            Sucursal = sucursal;
            CodigoPostal = codigoPostal;
            Estado = estado;
            DelegacionMunicipio = delegacionMunicipio;
            CalleNum = calleNum;
        }

        public DtoTienda(string sucursal, string codigoPostal, string estado, string delegacionMunicipio, string calleNum)
        {

            Sucursal = sucursal;
            CodigoPostal = codigoPostal;
            Estado = estado;
            DelegacionMunicipio = delegacionMunicipio;
            CalleNum = calleNum;
        }

        public static DtoTienda Create(string sucursal, string codigoPostal, string estado, string delegacionMunicipio, string calleNum)
        {
            return new DtoTienda(sucursal, codigoPostal, estado, delegacionMunicipio, calleNum);
        }

        public static DtoTienda Create(Guid idTienda, string sucursal, string codigoPostal, string estado, string delegacionMunicipio, string calleNum, Guid idUsuario)
        {
            return new DtoTienda(idTienda, sucursal, codigoPostal, estado, delegacionMunicipio, calleNum, idUsuario);
        }

    }
}
