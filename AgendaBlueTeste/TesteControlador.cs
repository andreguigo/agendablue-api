using AgendaBlueApi.Controllers;
using AgendaBlueApi.Models;
using AgendaBlueApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AgendaBlueTeste
{
    public class TesteControlador
    {
        [Fact]
        public async Task TodosResultadosDevolutivosDaAgenda()
        {
            // Arrange
            var mockAgendaService = new Mock<IAgendaService>();
            var agenda = new List<AgendaItemDto>
            {
                new AgendaItemDto { Id = 1, Nome = "Item 1", Email = "item1@example.com", Telefone = "123456789" },
                new AgendaItemDto { Id = 2, Nome = "Item 2", Email = "item2@example.com", Telefone = "987654321" }
            };
            mockAgendaService.Setup(service => service.TodosItens()).ReturnsAsync(agenda);

            var controlador = new AgendaController(mockAgendaService.Object);

            // Act
            var resultado = await controlador.TodosItens();

            // Assert
            var okResultado = Assert.IsType<OkObjectResult>(resultado);
            var modelo = Assert.IsAssignableFrom<IEnumerable<AgendaItemDto>>(okResultado.Value);
            Assert.Equal(2, modelo.Count());
        }

        [Fact]
        public async Task RetornarItemDaAgendaPorId()
        {
            // Arrange
            var mockAgendaService = new Mock<IAgendaService>();
            var item = new AgendaItemDto { Id = 1, Nome = "Item 1", Email = "item1@example.com", Telefone = "123456789" };
            mockAgendaService.Setup(service => service.ItemPorId(1)).ReturnsAsync(item);

            var controlador = new AgendaController(mockAgendaService.Object);

            // Act
            var resultado = await controlador.ItemPorId(1);

            // Assert
            var okResultado = Assert.IsType<OkObjectResult>(resultado);
            var modelo = Assert.IsType<AgendaItemDto>(okResultado.Value);
            Assert.Equal(1, modelo.Id);
        }

        [Fact]
        public async Task CriarNovoItemDaAgenda()
        {
            // Arrange
            var mockAgendaService = new Mock<IAgendaService>();
            var criarItem = new AgendaItemDto { Nome = "Novo Item", Email = "novoitem@example.com", Telefone = "999999999" };

            mockAgendaService.Setup(service => service.AdicionarItem(It.IsAny<AgendaItemDto>())).Returns(Task.CompletedTask);

            var controlador = new AgendaController(mockAgendaService.Object);

            // Act
            var resultado = await controlador.AdicionarItem(criarItem);

            // Assert
            var acaoResultadoCriacao = Assert.IsType<CreatedAtActionResult>(resultado);
            var modelo = Assert.IsType<AgendaItemDto>(acaoResultadoCriacao.Value);
            Assert.Equal(criarItem.Nome, modelo.Nome);
        }

        [Fact]
        public async Task EditarNaoRetornarResultadoAposAtualizarItemDaAgenda()
        {
            // Arrange
            var mockAgendaService = new Mock<IAgendaService>();
            var editarItem = new AgendaItemDto { Id = 1, Nome = "Item Atualizado", Email = "atualizado@example.com", Telefone = "111111111" };

            mockAgendaService.Setup(service => service.EditarItem(It.IsAny<int>(), It.IsAny<AgendaItemDto>())).Returns(Task.CompletedTask);

            var controlador = new AgendaController(mockAgendaService.Object);

            // Act
            var resultado = await controlador.EditarItem(1, editarItem);

            // Assert
            Assert.IsType<NotFoundResult>(resultado);
        }

        [Fact]
        public async Task ExcluirNaoRetornaResultadoAposExcluirItemDaAgenda()
        {
            // Arrange
            var mockAgendaService = new Mock<IAgendaService>();

            mockAgendaService.Setup(service => service.ExcluirItem(1)).Returns(Task.CompletedTask);

            var controlador = new AgendaController(mockAgendaService.Object);

            // Act
            var resultado = await controlador.ExcluirItem(1);

            // Assert
            Assert.IsType<NotFoundResult>(resultado);
        }
    }
}