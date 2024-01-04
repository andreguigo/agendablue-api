using AgendaBlueApi.Models;

namespace AgendaBlueApi.Services
{
    public interface IAgendaService
    {
        Task<IEnumerable<AgendaItemDto>> TodosItens();

        Task<AgendaItemDto> ItemPorId(int id);

        Task AdicionarItem(AgendaItemDto adicionarItem);

        Task EditarItem(int id, AgendaItemDto editarItem);

        Task ExcluirItem(int id);
    }
}