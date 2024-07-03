using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using AppControleMantec.Domain.Validation;

namespace AppControleMantec.Domain.Entities
{
    public class Funcionario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("Nome")]
        public string Nome { get; set; } = string.Empty;

        [BsonElement("Cargo")]
        public string Cargo { get; set; } = string.Empty;

        [BsonElement("Telefone")]
        public string Telefone { get; set; } = string.Empty;

        [BsonElement("Email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("DataContratacao")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DataContratacao { get; set; }

        [BsonElement("Ativo")]
        public bool Ativo { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnore]
        public virtual ICollection<OrdemDeServico> OrdensDeServico { get; set; } = new List<OrdemDeServico>();

        #region Construtores
        // Construtor padrão necessário para o MongoDB Driver
        public Funcionario()
        {
        }

        public Funcionario(string nome, string cargo, string telefone, string email, DateTime dataContratacao)
        {
            ValidateDomain(nome, cargo, telefone, email);
            Nome = nome;
            Cargo = cargo;
            Telefone = telefone;
            Email = email;
            DataContratacao = dataContratacao;
            Ativo = true;
        }

        public Funcionario(string id, string nome, string cargo, string telefone, string email, DateTime dataContratacao, bool ativo)
        {
            Id = id;
            Nome = nome;
            Cargo = cargo;
            Telefone = telefone;
            Email = email;
            DataContratacao = dataContratacao;
            Ativo = ativo;
            OrdensDeServico = new List<OrdemDeServico>();
        }
        #endregion

        #region Métodos Públicos
        public void Desativar()
        {
            Ativo = false;
        }
        #endregion

        #region Métodos Privados de Validação
        private void ValidateDomain(string nome, string cargo, string telefone, string email)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. O nome é obrigatório.");
            DomainExceptionValidation.When(nome.Length < 3, "Nome inválido. O nome deve conter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(cargo != null && cargo.Length > 100, "Cargo inválido. O cargo deve conter no máximo 100 caracteres.");

            DomainExceptionValidation.When(telefone != null && telefone.Length > 20, "Telefone inválido. O telefone deve conter no máximo 20 caracteres.");

            DomainExceptionValidation.When(!IsValidEmail(email), "Email inválido. O email deve ser válido.");

            Nome = nome;
            Cargo = cargo;
            Telefone = telefone;
            Email = email;
        }

        private static bool IsValidEmail(string email)
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
        #endregion
    }
}
