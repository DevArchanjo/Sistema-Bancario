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
        public DateTime Data { get; set; }
        
        public Transferencia(Conta origem, Conta destino, double valor)
        {
            ContaOrigem = origem;
            ContaDestino = destino;
            ValorTransferencia = valor;
            Data = DateTime.Now;
        }

        public void Transferir()
        {
            try
            {
                if (ContaOrigem != null && ContaDestino != null)//verifica se as contas existem
                {
                    if (ContaOrigem.Saldo > ValorTransferencia)//verifica se o valor do saldo é suficiente
                    {
                        ContaOrigem.TransferirValor(ValorTransferencia);
                        ContaDestino.DepositoDeValorTransferido(ValorTransferencia);

                        Console.WriteLine(ToString());
                    }
                    else
                    {
                        Console.WriteLine("Saldo da conta é insuficiente, para realizar a transferencia");
                    }
                }
            }
            catch (NullReferenceException nrf)
            {
                Console.WriteLine("Conta não encontrada " + nrf);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Comprovante de transferência");
            sb.AppendLine("Transferido para: " + ContaDestino.Cliente.Nome);
            sb.AppendLine("Valor transferido: " + ValorTransferencia);
            sb.AppendLine("Data e hora da transferencia: " + Data.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("-------------------------------------------------");
            sb.AppendLine("Origem");
            sb.AppendLine("Nome: " + ContaOrigem.Cliente.Nome);

            return sb.ToString();
        }
    }
}
