using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigmaBack.Domain.Entities
{
    public class AtualizarImagemProduto
    {
        public int IdProduto { get; set; }
        public string? ImagemProduto { get; set; }
    }
}
