using FluentValidation;
using Karta.Model;

namespace RPP_WebApp.ModelsValidation
{
	public class DogadajValidator : AbstractValidator<Dogadaj>
	{
		public DogadajValidator()
		{
			RuleFor(d => d.VrijemeDogadaja)
			  .NotEmpty().WithMessage("Vrijeme događaja je obvezno polje");


			RuleFor(d => d.IdDionica)
			  .NotEmpty().WithMessage("Id dionice je obvezno polje");


			RuleFor(d => d.MeteoroloskiUvjeti)
			  .NotEmpty().WithMessage("Meteorološki uvjeti događaja je obvezno polje")
			.MaximumLength(100).WithMessage("Opis meteoroloških uvjeta može sadržavati maksimalno 100 znakova");

			RuleFor(d => d.OpisDogadaja)
			  .NotEmpty().WithMessage("Opis događaja je obvezno polje")
			.MaximumLength(100).WithMessage("Opis događaja može sadržavati maksimalno 100 znakova");
		}
	}
}
