using AgendaBlueApi.Data;
using AgendaBlueApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaBlueApi.Repository
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly AgendaContext _context;

        public AgendaRepository(AgendaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AgendaItem>> TodosItens()
        {
            return await _context.AgendaItens.ToListAsync();
        }

        public async Task<AgendaItem> ItemPorId(int id)
        {
            return await _context.AgendaItens.FindAsync(id);
        }

        public async Task AdicionarItem(AgendaItem adicionarItem)
        {
            _context.AgendaItens.Add(adicionarItem);
            await _context.SaveChangesAsync();
        }

        public async Task EditarItem(AgendaItem editarItem)
        {
            _context.Entry(editarItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirItem(int id)
        {
            var item = await _context.AgendaItens.FindAsync(id);
            if (item != null)
            {
                _context.AgendaItens.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}