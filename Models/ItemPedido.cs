namespace PB.Models
{
    public class ItemPedido
    {
        public int Id { get; private set; }
        public int PedidoId { get; private set; }
        public int ProdutoId { get; private set; }
        public Produto? Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }

        private ItemPedido()
        {

        }

        public ItemPedido(Produto produto, int qtd, decimal precoUnitario)
        {
            ArgumentNullException.ThrowIfNull(produto);
            ValidarDados(qtd, precoUnitario);

            Produto = produto;
            Quantidade = qtd;
            PrecoUnitario = precoUnitario;
            ProdutoId = produto.Id;
        }

        public decimal CalcularSubtotal()
        {
            return PrecoUnitario * Quantidade;
        }

        private static void ValidarDados(int qtd, decimal precoUnitario)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(precoUnitario);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(qtd);
        }
    }
}

