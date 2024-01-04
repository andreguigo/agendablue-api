using AgendaBlueApi.Repository;
using AgendaBlueApi.Models;
using AutoMapper;

namespace AgendaBlueApi.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMapper _mapper;

        public AgendaService(IAgendaRepository agendaRepository, IMapper mapper)
        {
            _agendaRepository = agendaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AgendaItemDto>> TodosItens()
        {
            var agenda = await _agendaRepository.TodosItens();
            return _mapper.Map<IEnumerable<AgendaItemDto>>(agenda);
        }

        public async Task<AgendaItemDto> ItemPorId(int id)
        {
            var item = await _agendaRepository.ItemPorId(id);
            return _mapper.Map<AgendaItemDto>(item);
        }

        public async Task AdicionarItem(AgendaItemDto adicionarItem)
        {
            var item = _mapper.Map<AgendaItem>(adicionarItem);
            await _agendaRepository.AdicionarItem(item);
        }

        public async Task EditarItem(int id, AgendaItemDto editarItem)
        {
            var existeItem = await _agendaRepository.ItemPorId(id);
            if (existeItem == null)
                return;

            _mapper.Map(editarItem, existeItem);
            await _agendaRepository.EditarItem(existeItem);
        }

        public async Task ExcluirItem(int id)
        {
            await _agendaRepository.ExcluirItem(id);
        }
    }
}