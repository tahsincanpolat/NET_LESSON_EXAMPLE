using _11_FluentValidation.ViewModels;
using FluentValidation;

namespace _11_FluentValidation.Validators
{
    public class homePageViewModelValidator : AbstractValidator<HomePageViewModel>
    {
        public homePageViewModelValidator()
        {
            RuleFor(vm => vm.KisiNesnesi).NotNull().WithMessage("Kişi bilgileri boş olamaz");
            RuleFor(vm => vm.AdresNesnesi).NotNull().WithMessage("Adres bilgileri boş olamaz");

            RuleFor(vm => vm.KisiNesnesi.Ad)
                .NotEmpty().WithMessage("Ad Alanı Boş olamaz")
                .Length(1, 50).WithMessage("Ad alanı 1 ile 50 karakter arasında olmalıdır.");
            
            RuleFor(vm => vm.KisiNesnesi.Soyad)
               .NotEmpty().WithMessage("Soyad Alanı Boş olamaz")
               .Length(1, 50).WithMessage("Soyad alanı 1 ile 50 karakter arasında olmalıdır.");

            RuleFor(vm => vm.KisiNesnesi.Yas)
              .NotEmpty().WithMessage("Yaş Alanı Boş olamaz")
               .GreaterThan(0).WithMessage("Yaş 0'dan büyük olmalıdır")
              .LessThan(120).WithMessage("Yaş 120'den küçük olmalıdır");

            RuleFor(vm => vm.AdresNesnesi.AdresTanim)
             .NotEmpty().WithMessage("Adres tanım Alanı Boş olamaz")
             .Length(1, 100).WithMessage("Adres tanım alanı 1 ile 100 karakter arasında olmalıdır.");

            RuleFor(vm => vm.AdresNesnesi.Sehir)
            .NotEmpty().WithMessage("Şehir Alanı Boş olamaz")
            .Length(1, 50).WithMessage("Şehir alanı 1 ile 50 karakter arasında olmalıdır.");
        }

    }
}
