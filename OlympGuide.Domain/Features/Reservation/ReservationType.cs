﻿using OlympGuide.Domain.Abstraction;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Domain.Features.Reservation
{
    public class ReservationType : Entity
    {
        public Guid SportFieldId { get; set; }
        public required UserProfile User { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public ReservationStates State { get; set; }
    }
}