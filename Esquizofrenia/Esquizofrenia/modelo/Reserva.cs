using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquizofrenia.modelo
{
    public class Reserva
    {
        public int idReserva;
        public DateTime fecha;
        public string hora;

        public Reserva(int idReserva, DateTime fecha, string hora)
        {
            this.idReserva = idReserva;
            this.fecha = fecha;
            this.hora = hora;
        }

        public Reserva(DateTime fecha, string hora)
        {
            this.fecha = fecha;
            this.hora = hora;
        }
    }
}
