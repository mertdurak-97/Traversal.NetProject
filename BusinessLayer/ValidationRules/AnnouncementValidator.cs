using CoreLayer.DTOs.AnnouncementDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddDTO>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık kısmını boş geçemezseniz !");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Açıklama kısmını boş geçemezseniz !");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık En az 5 Karakterden Fazla Olmalı !");
            RuleFor(x => x.Content).MinimumLength(5).WithMessage("Açıklama En az 5 Karakterden Fazla Olmalı !");
            RuleFor(x => x.Title).MaximumLength(1500).WithMessage("Upps! Fazla Karakter Kullanımı");
            RuleFor(x => x.Content).MaximumLength(1500).WithMessage("Upps! Fazla Karakter Kullanımı");
        }
    }
}
