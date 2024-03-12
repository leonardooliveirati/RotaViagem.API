using Microsoft.EntityFrameworkCore;
using Rota.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rota.Infrastructure.Repository;

public class RotaRepository : IRotaRepository
{
    private readonly RotaDbContext _context;

    public RotaRepository(RotaDbContext context)
    {
        _context = context;
    }

    public async Task<List<RotaEntities>> ObterRotas()
    {
        return await _context.Rotas.ToListAsync();
    }

    public async Task<RotaEntities> ObterRotaPorOrigemDestino(string origem, string destino)
    {
        return await _context.Rotas.FirstOrDefaultAsync(r => r.Origem == origem && r.Destino == destino);
    }

    public async Task<List<RotaEntities>> ObterTodasAsRotas()
    {
        return await _context.Rotas.ToListAsync();
    }

    public Task<RotaEntities> AdicionarRota(RotaEntities rota)
    {
        throw new NotImplementedException();
    }

    public async Task<RotaEntities> AtualizarRota(int id, RotaEntities rota)
    {
        var rotaExistente = await _context.Rotas.FindAsync(id);
        if (rotaExistente == null)
            return null;

        rotaExistente.Origem = rota.Origem;
        rotaExistente.Destino = rota.Destino;
        rotaExistente.Valor = rota.Valor;

        await _context.SaveChangesAsync();
        return rotaExistente;
    }

    public async Task<bool> DeletarRota(int id)
    {
        var rota = await _context.Rotas.FindAsync(id);
        if (rota == null)
            return false;

        _context.Rotas.Remove(rota);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<RotaEntities> ObterRotaPorId(int id)
    {
        return await _context.Rotas.FindAsync(id);
    }
}

