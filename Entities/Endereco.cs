using Loja.API.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.API.Entities
{
    public class Endereco
    {

        public Endereco()
        {
            Cep = string.Empty;
            Logradouro = string.Empty;
            Bairro = string.Empty;
            Complemento = string.Empty;
            Cidade = string.Empty;
            Estado = string.Empty;
            Referencia = string.Empty;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public TipoEnderecoEnum Tipo { get; set; }
        [Required]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "Formato de CEP inválido. Utilize o formato 01234-000.")]
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; } 
        public string Estado { get; set; }
        public string Referencia { get; set; }
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
    }
}
