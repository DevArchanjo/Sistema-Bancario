using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Globalization;

using SistemaBancario.Entities;
using SistemaBancario.Entities.Exceptions;

namespace SistemaBancario
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco banco = new Banco(1003, "Latam Bank");
            int operacao = 0;

            do
            {
                OperacoesBancarias opBancarias = new OperacoesBancarias(banco);
                operacao = opBancarias.ExibirOperacaoBancaria();
            } while (operacao != 0);
        }
    }
}