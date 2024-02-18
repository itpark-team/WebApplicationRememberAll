using FluentValidation;
using WebApplicationRememberAll.Dtos;

namespace WebApplicationRememberAll.Validators;

public class SlavesAddNewRequestDtoValidator : AbstractValidator<SlavesAddNewRequestDto>
{
    public SlavesAddNewRequestDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name.Length).InclusiveBetween(2, 200);

        RuleFor(x => x.Age).InclusiveBetween(18, 65);

        RuleFor(x => x.CountryOfOrigin).NotEmpty();
        RuleFor(x => x.CountryOfOrigin.Length).InclusiveBetween(3, 200);

        RuleFor(x => x.Gender).InclusiveBetween(0, 1);
    }
}