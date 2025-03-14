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
            //verificar se a conta existe usando o bloco Try Cath 
            try
            {
                if (ContaOrigem.Saldo < ValorTransferencia)//só transfere se o saldo for positivo
                {
                    Console.WriteLine("Saldo insuficiente para transferência");
                }
                else
                {
                    ContaOrigem.TransferirValor(ValorTransferencia);
                    ContaDestino.Depositar(ValorTransferencia);
                }
            }
            catch (NullReferenceException nrf)
            {
                Console.WriteLine("Conta não encontrada " + nrf);
            }
        }

        public override string ToString()
        {
            return ContaOrigem + " " + ContaDestino + " " + ValorTransferencia;
        }
    }
}
