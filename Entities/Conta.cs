using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Entities
{
    internal class Conta
    {
        public int Numero { get; set; }
        public int Senha { get; set; }
        public double Saldo { get; private set; } = 0;
        public bool ContaAtiva { get; set; } = true;
        public List<Transferencia> transferencias { get; set; }
        public Cliente Cliente { get; set; }

        public Conta(int senha, Cliente cliente)
        {
            Numero = GerarNumeroDaConta();
            Senha = senha;
            Cliente = cliente;
        }

        public int GerarNumeroDaConta()
        {
            Random random = new Random();
            int numeroGerado = random.Next(1000, 65000);

            return numeroGerado;
        }
        public void Depositar(double valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Operação inválida");
            }
            else
            {
                Saldo += valor;
            }
        }

        public void Sacar(double valor)
        {
            if (valor > Saldo)
            {
                Console.WriteLine("Saldo insuficiente, não é possivel sacar o valor de {0} pois o saldo é de {1}", valor, Saldo);
            }
            else
            {
                Saldo -= valor;
            }
        }

        public void TransferirValor(double valor)
        {
            Saldo -= valor;
        }
        public double ConsultarSaldo()
        {
            return Saldo;
        }

        public override string ToString()
        {
            return "Titular da conta: " + Cliente.Nome
                + " Numero da conta: " + Numero;
        }
    }
}
