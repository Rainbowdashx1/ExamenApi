using ExamenApi.Models.ModelBD;
using ExamenApi.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ExamenApi.Models.Dto.ClientesDto;

namespace ExamenApi.Models.Bl.Interface
{
    public interface IClienteBl
    {
        Clientes ObtenerCliente(string Email, ref ResultSet result);
        void CrearCliente(CreateClientDto cliente, ref ResultSet result);
        void ActualizarCliente(UpdateClientDto cliente, ref ResultSet result);
    }
}