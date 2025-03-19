using System;
using System.Collections.Generic;
using System.Linq;

using SistemaBancario.Entities.Exceptions;
using System.Globalization;

namespace SistemaBancario.Entities
{
    internal class OperacoesBancarias
    {
        internal Banco Banco { get; set; }
        public int operacao { get; set; } = 3;
        public OperacoesBancarias(Banco banco)
        {
            Banco = banco;
        }
        public int ExibirOperacaoBancaria()
        {
            try
            {
                Console.WriteLine("Operações: \n1 -> Abrir uma conta \n2 -> Acessar conta \n0 -> Sair");
                operacao = int.Parse(Console.ReadLine());

                if (operacao == 1)
                {
                    Console.Clear();
                    AbrirContaCliente();
                    return operacao;
                }
                else if (operacao == 2)
                {
                    Console.Clear();
                    AcessarConta();
                    return operacao;
                }
                Console.Clear();
            }
            catch (FormatException fe)
            {
                Console.Clear();
                Console.WriteLine("Operação inválida, digite o valor da operação que deseja realizar");
            }

            return operacao;
        }

        public void AbrirContaCliente()
        {
            try
            {
                Conta conta = null;
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("CPF: ");
                string cpf = Console.ReadLine();
                Console.Write("Endereço: ");
                string endereco = Console.ReadLine();

                Cliente cliente = new Cliente(nome, cpf, endereco);

                Console.WriteLine("\nQual tipo de conta deseja abrir: \n1 -> Conta Corrente \n2 -> Conta Poupança");
                operacao = int.Parse(Console.ReadLine());
                Console.Write("\nDefina uma senha: ");
                int senha = int.Parse(Console.ReadLine());

                if (operacao == 1)
                {
                    ContaCorrente cCorrente = new ContaCorrente(senha, cliente);
                    conta = cCorrente;
                }
                else if (operacao == 2)
                {
                    ContaPoupanca cPoupanca = new ContaPoupanca(senha, cliente);
                    conta = cPoupanca;
                }
                else
                {
                    Console.WriteLine("Operação inválida");
                }
                Console.Clear();


                if (conta != null)
                {
                    Banco.CadastrarCliente(cliente);
                    Banco.AbrirConta(conta);
                }
                else
                {
                    Console.WriteLine("Erro ao gerar conta");
                }

            }
            catch (FormatException fe)
            {
                Console.WriteLine("Valor inválido para esse campo");
            }
        }

        public void ExibirOperacaoDaConta(Conta conta)
        {
            if (conta != null)
            {
                if (conta is ContaCorrente)
                {
                    Console.WriteLine("Operações: \n1 -> Depositar \n2 -> Sacar \n3 -> Transferir \n4 -> Consultar Saldo \n6 -> Sair\n");
                }
                else if (conta is ContaPoupanca)
                {
                    Console.WriteLine("Operações: \n1 -> Depositar \n2 -> Sacar \n3 -> Transferir \n4 -> Consultar Saldo \n5 -> Cusultar rendimento \n6 -> Sair\n");
                }
            }
            else
            {
                throw new DomainException("Conta não encontrada, operações inválidas.");
            }
        }

        public int AcessarConta()
        {
            int tentativa = 3;
            int numero = 0;
            int senha = 0;

            Conta conta = null;
            ContaCorrente cCorrente = null;
            ContaPoupanca cPoupanca = null;

            for (int i = 1; tentativa >= i; i++)
            {
                try
                {
                    Console.Write("Numero da conta: ");
                    numero = int.Parse(Console.ReadLine());
                    Console.Write("Senha: ");
                    senha = int.Parse(Console.ReadLine());

                    conta = Banco.AcessarConta(numero, senha);

                    if (conta != null)
                    {
                        i = 3;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Credenciais inválidas, você possui {0}/3 tentativas", i);
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Valor incorreto para este campo");
                }
            }
            Console.Clear();

            while (operacao != 6)
            {
                try
                {
                    if (conta is ContaCorrente)
                    {
                        cCorrente = (ContaCorrente)conta;
                        ExibirOperacaoDaConta(cCorrente);
                    }
                    else if (conta is ContaPoupanca)
                    {
                        cPoupanca = (ContaPoupanca)conta;
                        ExibirOperacaoDaConta(cPoupanca);
                    }
                    else
                    {
                        Console.WriteLine("Você excedeu o número de tentativas de acesso á conta, tente mais tarde.");
                        return operacao = 0;
                    }

                    operacao = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (operacao)
                    {
                        case 1:
                            Console.Write("Valor a depositar: ");
                            double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                            if (conta is ContaCorrente)
                            {
                                cCorrente.Depositar(valor);
                            }
                            else if (conta is ContaPoupanca)
                            {
                                cPoupanca.Depositar(valor);
                            }

                            break;
                        case 2:
                            Console.Write("Valor a Sacar: ");
                            valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                            if (conta is ContaCorrente)
                            {
                                cCorrente.Sacar(valor);
                            }
                            else if (conta is ContaPoupanca)
                            {
                                cPoupanca.Sacar(valor);
                            }

                            break;
                        case 3:
                            Console.Write("Valor a transferir: ");
                            valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            Console.Write("Numero da conta: ");
                            numero = int.Parse(Console.ReadLine());
                            Console.Clear();

                            Conta contaDestino = Banco.EncontrarConta(numero);
                            if (contaDestino != null)
                            {
                                Transferencia transfe = new Transferencia(conta, contaDestino, valor);
                                transfe.Transferir();
                            }
                            else
                            {
                                throw new NullReferenceException("Conta informada para transferência não foi encontrada");
                            }

                            break;
                        case 4:

                            if (conta is ContaCorrente)
                            {
                                cCorrente.ConsultarSaldo();
                            }
                            else if (conta is ContaPoupanca)
                            {
                                cPoupanca.ConsultarSaldo();
                            }

                            break;
                        case 5:
                            if (conta is ContaPoupanca)
                            {
                                cPoupanca.CalcularRendimento();
                            }

                            break;
                        case 6:
                            Console.WriteLine("\nA {0} agradece por sua preferência!\n",Banco.Nome);

                            break;
                        default:

                            Console.WriteLine("Operação de conta é inválida");

                            break;
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Valor inadequado para este campo");
                }
                catch (NullReferenceException nf)
                {
                    Console.WriteLine("A conta informada não foi encontrada");
                }
            }
            return 0;
        }
    }
}
