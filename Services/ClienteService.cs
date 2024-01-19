using Loja.API.Entities;
using Loja.API.Entities.DTOs.response;
using Loja.API.Exceptions;
using Loja.API.Persistence;
using Microsoft.EntityFrameworkCore;
namespace Loja.API.Services
{
    public class ClienteService
    {
        private readonly ClienteDbContext _context;
        private readonly ContatoDbContext _contatoDbContext;
        private readonly EnderecoDbContext _enderecoDbContext;
        public ClienteService(ClienteDbContext context, ContatoDbContext contatoDbContext, EnderecoDbContext enderecoDbContext)
        {
            _context = context;
            _contatoDbContext = contatoDbContext;
            _enderecoDbContext = enderecoDbContext;
        }
        public Cliente CreateCliente(Cliente cliente)
        {
            if (_context.Cliente.Any(c => c.Email == cliente.Email))
            {
                throw new CustomObjectDuplicated("Já existe um cliente cadastrado com o mesmo e-mail");
            }
            if (_context.Cliente.Any(c => c.Cpf == cliente.Cpf))
            {
                throw new CustomObjectDuplicated("Já existe um cliente cadastrado com o mesmo CPF");
            }
            if (_context.Cliente.Any(c => c.Rg == cliente.Rg))
            {
                throw new CustomObjectDuplicated("Já existe um cliente cadastrado com o mesmo RG");
            }
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
           
            return cliente;
        }
        public ClienteResponseDTO GetClienteById(int id)
        {
            var cliente = _context.Cliente.FirstOrDefault(c => c.Id == id) ??
                throw new CustomNotFound($"Nenhum cliente encontrado com o ID: {id}");
            var contatos = _contatoDbContext.Contato.Where(c => c.ClienteId == cliente.Id).ToList();
            var enderecos = _enderecoDbContext.Endereco.Where(c => c.ClienteId == cliente.Id).ToList();
            List<ContatoResponseDTO> contatosDTO = [];
            List<EnderecoResponseDTO> enderecosDTO = [];
            foreach (var contato in contatos)
            {
                ContatoResponseDTO contatoDTO = new(contato.Id, contato.Tipo, contato.Ddd, contato.Telefone, contato.ClienteId);
                contatosDTO.Add(contatoDTO);
            }
            foreach (var endereco in enderecos)
            {
                EnderecoResponseDTO enderecoDTO = new(endereco.Id, endereco.Tipo, endereco.Cep, endereco.Logradouro, endereco.Numero, endereco.Bairro, endereco.Complemento, endereco.Cidade, endereco.Estado, endereco.Referencia, endereco.ClienteId);
                enderecosDTO.Add(enderecoDTO);
            }
            ClienteResponseDTO clienteResponse = new(cliente.Id, cliente.Nome, cliente.Email, cliente.Cpf, cliente.Rg, contatosDTO, enderecosDTO);
            return clienteResponse;
        }
        public List<ClienteResponseDTO> GetAllClientes()
        {
            var clientes = _context.Cliente.ToList();
            if (clientes.Count == 0)
            {
                throw new CustomNotFound("Nenhum cliente encontrado");
            }
            List<ClienteResponseDTO> clientesDTO = [];
            foreach (var cliente in clientes)
            {
                var contatos = _contatoDbContext.Contato.Where(c => c.ClienteId == cliente.Id).ToList();
                var enderecos = _enderecoDbContext.Endereco.Where(c => c.ClienteId == cliente.Id).ToList();
                List<ContatoResponseDTO> contatosDTO = [];
                List<EnderecoResponseDTO> enderecosDTO = [];
                foreach (var contato in contatos)
                {
                    ContatoResponseDTO contatoDTO = new(contato.Id, contato.Tipo, contato.Ddd, contato.Telefone, contato.ClienteId);
                    contatosDTO.Add(contatoDTO);
                }
                foreach (var endereco in enderecos)
                {
                    EnderecoResponseDTO enderecoDTO = new(endereco.Id, endereco.Tipo, endereco.Cep, endereco.Logradouro, endereco.Numero, endereco.Bairro, endereco.Complemento, endereco.Cidade, endereco.Estado, endereco.Referencia, endereco.ClienteId);
                    enderecosDTO.Add(enderecoDTO);
                }
                ClienteResponseDTO clienteDTO = new(cliente.Id, cliente.Nome, cliente.Email, cliente.Cpf, cliente.Rg, contatosDTO, enderecosDTO);
                clientesDTO.Add(clienteDTO);
            }
            return clientesDTO;
        }
        public List<ClienteResponseDTO> GetClienteWithParams(string nome, string email, string cpf)
        {
            try
            {
                var clientesQuery = _context.Cliente.AsQueryable();

                if (!string.IsNullOrEmpty(nome))
                {
                    clientesQuery = clientesQuery.Where(c => c.Nome.Contains(nome));
                }
                if (!string.IsNullOrEmpty(email))
                {
                    clientesQuery = clientesQuery.Where(c => c.Email.Contains(email));
                }
                if (!string.IsNullOrEmpty(cpf))
                {
                    clientesQuery = clientesQuery.Where(c => c.Cpf.Contains(cpf));
                }
                var clientes = clientesQuery.ToList();
                if (clientes.Count == 0)
                {
                    throw new CustomNotFound("Nenhum cliente encontrado");
                }
                List<ClienteResponseDTO> clientesDTO = [];
                foreach (var cliente in clientes)
                {
                    var contatos = _contatoDbContext.Contato.Where(c => c.ClienteId == cliente.Id).ToList();
                    var enderecos = _enderecoDbContext.Endereco.Where(c => c.ClienteId == cliente.Id).ToList();
                    List<ContatoResponseDTO> contatosDTO = [];
                    List<EnderecoResponseDTO> enderecosDTO = [];
                    foreach (var contato in contatos)
                    {
                        ContatoResponseDTO contatoDTO = new(contato.Id, contato.Tipo, contato.Ddd, contato.Telefone, contato.ClienteId);
                        contatosDTO.Add(contatoDTO);
                    }
                    foreach (var endereco in enderecos)
                    {
                        EnderecoResponseDTO enderecoDTO = new(endereco.Id, endereco.Tipo, endereco.Cep, endereco.Logradouro, endereco.Numero, endereco.Bairro, endereco.Complemento, endereco.Cidade, endereco.Estado, endereco.Referencia, endereco.ClienteId);
                        enderecosDTO.Add(enderecoDTO);
                    }
                    ClienteResponseDTO clienteDTO = new(cliente.Id, cliente.Nome, cliente.Email, cliente.Cpf, cliente.Rg, contatosDTO, enderecosDTO);
                    clientesDTO.Add(clienteDTO);
                }
                // Verifique se há clientes
                if (clientes.Count == 0)
                {
                    throw new CustomNotFound("Nenhum cliente encontrado");
                }
                return clientesDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Cliente UpdateCliente(int id, Cliente cliente)
        {
            var clienteExistente = _context.Cliente.FirstOrDefault(c => c.Id == id);

            if (clienteExistente == null)
            {
                _context.Add(cliente);
            }
            else
            {
                clienteExistente.Nome = cliente.Nome;
                clienteExistente.Email = cliente.Email;
                clienteExistente.Cpf = cliente.Cpf;
                clienteExistente.Rg = cliente.Rg;

                clienteExistente.Contatos = cliente.Contatos;
                clienteExistente.Enderecos = cliente.Enderecos;
            }

            try
            {               
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar as alterações: {ex.Message}");
            }

            return clienteExistente;
        }

        public bool DeteleCliente(int id)
        {
            var clienteExistente = _context.Cliente.Include(c => c.Contatos).Include(e => e.Enderecos).FirstOrDefault(c => c.Id == id) ??
                throw new CustomNotFound($"Nenhum cliente encontrado com o ID: {id}");
            _context.Cliente.Remove(clienteExistente);
            _context.SaveChanges();
            return true;
        }
    }
}