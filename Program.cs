using System;
using System.Data;
using System.Globalization;

using SistemaBancario.Entities;

namespace SistemaBancario
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente c1 = new Cliente(01, "Bruna Oliveira", "40084675527", "Rua Emilio Brizolla, 124");
            Conta conta = new Conta(1234, c1);

            Console.WriteLine(conta);

            double valor = double.Parse(Console.ReadLine());
            conta.Depositar(valor);
            Console.WriteLine(conta);
        }
    }
}