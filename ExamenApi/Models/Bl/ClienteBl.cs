using ExamenApi.Models.Bl.Interface;
using ExamenApi.Models.Dao;
using ExamenApi.Models.Dao.Interface;
using ExamenApi.Models.ModelBD;
using ExamenApi.Models.Util;
using System;
using static ExamenApi.Models.Dto.ClientesDto;

namespace ExamenApi.Models.Bl
{
    public class ClienteBl : IClienteBl
    {
        private static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        private readonly IClientesDao ClientesDao;
        public ClienteBl(IClientesDao ClientesDao) 
        {
            this.ClientesDao = ClientesDao;
        }
        public Clientes ObtenerCliente(string Email,ref ResultSet result)
        {
            Clientes user = ClientesDao.ObtenerCliente(Email,ref result);
            if (result.IsError)
            {
                log.Error(result.Error, "Error al consultar email : " + Email);
            }
            else if(user == null)
            {
                log.Error("Cliente es null con el email consultado : " + Email);

            }
            return user;
        }
        public void CrearCliente(CreateClientDto cliente, ref ResultSet result)
        {
            ClientesDao.CrearCliente(cliente, ref result);
            if (result.IsError)
            {
                log.Error(result.Error, "Error al crear ciente");
            }
        }
        public void ActualizarCliente(UpdateClientDto cliente, ref ResultSet result)
        {
            ClientesDao.ActualizarCliente(cliente, ref result);
            if (result.IsError)
            {
                log.Error(result.Error, "Error al actualizar ciente");
            }
        }
    }
}