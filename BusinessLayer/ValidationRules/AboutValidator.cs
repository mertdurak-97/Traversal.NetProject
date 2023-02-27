using EntityLayer;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmını boş geçemezseniz !");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Görsel Seçiniz !");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Açıklama En az 50 Karakterde Olmalı !");
            RuleFor(x => x.Description).MaximumLength(1500).WithMessage("Upps! Fazla Karakter Kullanımı");
        }
    }
}
