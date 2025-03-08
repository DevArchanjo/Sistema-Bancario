using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Entities
{
    internal class Banco
    {
        public int NumeroAgencia { get; set; }
        public string Nome { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Conta> Contas { get; set; }

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
            //verificar se é conta Corrente ou Poupanca ante de abrir e salvar cada tipo de conta ou invés de conta genérica
            Contas.Add(conta);
        }
    }
}
