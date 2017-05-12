﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRestaurante
{
    [Table("TB_Restaurante")]
    public class Restaurante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(80)]
        [Required(ErrorMessage = "Nome do restaurante não pode ser branco.")]
        public string Nome { get; set; }

        public bool Ativo { get; set; } = true;
    }
}
