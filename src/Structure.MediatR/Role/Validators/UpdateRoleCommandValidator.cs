﻿using Structure.MediatR.CommandAndQuery;
using FluentValidation;

namespace Structure.MediatR.Validators
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Role Id is required.");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Role Name is required.");
        }
    }
}
