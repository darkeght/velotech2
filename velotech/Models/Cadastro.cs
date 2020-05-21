using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace velotech.Models
{
    public class Cadastro
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string CpfCnpj { get; set; }
        public string Rg { get; set; }
        public string  Mae { get; set; }
        public string Pai { get; set; }
        public string Emissor { get; set; }
        public int Documento { get; set; }
        public List<Cliente> Clientes { get; set; }
}
}
