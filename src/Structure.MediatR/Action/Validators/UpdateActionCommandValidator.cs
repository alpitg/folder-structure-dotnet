﻿using Structure.MediatR.CommandAndQuery;
using FluentValidation;
using System;

namespace Structure.MediatR.Validators
{
    public class UpdateActionCommandValidator : AbstractValidator<UpdateActionCommand>
    {
        public UpdateActionCommandValidator()
        {
            RuleFor(c => c.Id).Must(NotEmptyGuid).WithMessage("Id is required");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required");
        }

        private bool NotEmptyGuid(Guid p)
        {
            return p != Guid.Empty;
        }
    }
}
