using Entities.Models.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.FluentValidation;

public class ManagerValidator : AbstractValidator<Manager>
{
    public ManagerValidator()
    {
        RuleFor(m => m.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(m => m.LastName).NotEmpty().WithMessage("LastName is required");
        RuleFor(m => m.Email).EmailAddress().WithMessage("Invalid email format");
        RuleFor(m => m.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required")
                                     .Matches(@"^\d{10}$").WithMessage("Invalid phone number format"); // Örnek telefon numarası doğrulama
    }

    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(r => r.Description).NotEmpty().WithMessage("Description is required");
        }
    }

    public class ClaimValidator : AbstractValidator<Claim>
    {
        public ClaimValidator()
        {
            RuleFor(c => c.Type).NotEmpty().WithMessage("Type is required");
            RuleFor(c => c.Value).NotEmpty().WithMessage("Value is required");
        }
    }

    public class RoleClaimValidator : AbstractValidator<RoleClaim>
    {
        public RoleClaimValidator()
        {
            RuleFor(rc => rc.RoleId).NotEmpty().WithMessage("RoleId is required");
            RuleFor(rc => rc.ClaimId).NotEmpty().WithMessage("ClaimId is required");
        }
    }

}
