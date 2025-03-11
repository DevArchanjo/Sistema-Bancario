using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Entities
{
    internal class Conta
    {
        internal int Numero { get; set; }
        internal int Senha { get; set; }
        internal double Saldo { get; set; } = 0;
        internal bool ContaAtiva { get; set; } = true;
        internal List<Transferencia> transferencias { get; set; }
        internal Cliente Cliente { get; set; }

        public Conta(int senha, Cliente cliente)
        {
            Numero = GerarNumeroDaConta();
            Senha = senha;
            Cliente = cliente;
        }

        public int GerarNumeroDaConta()
        {
            Random random = new Random();
            int numeroGerado = random.Next(10000, 65000);

            return numeroGerado;
        }
        public virtual void Depositar(double valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Operação inválida");
            }
            else
            {
                Saldo += valor;
                Console.WriteLine("Depósito realizado no valor de {0}", valor);
            }
        }

        public virtual void Sacar(double valor)
        {
            if (Saldo > valor)
            {
                Saldo -= valor;
                Console.WriteLine("Saque realizado no valor de {0}, Saldo atual: {1}", valor, Saldo);
            }
            else
            {
                Console.WriteLine("Saldo insuficiente, não é possivel sacar o valor de {0} pois o saldo da conta é de {1}", valor, Saldo);
            }
        }

        public void TransferirValor(double valor)
        {
            Saldo -= valor;
            Console.WriteLine("Valor transferido: {0} Saldo atual: {1}", valor, Saldo);
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
