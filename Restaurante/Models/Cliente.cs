using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WebRestaurante.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Nome do cliente não pode ser branco.")]
        public string Nome { get; set; }
        public int Idade { get; set; }
        public bool Ativo { get; set; }

        //public virtual ICollection<Prato> Pratos { get; set; }
    }
}