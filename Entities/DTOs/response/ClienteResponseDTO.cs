using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Loja.API.Entities.DTOs.response
{
    public class ClienteResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }

        public List<ContatoResponseDTO> Contatos { get; set; }
        public List<EnderecoResponseDTO> Enderecos { get; set; }

        public ClienteResponseDTO(int id, string nome, string email, string cpf, string rg, List<ContatoResponseDTO> contatos, List<EnderecoResponseDTO> enderecos)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Rg = rg;
            Contatos = contatos;
            Enderecos = enderecos;
        }
    }
}
