using Loja.API.Entities.Enums;

namespace Loja.API.Entities.DTOs.response
{
    public class ContatoResponseDTO
    {
        public int Id { get; set; }
        public TipoContatoEnum Tipo { get; set; }
        public int Ddd { get; set; }
        public Decimal Telefone { get; set; }
        public int ClientId { get; set; }


        public ContatoResponseDTO(int id, TipoContatoEnum tipo, int ddd, Decimal telefone, int clienteId)
        {
            Id = id;
            Tipo = tipo;
            Ddd = ddd;
            Telefone = telefone;
            ClientId = clienteId;
            
        }
    }
}
