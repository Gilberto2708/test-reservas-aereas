using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test_reservas.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Aeropuerto_Origen { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime Horario_Salida { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Aeropuerto_Llegada { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime Horario_Llegada { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Aerolinea { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Numero_Vuelo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Tipo_Pasajero { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Precio { get; set; }

    }
}
