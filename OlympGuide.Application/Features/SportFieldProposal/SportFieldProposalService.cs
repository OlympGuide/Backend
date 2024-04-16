﻿using OlympGuide.Application.Features.SportField;
using OlympGuide.Domain.Features.SportFieldProposal;

namespace OlympGuide.Application.Features.SportFieldProposal
{
    public class SportFieldProposalService(ISportFieldProposalRepository repository) : ISportFieldProposalService
    {
        private readonly ISportFieldProposalRepository _repository = repository;

        public Task<List<SportFieldProposalType>> GetAllSportFieldProposals()
        {
            return _repository.GetAllSportFieldProposals();
        }

        public Task<List<SportFieldProposalType>> GetAllOpenSportFieldProposals()
        {
            return _repository.GetAllOpenSportFieldProposals();
        }

        public Task<SportFieldProposalType> AddSportFieldProposal(SportFieldProposalDto sportFieldProposalToAdd)
        {
            var newSportFieldProposal = new SportFieldProposalType()
            {
                Date = DateTime.Now,
                UserId = Guid.Empty, //TODO: Replace with userID
                SportFieldName = sportFieldProposalToAdd.SportFieldName,
                SportFieldDescription = sportFieldProposalToAdd.SportFieldDescription,
                SportFieldLongitude = sportFieldProposalToAdd.SportFieldLongitude,
                SportFieldLatitude = sportFieldProposalToAdd.SportFieldLatitude,
                SportFieldAddress = sportFieldProposalToAdd.SportFieldAddress,
                State = SportFieldProposalStates.Open
            };

            return _repository.AddSportFieldProposal(newSportFieldProposal);
        }

        public async Task<SportFieldProposalType> GetSportFieldProposalById(Guid sportFieldProposalId)
        {
            if (sportFieldProposalId == Guid.Empty)
            {
                throw new ArgumentException("Guid must no be null");
            }
            var sportFieldProposal = await _repository.GetSportFieldProposalById(sportFieldProposalId);

            if (sportFieldProposal == null)
            {
                throw new NoSportFieldFoundException(sportFieldProposalId);
            }
            return sportFieldProposal;
        }

        public async Task<SportFieldProposalType> ChangeStateById(Guid sportFieldProposalId, SportFieldProposalStates newState)
        {
            if (sportFieldProposalId == Guid.Empty)
            {
                throw new ArgumentException("Guid must no be null");
            }
            var sportFieldProposal = await _repository.ChangeStateById(sportFieldProposalId,newState);

            if (sportFieldProposal == null)
            {
                throw new NoSportFieldFoundException(sportFieldProposalId);
            }
            return sportFieldProposal;
        }
    }
}