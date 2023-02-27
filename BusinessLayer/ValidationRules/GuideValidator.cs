using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Rehber adını boş geçemezseniz !");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Rehber açıklamasını giriniz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Rehberin resimi olmalı");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Upps! 50'den Fazla Karakter Kullanımı");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Upps! 2'den Az Karakter Kullanımı");
        }
    }
}
