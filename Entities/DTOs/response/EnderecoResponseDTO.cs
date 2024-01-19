using Loja.API.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.API.Entities.DTOs.response
{
    public class EnderecoResponseDTO
    {
        public int Id { get; set; }
        public TipoEnderecoEnum Tipo { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Referencia { get; set; }
        public int ClienteId { get; set; }

        public EnderecoResponseDTO(int id, TipoEnderecoEnum tipo, string cep, string logradouro, int numero,
            string bairro, string complemento, string cidade, string estado, string referencia, int clienteId)
        {
            Id = id;
            Tipo = tipo;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
            Referencia = referencia;
            ClienteId = clienteId;
        }
    }
}
