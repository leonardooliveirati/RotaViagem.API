using Rota.Domain.Interface;
using Rota.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rota.Services
{
    public class RotaAppService
    {
        private readonly IRotaService _rotaService;

        public RotaAppService(IRotaService rotaService)
        {
            _rotaService = rotaService;
        }

        public async Task<List<RotaEntities>> ObterTodasAsRotas(string origem, string destino)
        {
            return await _rotaService.ObterTodasAsRotas();
        }
    }
}
