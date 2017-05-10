﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRestaurante.Models
{
    [Table("Tb_Prato")]
    public class Prato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Nome do prato não pode ser branco.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O valor de ser informado.")]
        public decimal Preco { get; set; }

        public bool Ativo { get; set; }
    }
}