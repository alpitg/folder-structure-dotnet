

namespace Structure.Data.Dto
{
    public class PosmWorkflowDto
    {


        public Guid? Id { get; set; }

        public string? Title { get; set; }

        public int? Created_by { get; set; }

        public DateTime? Created_at { get; set; }


        public ClientDto? Client { get; set; }

        public Guid? ClientId { get; set; }
    }
}
