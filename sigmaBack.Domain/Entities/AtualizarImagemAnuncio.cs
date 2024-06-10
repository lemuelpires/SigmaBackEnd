using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigmaBack.Domain.Entities
{
    public class AtualizarImagemAnuncio
    {
        public int IdAnuncio { get; set; }
        public string? ReferenciaImagem { get; set; }
    }
}
