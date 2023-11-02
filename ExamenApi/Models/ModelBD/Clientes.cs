using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using Newtonsoft.Json;

namespace ExamenApi.Models.ModelBD
{
    [Table("Clientes")]
    public class Clientes
    {
        [Key]
        [ApiExplorerSettings(IgnoreApi = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [JsonIgnore]
        [ApiExplorerSettings(IgnoreApi = true)]
        [DataType(DataType.DateTime)]
        public DateTime FechaDeCreacion { get; set; } = DateTime.Now;

        [JsonIgnore]
        [ApiExplorerSettings(IgnoreApi = true)]
        [DataType(DataType.DateTime)]
        public DateTime? FechaDeActualizacion { get; set; }
    }
}