using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace velotech.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public int VeloRefId { get; set; }
        public string Nome { get; set; }
    }
}
