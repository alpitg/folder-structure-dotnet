using FluentValidation;
using Structure.MediatR.CommandAndQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.MediatR.FacilityCourts.validatore
{
    public class AddFacilityCourtCommandValidatore :AbstractValidator<AddFacilityCourtsCommands>
    {

        //public AddFacilityCourtsCommands()
        //{
        //    RuleFor(c => c.).NotEmpty().WithMessage("Name is required");
        //}

    }
}
