using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Entities
{
    internal class Cliente
    {
        public Banco banco;
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }    

        public Cliente(string nome, string cpf, string endereco) 
        {
            Id = IncrementarId();
            Nome = nome;
            CPF = cpf;
            Endereco = endereco;
        }

        public int IncrementarId()
        {
            int proxId = 0;
            proxId++;

            return proxId;
        }
    }
}
