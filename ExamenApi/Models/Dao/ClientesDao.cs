using ExamenApi.Models.Bl.Interface;
using ExamenApi.Models.Dao.Interface;
using ExamenApi.Models.ModelBD;
using ExamenApi.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ExamenApi.Models.Dto.ClientesDto;

namespace ExamenApi.Models.Dao
{
    public class ClientesDao : IClientesDao
    {
        private readonly IBDContextSqlLite db;
        public ClientesDao(IBDContextSqlLite db) 
        {
            this.db = db;
        }
        public Clientes ObtenerCliente(string email, ref ResultSet result) 
        {
            Clientes user = new Clientes();
            try
            {
                user = db.Clientes.Where(x => x.Email == email).FirstOrDefault();
            }catch (Exception ex) 
            {
                result.IsError = true;
                result.Error = ex;
            }
            return user;
        }
        public void CrearCliente(CreateClientDto cliente, ref ResultSet result)
        {
            try
            {
                Clientes newClientes = new Clientes { Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Email = cliente.Email,
                    Contraseña = cliente.Contraseña,
                    FechaDeActualizacion = DateTime.Now,
                    FechaDeCreacion = DateTime.Now,
                };
                db.Clientes.Add(newClientes);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.Error = ex;
            }
        }
        public void ActualizarCliente(UpdateClientDto cliente, ref ResultSet result)
        {
            try
            {
                Clientes clientebd = db.Clientes.Where(x => x.ClienteID == cliente.ClienteID).FirstOrDefault();
                if (clientebd != null) 
                {
                    clientebd.Nombre = cliente.Nombre;
                    clientebd.Apellido = cliente.Apellido;
                    clientebd.Email = cliente.Email;
                    clientebd.Contraseña = cliente.Contraseña;
                    clientebd.FechaDeActualizacion = DateTime.Now;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.IsError = true;
                result.Error = ex;
            }
        }
    }
}