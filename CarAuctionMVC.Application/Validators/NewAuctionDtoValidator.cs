using CarAuctionMVC.Application.Dtos;
using FluentValidation;

namespace CarAuctionMVC.Application.Validators
{
    public class NewAuctionDtoValidator : AbstractValidator<NewAuctionDto>
    {
        public NewAuctionDtoValidator()
        {
            RuleFor(a => a.AuctionTittle)
                .MaximumLength(100).WithMessage("Maksymalna liczba znaków to 100")
                .NotEmpty().WithMessage("Uzupełnij tytuł");

            RuleFor(a => a.CountryOfOrigin)
                .MaximumLength(100).WithMessage("Maksymalna liczba znaków to 20")
                .NotEmpty().WithMessage("Uzupełnij kraj pochodzenia");

            RuleFor(a => a.Price)
                .NotEmpty().WithMessage("Uzupełnij cenę");

            RuleFor(a => a.Model)
                .MaximumLength(30).WithMessage("Maksymalna liczba znaków to 30")
                .NotEmpty().WithMessage("Uzupełnij model");

            RuleFor(a => a.Brand)
                .MaximumLength(30).WithMessage("Maksymalna liczba znaków to 30")
                .NotEmpty().WithMessage("Uzupełnij markę");

            RuleFor(a => a.DateOfProduction)
                .NotEmpty().WithMessage("Uzupełnij datę");

            RuleFor(a => a.Mileage)
                .NotEmpty().WithMessage("Uzupełnij przebieg");

            RuleFor(a => a.Color)
                .NotEmpty().WithMessage("Uzupełnij kolor");
        }
    }
}
