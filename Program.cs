﻿using System;
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
            ContaCorrente cCorrente = null;
            ContaPoupanca cPoupanca = null;
            Conta conta = null;
            Conta contaAcessada;
            int operacao = 0;

            do
            {
                try
                {
                    Console.WriteLine("Operações: \n1 -> Abrir conta \n2 -> Acessar conta \n0 -> Sair");
                    operacao = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (operacao)
                    {
                        case 1:
                            Console.Write("Id: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Nome: ");
                            string nome = Console.ReadLine();
                            Console.Write("CPF: ");
                            string cpf = Console.ReadLine();
                            Console.Write("Endereço: ");
                            string endereco = Console.ReadLine();

                            Cliente cliente = new Cliente(id, nome, cpf, endereco);

                            Console.WriteLine("\nQual tipo de conta deseja abrir: \n1 -> Conta Corrente \n2 -> Conta Poupança");
                            operacao = int.Parse(Console.ReadLine());

                            int senha = 0;

                            if (operacao is 1)
                            {
                                Console.Write("\nCrie uma senha: ");
                                senha = int.Parse(Console.ReadLine());

                                conta = new ContaCorrente(senha, cliente);
                            }
                            else if (operacao is 2)
                            {
                                Console.Write("\nCrie uma senha: ");
                                senha = int.Parse(Console.ReadLine());

                                conta = new ContaPoupanca(senha, cliente);
                            }
                            else
                            {
                                Console.WriteLine("Operação inválida");
                            }
                            Console.Clear();

                            banco.CadastrarCliente(cliente);
                            banco.AbrirConta(conta);

                            Console.WriteLine("\nAgora você faz parte do {0}\n", banco.Nome);

                            break;
                        case 2:
                            Console.Write("Numero: ");
                            int numero = int.Parse(Console.ReadLine());
                            Console.Write("Senha: ");
                            senha = int.Parse(Console.ReadLine());
                            contaAcessada = banco.AcessarConta(numero, senha);

                            if (contaAcessada is ContaCorrente)
                            {
                                cCorrente = (ContaCorrente)contaAcessada;
                                Console.WriteLine("Operações: \n1 -> Depositar \n2 -> Sacar \n3 -> Transferir \n4 -> Consultar Saldo");
                                operacao = int.Parse(Console.ReadLine());

                                switch (operacao)
                                {
                                    case 1:
                                        Console.Write("Valor do depósito: ");
                                        double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                                        cCorrente.Depositar(valor);

                                        break;
                                    case 2:
                                        Console.Write("Valor do saque: ");
                                        valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                                        cCorrente.Sacar(valor);
                                        break;
                                    case 3:
                                        Console.Write("Numero da conta: ");
                                        numero = int.Parse(Console.ReadLine());
                                        Console.Write("Valor da transferência: ");
                                        valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                                        conta = banco.EncontrarConta(numero);

                                        Transferencia transferencia = new Transferencia(contaAcessada, conta, valor);
                                        transferencia.Transferir();
                                        break;
                                    case 4:
                                        Console.WriteLine(cCorrente.ConsultarSaldo());
                                        break;
                                }
                            }
                            else if (contaAcessada is ContaPoupanca)
                            {
                                cPoupanca = (ContaPoupanca)contaAcessada;
                                Console.WriteLine("Operações: \n1 -> Depositar \n2 -> Sacar \n3 -> Transferir \n4 -> Consultar Saldo \n5 -> Cusultar rendimento");
                                operacao = int.Parse(Console.ReadLine());

                                switch (operacao)
                                {
                                    case 1:
                                        Console.Write("Valor do depósito: ");
                                        double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                                        cPoupanca.Depositar(valor);

                                        break;
                                    case 2:
                                        Console.Write("Valor do saque: ");
                                        valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                                        cPoupanca.Depositar(valor);
                                        break;
                                    case 3:
                                        Console.Write("Numero da conta: ");
                                        numero = int.Parse(Console.ReadLine());
                                        Console.Write("Valor da transferência: ");
                                        valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                                        conta = banco.EncontrarConta(numero);

                                        Transferencia transferencia = new Transferencia(contaAcessada, conta, valor);
                                        transferencia.Transferir();
                                        break;
                                    case 4:
                                        Console.WriteLine(cPoupanca.ConsultarSaldo());
                                        break;
                                    case 5:
                                        cPoupanca.CalcularRendimento();
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Conta não encontrada, ou credênciais incorretas");
                            }

                            break;
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Valor inválido para este campo");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro inesperado " + ex.Message);
                }
            } while (operacao != 0);
        }
    }
}