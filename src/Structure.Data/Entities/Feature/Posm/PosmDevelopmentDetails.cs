

using Structure.Data.Dto;

namespace Structure.Data
{
    public class PosmDevelopmentDetails : BaseEntity
    {

        public Guid? Id { get; set; }   

        public PosmWorkflowTransitAssignmentDto? PosmWorkflowTransitAssignment { get; set; }

        public Guid? PosmWorkflowTransitAssignmentId { get; set; }

        public DateTime DeploymentDate { get; set; }

        public string? RetailerName { get; set; }   

        public string? RetailerGST { get; set; }

        public string? RetailerAddress1 { get; set; }   
        public string? RetailerAddress2 { get; set; }

        public string? RetailerCity { get; set; }   

        public string? RetailerPin { get; set; }

        public string? RetailerState { get; set; }  

        public string? RetailerLongitude { get; set; }   

        public string? RetailerLatitude { get; set; }   

    }
}
