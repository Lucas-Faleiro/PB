using PB.Models.Exceptions;

namespace PB.Models
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Quantidade { get; private set; }
        public int CategoriaId { get; private set; }
        public Categoria? Categoria { get; private set; }
        public bool Ativo { get; private set; }

        public Produto(int categoriaId, string codigo, string nome, string desc, decimal preco, int qtd)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(codigo);
            ValidarDados(nome, preco, qtd);

            CategoriaId = categoriaId;
            Codigo = codigo.Trim();
            Nome = nome.Trim();
            Descricao = desc?.Trim() ?? string.Empty;
            Preco = preco;
            Quantidade = qtd;
            Ativo = true;
        }

        public bool VerificarDisponibilidade(int qtd)
        {
            return Ativo && qtd > 0 && Quantidade >= qtd;
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public void Reativar()
        {
            Ativo = true;
        }

        public void AtualizarDados(string novoNome, string novaDesc, decimal novoPreco, int novaQtd)
        {
            ValidarDados(novoNome, novoPreco, novaQtd);

            Nome = novoNome.Trim();
            Descricao = novaDesc?.Trim() ?? string.Empty;
            Preco = novoPreco;
            Quantidade = novaQtd;
        }

        public void DebitarEstoque(int qtd)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(qtd);

            if (qtd > Quantidade)
                throw new EstoqueInsuficienteException(
                    $"Estoque insuficiente: disponível {Quantidade}, solicitado {qtd}.");

            Quantidade -= qtd;
        }

        private static void ValidarDados(string nome, decimal preco, int qtd)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nome);
            ArgumentOutOfRangeException.ThrowIfNegative(preco);
            ArgumentOutOfRangeException.ThrowIfNegative(qtd);
        }
    }
}
