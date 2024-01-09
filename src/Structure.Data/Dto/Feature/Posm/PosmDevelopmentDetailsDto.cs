namespace Structure.Data.Dto
{
    public class PosmDevelopmentDetailsDto
    {

        public Guid? Id { get; set; }

        public PosmWorkflowTransitAssignment? posmWorkflowTransitAssignment { get; set; }

        public Guid? posmWorkflowTransitAssignmentId { get; set; }

        public DateTime? DeploymentDate { get; set; }

        public string? RetailerName { get; set; }

        public string? RetailerGST { get; set; }

        public string? RetailerAddress1 { get; set; }
        public string? RetailerAddress2 { get; set; }

        public string? RetailerCity { get; set; }

        public string? RetailerPin { get; set; }

        public string? RetailerState { get; set; }

        public string? RetailerLogitude { get; set; }

        public string? RetailerLatitude { get; set; }

    }
}
