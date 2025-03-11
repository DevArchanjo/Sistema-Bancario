using System;
using System.Collections.Generic;
using System.Globalization;


namespace SistemaBancario.Entities
{
    internal class ContaPoupanca : Conta
    {
        public double TaxaRendimento { get; set; } = 0.01;
        public ContaPoupanca(int senha, Cliente cliente) : base(senha, cliente)
        {
        }

        public void CalcularRendimento()
        {
            double rendimento = Saldo * TaxaRendimento;
            Saldo += rendimento;
            Console.WriteLine("Rendimento da conta: {0} saldo atual: {1}", rendimento.ToString("F2", CultureInfo.InvariantCulture), Saldo.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
