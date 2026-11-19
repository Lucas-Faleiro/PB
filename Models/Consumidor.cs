namespace PB.Models
{
    public class Consumidor
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public Consumidor(string nome)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nome);
            Nome = nome.Trim();
        }
    }
}
