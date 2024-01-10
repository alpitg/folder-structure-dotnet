

namespace Structure.Data.Dto
{
    public class PosmWorkflowManufacturingDetailsDto
    {

        public Guid? Id { get; set; }

        public  PosmWorkflowDto? PosmWorkFlow { get; set; }

        public Guid? PosmWorkFlowId { get; set; }

        public string? ManufacturingCompany { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Comments { get; set; }

    }
}
