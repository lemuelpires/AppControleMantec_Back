using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using AppControleMantec.Domain.Validation;

namespace AppControleMantec.Domain.Entities
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; } = string.Empty;

        [BsonElement("Endereco")]
        public string Endereco { get; set; } = string.Empty;

        [BsonElement("Telefone")]
        public string Telefone { get; set; } = string.Empty;

        [BsonElement("Email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("DataCadastro")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DataCadastro { get; set; }

        [BsonElement("Ativo")]
        public bool Ativo { get; set; }

        /*[BsonIgnoreIfNull]
        [BsonElement("OrdensDeServico")]
        public ICollection<OrdemDeServico> OrdensDeServico { get; set; } = new List<OrdemDeServico>();*/

        // Construtor padrão necessário para o MongoDB Driver
        public Cliente()
        {
            Id = ObjectId.GenerateNewId().ToString(); // Gera um novo ObjectId para o Id
            DataCadastro = DateTime.UtcNow;
            Ativo = true;
        }

        // Construtor utilizado para criar instâncias com dados específicos
        public Cliente(string nome, string endereco, string telefone, string email)
            : this() // Chama o construtor padrão para inicialização básica
        {
            ValidateDomain(nome, endereco, telefone, email);
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
        }

        // Outro construtor utilizado para inicializar todos os campos
        public Cliente(string id, string nome, string endereco, string telefone, string email, DateTime dataCadastro, bool ativo)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            DataCadastro = dataCadastro;
            Ativo = ativo;
        }

        // Método para desativar o cliente
        public void Desativar()
        {
            Ativo = false;
        }

        // Método privado de validação dos dados do cliente
        private void ValidateDomain(string nome, string endereco, string telefone, string email)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. O nome é obrigatório.");
            DomainExceptionValidation.When(nome.Length < 3, "Nome inválido. O nome deve conter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(endereco != null && endereco.Length > 255, "Endereço inválido. O endereço deve conter no máximo 255 caracteres.");

            DomainExceptionValidation.When(telefone != null && telefone.Length > 20, "Telefone inválido. O telefone deve conter no máximo 20 caracteres.");

            DomainExceptionValidation.When(!IsValidEmail(email), "Email inválido. O email deve ser válido.");
        }

        // Método para validar se o email é válido
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
