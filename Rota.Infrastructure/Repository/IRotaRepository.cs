using Rota.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rota.Infrastructure.Repository;

public interface IRotaRepository
{
    Task<List<RotaEntities>> ObterRotas();
    Task<RotaEntities> ObterRotaPorOrigemDestino(string origem, string destino);
    Task<List<RotaEntities>> ObterTodasAsRotas();
    Task<RotaEntities> AdicionarRota(RotaEntities rota);
    Task<RotaEntities> AtualizarRota(int id, RotaEntities rota);
    Task<bool> DeletarRota(int id);
    Task<RotaEntities> ObterRotaPorId(int id);
}
