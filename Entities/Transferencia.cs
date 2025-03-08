using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Entities
{
    internal class Transferencia
    {
        public Conta ContaOrigem { get; set; }
        public Conta ContaDestino { get; set; }
        public double ValorTransferencia { get; set; }
        
        public Transferencia(Conta origem, Conta destino, double valor)
        {
            ContaOrigem = origem;
            ContaDestino = destino;
            ValorTransferencia = valor;
        }

        public void Transferir()
        {
            if (ContaOrigem.Saldo < ValorTransferencia)
            {
                Console.WriteLine("Saldo insuficiente para transferência");
            }
            else
            {
                ContaOrigem.TransferirValor(ValorTransferencia);
                ContaDestino.Depositar(ValorTransferencia);
            }
        }

        public override string ToString()
        {
            return ContaOrigem + " " + ContaDestino + " " + ValorTransferencia;
        }
    }
}
