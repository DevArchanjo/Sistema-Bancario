using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaBancario.Entities.Exceptions;
using SistemaBancario.Entities.Enums;
using System.Globalization;

namespace SistemaBancario.Entities
{
    internal class Conta
    {
        internal int Numero { get; set; }
        internal int Senha { get; set; }
        internal double Saldo { get; set; } = 0;
        internal StatusConta StatusConta { get; set; } = (StatusConta)1;
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
            if (valor > 0)
            {
                Saldo += valor;
                Console.WriteLine("Depósito realizado no valor de {0}", valor);
            }
            else
            {
                throw new DomainException("O valor para depósito é inválido");
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
                throw new DomainException("Saldo insuficiente");
            }
        }

        public virtual void TransferirValor(double valor)
        {
            if (valor < Saldo)
            {
                Saldo -= valor;
            }
            else
            {
                Console.WriteLine("Não é possivel realizar a transferência, valor da transferência é maior que o saldo atual");
            }
        }
        public void ConsultarSaldo()
        {
            Console.WriteLine("Saldo atual da conta: " + Saldo);
        }

        public override string ToString()
        {
            return " Numero da conta: " + Numero +
            " Titular da conta: " + Cliente.Nome; 
                
        }
    }
}
