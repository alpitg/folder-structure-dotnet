

namespace Structure.Data
{
    public class PosmWorkflowTransitDetails : BaseEntity
    {

        public Guid? Id { get; set; }

        public PosmWorkflowTransition? PosmWorkflowTransition { get; set; }  

        public Guid? PosmWorkflowTransitionId { get; set; }

        public int? Quantity { get; set; }

        public DateTime? TransitionDate { get; set; }

        public string? TransporterName { get; set; }

        public string? SourceCityName { get; set; }

        public string? DestinationCityName { get; set; }

        public string? VehicaleNumber { get; set; }

        public string? CourierNumber { get; set; }

        public string? RFTD { get; set; }

        public string? TransporterContactNumber { get; set; }   

        public string? Route { get; set; }

        public DateTime? ExpectedDeliveryDate { get; set; }

        public string? Comments { get; set; }   

    }
}
