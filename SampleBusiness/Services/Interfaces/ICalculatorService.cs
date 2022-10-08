using System;
namespace SampleBusiness.Services.Interfaces
{
    public interface ICalculatorService
    {
        Task<int> Increase(CancellationToken cancellationToken);
    }
}

