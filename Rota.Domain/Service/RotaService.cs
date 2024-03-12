using Rota.Domain.Interface;
using Rota.Entities.ViewModel;
using Rota.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rota.Domain.Service
{
    public class RotaService : IRotaService
    {
        private readonly IRotaRepository _rotaRepository;

        public RotaService(IRotaRepository rotaRepository)
        {
            _rotaRepository = rotaRepository;
        }    
        public Task<List<RotaEntities>> ObterRotas()
        {
            throw new NotImplementedException();
        }

        public async Task<List<RotaEntities>> ObterTodasAsRotas()
        {
            // Obtenha a lista de rotas do repositório
            var todasRotas = await _rotaRepository.ObterTodasAsRotas();
            if (todasRotas.Count == 0)
                return null;

            return todasRotas.OrderBy(r => r.Valor).ToList();
        }

        public async Task<RotaEntities> ObterMelhorRota(string origem, string destino)
        {
            var todasRotas = await _rotaRepository.ObterTodasAsRotas();
            if (todasRotas.Count == 0)
                return null;

            var rotasPossiveis = CalcularTodasRotas(origem, destino, todasRotas);
            if (rotasPossiveis.Count == 0)
                return null;

            // Encontrar a rota com o menor custo total
            var melhorRota = rotasPossiveis.OrderBy(r => r.Valor).First();

            return melhorRota;
        }

        private List<RotaEntities> CalcularTodasRotas(string origem, string destino, List<RotaEntities> todasRotas)
        {
            var rotasPossiveis = new List<RotaEntities>();
            CalcularRotasRecursivamente(origem, destino, new List<string>(), todasRotas, ref rotasPossiveis);
            return rotasPossiveis;
        }

        private void CalcularRotasRecursivamente(string origem, string destino, List<string> rotaAtual, List<RotaEntities> todasRotas, ref List<RotaEntities> rotasPossiveis)
        {
            rotaAtual.Add(origem);

            if (origem == destino)
            {
                var rota = new RotaEntities
                {
                    Origem = string.Join(" - ", rotaAtual),
                    Destino = destino,
                    Valor = CalcularValorRota(rotaAtual, todasRotas)
                };
                rotasPossiveis.Add(rota);
            }
            else
            {
                foreach (var proximaRota in todasRotas.Where(r => r.Origem == origem))
                {
                    CalcularRotasRecursivamente(proximaRota.Destino, destino, rotaAtual, todasRotas, ref rotasPossiveis);
                }
            }

            rotaAtual.RemoveAt(rotaAtual.Count - 1);
        }

        private decimal CalcularValorRota(List<string> rotaAtual, List<RotaEntities> todasRotas)
        {
            decimal valorTotal = 0;
            for (int i = 0; i < rotaAtual.Count - 1; i++)
            {
                var rota = todasRotas.FirstOrDefault(r => r.Origem == rotaAtual[i] && r.Destino == rotaAtual[i + 1]);
                if (rota == null)
                    throw new InvalidOperationException($"Rota de {rotaAtual[i]} para {rotaAtual[i + 1]} não encontrada.");

                valorTotal += rota.Valor;
            }
            return valorTotal;
        }

        public async Task<RotaEntities> AdicionarRota(RotaEntities rota)
        {
            return await _rotaRepository.AdicionarRota(rota);
        }

        public async Task<RotaEntities> AtualizarRota(int id, RotaEntities rota)
        {
            return await _rotaRepository.AtualizarRota(id, rota);
        }

        public Task<bool> DeletarRota(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RotaEntities> ObterRotaPorId(int id)
        {
            return await _rotaRepository.ObterRotaPorId(id);
        }
    }
}
