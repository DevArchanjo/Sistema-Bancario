﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaBancario.Entities
{
    internal class Banco
    {
        public int NumeroAgencia { get; set; }
        public string Nome { get; set; }
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public List<Conta> Contas { get; set; } = new List<Conta>();

        public Banco(int numero, string nome)
        {
            NumeroAgencia = numero;
            Nome = nome;
        }

        public void CadastrarCliente(Cliente cliente)
        {
            Clientes.Add(cliente);
        }

        public void AbrirConta(Conta conta)
        {
            Contas.Add(conta);
            Console.WriteLine("Conta criada com sucesso! \nNumero da conta: {0} Senha: {1} \nGuarde esses dados, eles não serão exibidos novamente", conta.Numero, conta.Senha);
        }

        public Conta AcessarConta(int numero, int senha)
        {
            Conta conta = null;

            var filtrarConta = (from c in Contas
                         where numero == c.Numero && senha == c.Senha
                         select c);

            foreach (Conta c in filtrarConta)
            {
                conta = c;
            }

            return conta;
        }

        public Conta EncontrarConta(int numero)
        {
            Conta conta = null;
            var filtrarConta = (from c in Contas
                                where numero == c.Numero
                                select c);

            foreach (Conta c in filtrarConta)
            {
                conta = c;
            }

            return conta;
        }
    }
}
