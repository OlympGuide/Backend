using System.ComponentModel.DataAnnotations;

namespace OlympGuide.Domain.Abstraction
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; init; } =  Guid.NewGuid();

        public override bool Equals(object? obj)
        {
           if(obj is Entity entity)
            {
                return entity.Id == Id;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
