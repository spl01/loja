using Loja.API.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.API.Entities
{
    public class Contato
    {

        public Contato()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório. EX: Residencial, Comercial ou Celular.")]
        public TipoContatoEnum Tipo { get; set; }

        [Required(ErrorMessage = "O campo DDD é obrigatório.")]
        [Range(00, 99, ErrorMessage = "O DDD deve estar no formato EX: 11, 22, 47.")]
        public int Ddd { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [RegularExpression(@"^\d{8,9}$", ErrorMessage = "O campo Telefone deve conter somente dígitos.")]
        public Decimal Telefone { get; set; }
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
    }
}
