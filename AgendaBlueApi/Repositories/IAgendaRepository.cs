using AgendaBlueApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaBlueApi.Repository
{
    public interface IAgendaRepository
    {
        Task<IEnumerable<AgendaItem>> TodosItens();

        Task<AgendaItem> ItemPorId(int id);

        Task AdicionarItem(AgendaItem adicionarItem);

        Task EditarItem(AgendaItem editarItem);

        Task ExcluirItem(int id);
    }
}