namespace PB.Models
{
    public class Funcionario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public Funcionario(string nome)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nome);
            Nome = nome.Trim();
        }
    }
}
