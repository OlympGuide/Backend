namespace OlympGuide.Domain.Abstraction
{
    public abstract class Entity
    {
        public Guid Id { get; set; } = new Guid();
    }
}
