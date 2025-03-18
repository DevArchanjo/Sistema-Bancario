using System;
using System.Globalization;

using SistemaBancario.Entities.Exceptions;

namespace SistemaBancario.Entities
{
    internal class ContaCorrente : Conta
    {
        internal double LimiteChequeEspecial { get; set; } = 500.0D;
        internal double SaldoCheque { get; set; }
        public ContaCorrente(int senha, Cliente cliente) : base(senha, cliente)
        {
        }

        public override void Sacar(double valor)
        {
            if (Saldo >= valor)
            {
                Saldo -= valor;
                Console.WriteLine("Saque realizado no valor de: {0} Saldo atual: {1}", valor, Saldo);
            }
            else
            {
                if (Saldo + LimiteChequeEspecial >= valor)
                {
                    Saldo = Saldo - valor;
                    SaldoCheque = LimiteChequeEspecial + Saldo;
                    Console.WriteLine("Saldo atual: {0} \nSaldo cheque especal: {1}", Saldo.ToString("F2", CultureInfo.InvariantCulture), SaldoCheque.ToString("F2", CultureInfo.InvariantCulture));
                }
                else
                {
                    throw new DomainException("Operação inválida o valor informado é maior do que o saldo da conta");
                }
            }
        }

        public override void TransferirValor(double valor)
        {
            if (Saldo >= valor)
            {
                Saldo -= valor;
            }
            else
            {
                if (Saldo + LimiteChequeEspecial >= valor)
                {
                    Saldo = Saldo - valor;
                    SaldoCheque = LimiteChequeEspecial + Saldo;
                }
                else
                {
                    throw new DomainException("Operação inválida o valor informado é maior do que o saldo da conta");
                }
            }
        }
    }
}
