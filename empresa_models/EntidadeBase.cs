using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empresa_models
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }

    }
}
