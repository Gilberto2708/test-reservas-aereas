using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_reservas.Data;
using test_reservas.Models;
using test_reservas.Repository.IRepository;

namespace test_reservas.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly test_reservasContext context;
        public ReservaRepository(test_reservasContext context)
        {
            this.context = context;
        }
        public bool CreateReserva(Reserva reserva)
        {
            context.Reserva.Add(reserva);
            return  Save();
        }

        public bool DeleteReserva(Reserva reserva)
        {
            context.Reserva.Remove(reserva);
            return Save();
        }

        public IEnumerable<Reserva> GetAllReserva()
        {
            return context.Reserva.ToList();
        }

        public IEnumerable<Reserva> GetAllReserva(string origen, string destino, string tipo_pasajero, string hora_salida, string hora_llegada, string numero_vuelo)
        {

            IEnumerable<Reserva> lst = context.Reserva.ToList();          
           lst =  context.Reserva.ToList().Where( x => x.Aeropuerto_Origen.Contains(origen)
                                               || x.Aeropuerto_Llegada.Contains(destino)
                                               || x.Numero_Vuelo.Contains(numero_vuelo)                                               
                                               || x.Tipo_Pasajero.Contains(tipo_pasajero) 
                                               );

            if (hora_salida != ",") { lst = lst.Where(f => f.Horario_Salida == Convert.ToDateTime(hora_salida)); }
            if (hora_salida != ",") { lst = lst.Where(f => f.Horario_Salida == Convert.ToDateTime(hora_salida)); }

            return lst;
        }

        public Reserva GetReserva(int id)
        {
            return context.Reserva.FirstOrDefault(x => x.Id.Equals(id));
        }

      
        public bool ReservaExists(int id)
        {
            return context.Reserva.Any(x => x.Id.Equals(id));
        }

        public bool ReservaNumeroVueloExists(string numero_vuelo)
        {
            return context.Reserva.Any(x => x.Numero_Vuelo.Equals(numero_vuelo));
        }

        public bool Save()
        {
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateReserva(Reserva reserva)
        {
            context.Reserva.Update(reserva);
            return Save();
        }
    }
}
