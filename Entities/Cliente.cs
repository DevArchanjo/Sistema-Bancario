using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Entities
{
    internal class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }    

        public Cliente(int id, string nome, string cpf, string endereco) 
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Endereco = endereco;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Nome + " CPF: " + " Endereço: " + Endereco);

            return sb.ToString();
        }
    }
}
