using Application.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    /// <summary>
    /// Serviço de cálculo de posições com base em operações e cotações.
    /// </summary>
    public class PosicaoService
    {
        private readonly IOperacaoRepository _operacaoRepo;
        private readonly ICotacaoRepository _cotacaoRepo;

        public PosicaoService(IOperacaoRepository operacaoRepo, ICotacaoRepository cotacaoRepo)
        {
            _operacaoRepo = operacaoRepo;
            _cotacaoRepo = cotacaoRepo;
        }

        /// <summary>
        /// Retorna o total investido: soma de (quantidade * preço) + corretagem.
        /// </summary>
        public async Task<decimal> GetTotalInvestidoAsync(int usuarioId)
        {
            var ops = await _operacaoRepo.GetByUsuarioAsync(usuarioId);
            return ops.Sum(o => (o.PrecoUnitario * o.Quantidade) + o.Corretagem);
        }

        /// <summary>
        /// Retorna o preço médio ponderado de aquisição.
        /// </summary>
        public async Task<decimal> GetPrecoMedioAsync(int usuarioId)
        {
            var ops = await _operacaoRepo.GetByUsuarioAsync(usuarioId);
            var totalQty = ops.Sum(o => o.Quantidade);
            if (totalQty == 0) return 0;
            var totalCost = ops.Sum(o => (o.PrecoUnitario * o.Quantidade) + o.Corretagem);
            return totalCost / totalQty;
        }

        /// <summary>
        /// Retorna o Profit & Loss com base na cotação atual.
        /// </summary>
        public async Task<decimal> GetPnLAsync(int usuarioId, decimal cotacaoAtual)
        {
            var ops = await _operacaoRepo.GetByUsuarioAsync(usuarioId);
            var totalQty = ops.Sum(o => o.Quantidade);
            if (totalQty == 0) return 0;
            var averageCost = ops.Sum(o => (o.PrecoUnitario * o.Quantidade) + o.Corretagem) / totalQty;
            return (cotacaoAtual - averageCost) * totalQty;
        }

        /// <summary>
        /// Retorna a soma de todas as corretagens pagas.
        /// </summary>
        public async Task<decimal> GetTotalCorretagemAsync(int usuarioId)
        {
            var ops = await _operacaoRepo.GetByUsuarioAsync(usuarioId);
            return ops.Sum(o => o.Corretagem);
        }
            }
}
