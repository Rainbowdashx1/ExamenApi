using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace ExamenApi.Models.Dto
{
    public class ClientesDto
    {
        public class CreateClientDto 
        {
            [Required]
            [StringLength(50)]
            public string Nombre { get; set; }

            [Required]
            [StringLength(50)]
            public string Apellido { get; set; }

            [Required]
            [StringLength(100)]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [StringLength(255)]
            public string Contraseña { get; set; }
        }
        public class UpdateClientDto
        {
            [Required]
            public int ClienteID { get; set; }
            [Required]
            [StringLength(50)]
            public string Nombre { get; set; }

            [Required]
            [StringLength(50)]
            public string Apellido { get; set; }

            [Required]
            [StringLength(100)]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [StringLength(255)]
            public string Contraseña { get; set; }
        }
    }
}