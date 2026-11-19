namespace PB.Models
{
    public class Categoria
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public Categoria(string nome)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nome);
            Nome = nome.Trim();
        }

        public void AtualizarNome(string novoNome)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(novoNome);
            Nome = novoNome.Trim();
        }
    }
}
