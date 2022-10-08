using System;
using Microsoft.EntityFrameworkCore;
using SampleBusiness.Services.Interfaces;
using SampleDomain.Entities;
using SampleDomain.Exceptions;
using SampleInfrastructure.Persistence.Repositories;
using SampleInfrastructure.Persistence.Repositories.Interfaces;

namespace SampleBusiness.Services
{
    public class CalculatorService: ICalculatorService
    {
        private readonly INumberRepository _numberRepository;

        public CalculatorService(INumberRepository numberRepository)
        {
            _numberRepository = numberRepository;
        }

        public async Task<int> Increase(CancellationToken cancellationToken = default)
        {
            //var result = await _numberRepository.GetLastNumberAsync(cancellationToken);

            var result = new Number();
            result.Current = 1;

            var number = result != null ? result.Current : int.MinValue;

            return number;
        }
    }
}

