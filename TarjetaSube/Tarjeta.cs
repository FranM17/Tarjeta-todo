using System;

namespace TarjetaSube
{
    public class Tarjeta
    {
        private decimal saldo;
        private const decimal LIMITE_SALDO = 40000m;
        private static readonly decimal[] CargasPermitidas = { 2000, 3000, 4000, 5000, 8000, 10000, 15000, 20000, 25000, 30000 };

        public decimal Saldo
        {
            get { return saldo; }
        }

 
        public Tarjeta()
        {
            saldo = 0;
        }

        public bool Cargar(decimal monto)
        {

            bool montoValido = false;
            foreach (decimal carga in CargasPermitidas)
            {
                if (carga == monto)
                {
                    montoValido = true;
                    break;
                }
            }

            if (!montoValido)
            {
                return false;
            }

            if (saldo + monto > LIMITE_SALDO)
            {
                return false;
            }

            saldo += monto;
            return true;
        }


        public bool DescontarSaldo(decimal monto)
        {
            if (saldo >= monto)
            {
                saldo -= monto;
                return true;
            }
            return false;
        }
    }
}