using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_reservas.Models;

namespace test_reservas.Repository.IRepository
{
    public interface IReservaRepository
    {
        IEnumerable<Reserva> GetAllReserva();
        
         IEnumerable<Reserva> GetAllReserva(string origen, string destino, string tipo_persona, string fecha_salida, string fecha_llegada, string numero_vuelo);

        Reserva GetReserva(int id);

        bool ReservaExists(int id);

        bool ReservaNumeroVueloExists(string numero_vuelo);

        bool CreateReserva(Reserva reserva);

        bool UpdateReserva(Reserva reserva);

        bool DeleteReserva(Reserva reserva);

        bool Save();

    }
}
