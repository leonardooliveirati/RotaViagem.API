using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rota.Entities.ViewModel;

namespace Rota.Domain.Interface;

public interface IRotaService
{
    Task<List<RotaEntities>> ObterRotas();
    Task<RotaEntities> ObterMelhorRota(string origem, string destino);
    Task<List<RotaEntities>> ObterTodasAsRotas();
    Task<RotaEntities> AdicionarRota(RotaEntities rota);
    Task<RotaEntities> AtualizarRota(int id, RotaEntities rota);
    Task<RotaEntities> ObterRotaPorId(int id);
    Task<bool> DeletarRota(int id);

}
