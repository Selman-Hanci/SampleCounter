using System.ComponentModel.DataAnnotations;
using FluentValidation;
using SampleDomain.Exceptions;
using SampleDomain.Models;

namespace SampleAPI.Validators
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(client => client.Description).NotNull().NotEqual("Empty");
            RuleFor(client => client.Counter).GreaterThanOrEqualTo(1);
        }

        public void ValidateModel(Client client)
        {
            FluentValidation.Results.ValidationResult validationResult = Validate(client);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException($"Parameters are in wrong format, errors are as following " +
                    $"{validationResult.ToString()}");
            }
        }
    }
}

