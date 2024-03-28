using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympGuide.Domain.Abstraction
{
    public abstract class Entity
    {
        public Guid Id { get; init; } = new Guid();
    }
}
