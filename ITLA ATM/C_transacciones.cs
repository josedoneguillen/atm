using System;
using System.Collections.Generic;
using System.Text;

namespace ITLA_ATM
{
    class C_transacciones
    {
        public int numero_transacciones { get; set; }
        public string numero_tarjeta { get; set; }
        public string tipo_transaccion { get; set; }
        public double monto_transacciones { get; set; }

        public double balance_anterio { get; set; }
        public double balance_nuevo { get; set; }

        public void C_transaccion(string numero_tj, string tipo_trans, double monto_trans, double balance_ant, double balance_nuev)
        {
            numero_tarjeta = numero_tj;
            tipo_transaccion = tipo_trans;
            monto_transacciones = monto_trans;
            balance_anterio = balance_ant;
            balance_nuevo = balance_nuev;
        }
    }
}
