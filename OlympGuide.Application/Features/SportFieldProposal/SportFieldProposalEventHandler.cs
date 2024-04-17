using MediatR;
using OlympGuide.Application.Features.SportField;
using OlympGuide.Domain.Features.SportField;
using OlympGuide.Domain.Features.SportFieldProposal;

namespace OlympGuide.Application.Features.SportFieldProposal
{
    public class SportFieldProposalEventHandler(ISportFieldService service) : INotificationHandler<SportFieldProposalApprovedEvent>
    {

        private readonly ISportFieldService _service = service;
        public Task Handle(SportFieldProposalApprovedEvent message, CancellationToken cancellationToken)
        {
            SportFieldType sportFieldToAdd = new SportFieldType
            {
                Name = message.SportFieldProposal.SportFieldName,
                Description = message.SportFieldProposal.SportFieldDescription,
                Longitude = message.SportFieldProposal.SportFieldLongitude,
                Latitude = message.SportFieldProposal.SportFieldLatitude,
                Address = message.SportFieldProposal.SportFieldAddress
            };
            _service.AddSportField(sportFieldToAdd);
            return Task.CompletedTask;
        }

    }
}
