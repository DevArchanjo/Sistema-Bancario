using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Entities.Enums
{
    enum StatusConta : int
    {
        Ativa = 1,
        Temporáreamente_inativa = 2,
        Manutencao = 3,
        Bloqueada = 4
    }
}
