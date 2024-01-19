using Loja.API.Entities.DTOs.response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.API.Entities
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [RegularExpression(@"^[a-zA-ZÀ-ÖØ-öø-ÿ\s]+$", ErrorMessage = "O campo Nome deve conter apenas letras.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Formato de CPF inválido. Utilize o formato 123.456.789-01")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo RG é obrigatório")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}-\d{1,2}$", ErrorMessage = "Formato de RG inválido. Utilize o formato 12.345.678-9")]
        public string Rg { get; set; }

        public List<Contato> Contatos { get; set; }
        public List<Endereco> Enderecos { get; set; }

    }
}
