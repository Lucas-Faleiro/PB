using PB.Models.Enums;

namespace PB.Models
{
    public class Pedido
    {
        public int Id { get; private set; }
        public DateTime Data { get; private set; }
        public int ConsumidorId { get; private set; }
        public Consumidor? Consumidor { get; private set; }
        public int FuncionarioId { get; private set; }
        public Funcionario? Funcionario { get; private set; }
        public PagamentoEnum Pagamento { get; private set; }
        public decimal Frete { get; private set; }
        public List<ItemPedido> Itens { get; private set; } = new();

        private Pedido()
        {

        }
        public Pedido(int consumidorId, int funcionarioId, PagamentoEnum pagamento, decimal frete)
        {
            ValidarDados(consumidorId, funcionarioId, frete);

            ConsumidorId = consumidorId;
            FuncionarioId = funcionarioId;
            Pagamento = pagamento;
            Frete = frete;
            Data = DateTime.UtcNow;
        }

        public ItemPedido AdicionarItem(Produto produto, int qtd)
        {
            ArgumentNullException.ThrowIfNull(produto);

            ItemPedido item = new ItemPedido(produto, qtd, produto.Preco);
            Itens.Add(item);
            return item;
        }

        public decimal CalcularTotal()
        {
            return Itens.Sum(i => i.CalcularSubtotal()) + Frete;
        }

        private static void ValidarDados(int consumidorId, int funcionarioId, decimal frete)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(consumidorId);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(funcionarioId);
            ArgumentOutOfRangeException.ThrowIfNegative(frete);
        }
    }
}
