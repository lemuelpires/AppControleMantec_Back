using System;
using Xunit;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Validation;

namespace AppControleMantec.Domain.Tests
{
    public class OrdemDeServicoTests
    {
        [Fact]
        public void OrdemDeServico_CriarOrdemDeServicoValida_DeveSerValida()
        {
            // Arrange
            var clienteID = 1;
            var funcionarioID = 1;
            var servicoID = 1;
            var dataEntrada = DateTime.UtcNow;
            var status = "Em andamento";
            var observacoes = "Observações da ordem de serviço";

            // Act
            var ordemDeServico = new OrdemDeServico(clienteID, funcionarioID, servicoID, dataEntrada, status, observacoes);

            // Assert
            Assert.NotNull(ordemDeServico);
            Assert.Equal(clienteID, ordemDeServico.ClienteID);
            Assert.Equal(funcionarioID, ordemDeServico.FuncionarioID);
            Assert.Equal(servicoID, ordemDeServico.ServicoID);
            Assert.Equal(dataEntrada, ordemDeServico.DataEntrada);
            Assert.Equal(status, ordemDeServico.Status);
            Assert.Equal(observacoes, ordemDeServico.Observacoes);
            Assert.True(ordemDeServico.Ativo);
        }

        [Fact]
        public void OrdemDeServico_CriarOrdemDeServicoComClienteIDInvalido_DeveLancarExcecao()
        {
            // Arrange
            var clienteID = 0; // ClienteID inválido
            var funcionarioID = 1;
            var servicoID = 1;
            var dataEntrada = DateTime.UtcNow;
            var status = "Em andamento";
            var observacoes = "Observações da ordem de serviço";

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new OrdemDeServico(clienteID, funcionarioID, servicoID, dataEntrada, status, observacoes));
            Assert.Equal("Cliente inválido. Selecione um cliente válido.", exception.Message);
        }

        [Fact]
        public void OrdemDeServico_CriarOrdemDeServicoComFuncionarioIDInvalido_DeveLancarExcecao()
        {
            // Arrange
            var clienteID = 1;
            var funcionarioID = 0; // FuncionarioID inválido
            var servicoID = 1;
            var dataEntrada = DateTime.UtcNow;
            var status = "Em andamento";
            var observacoes = "Observações da ordem de serviço";

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new OrdemDeServico(clienteID, funcionarioID, servicoID, dataEntrada, status, observacoes));
            Assert.Equal("Funcionário inválido. Selecione um funcionário válido.", exception.Message);
        }

        [Fact]
        public void OrdemDeServico_CriarOrdemDeServicoComServicoIDInvalido_DeveLancarExcecao()
        {
            // Arrange
            var clienteID = 1;
            var funcionarioID = 1;
            var servicoID = 0; // ServicoID inválido
            var dataEntrada = DateTime.UtcNow;
            var status = "Em andamento";
            var observacoes = "Observações da ordem de serviço";

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new OrdemDeServico(clienteID, funcionarioID, servicoID, dataEntrada, status, observacoes));
            Assert.Equal("Serviço inválido. Selecione um serviço válido.", exception.Message);
        }

        [Fact]
        public void OrdemDeServico_CriarOrdemDeServicoComStatusInvalido_DeveLancarExcecao()
        {
            // Arrange
            var clienteID = 1;
            var funcionarioID = 1;
            var servicoID = 1;
            var dataEntrada = DateTime.UtcNow;
            var status = ""; // Status inválido
            var observacoes = "Observações da ordem de serviço";

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new OrdemDeServico(clienteID, funcionarioID, servicoID, dataEntrada, status, observacoes));
            Assert.Equal("Status inválido. O status é obrigatório.", exception.Message);
        }

        [Fact]
        public void OrdemDeServico_ConcluirOrdem_DeveAlterarStatusEDataConclusao()
        {
            // Arrange
            var clienteID = 1;
            var funcionarioID = 1;
            var servicoID = 1;
            var dataEntrada = DateTime.UtcNow;
            var status = "Em andamento";
            var observacoes = "Observações da ordem de serviço";
            var ordemDeServico = new OrdemDeServico(clienteID, funcionarioID, servicoID, dataEntrada, status, observacoes);
            var dataConclusao = DateTime.UtcNow;

            // Act
            ordemDeServico.ConcluirOrdem(dataConclusao);

            // Assert
            Assert.Equal("Concluída", ordemDeServico.Status);
            Assert.Equal(dataConclusao, ordemDeServico.DataConclusao);
        }

        [Fact]
        public void OrdemDeServico_CancelarOrdem_DeveAlterarStatusEAtivo()
        {
            // Arrange
            var clienteID = 1;
            var funcionarioID = 1;
            var servicoID = 1;
            var dataEntrada = DateTime.UtcNow;
            var status = "Em andamento";
            var observacoes = "Observações da ordem de serviço";
            var ordemDeServico = new OrdemDeServico(clienteID, funcionarioID, servicoID, dataEntrada, status, observacoes);

            // Act
            ordemDeServico.CancelarOrdem();

            // Assert
            Assert.Equal("Cancelada", ordemDeServico.Status);
            Assert.False(ordemDeServico.Ativo);
        }
    }
}
