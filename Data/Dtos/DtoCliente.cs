using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Dtos
{
    public class DtoCliente
    {
        public DtoCliente(string nombre, string codigoPostal, string estado, string delegacionMunicipio, string calleNum)
        {

            Nombre = nombre;
            CodigoPostal = codigoPostal;
            Estado = estado;
            DelegacionMunicipio = delegacionMunicipio;
            CalleNum = calleNum;
        }

        public DtoCliente(Guid idCliente, string nombre, string codigoPostal, string estado, string delegacionMunicipio, string calleNum)
        {
            IdCliente = idCliente;
            Nombre = nombre;
            CodigoPostal = codigoPostal;
            Estado = estado;
            DelegacionMunicipio = delegacionMunicipio;
            CalleNum = calleNum;
        }

        public Guid IdCliente { get; set; }
        public string Nombre { get; set; }
        public string CodigoPostal { get; set; }
        public string Estado { get; set; }
        public string DelegacionMunicipio { get; set; }
        public string CalleNum { get; set; }

        public static DtoCliente Create(string nombre, string codigoPostal, string estado, string delegacionMunicipio, string calleNum)
        {
            return new DtoCliente(nombre, codigoPostal, estado, delegacionMunicipio, calleNum);
        }

        public static DtoCliente Create(Guid idCliente, string nombre, string codigoPostal, string estado, string delegacionMunicipio, string calleNum)
        {
            return new DtoCliente(idCliente, nombre, codigoPostal, estado, delegacionMunicipio, calleNum);
        }
    }
}
