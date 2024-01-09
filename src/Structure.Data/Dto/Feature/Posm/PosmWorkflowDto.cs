

namespace Structure.Data.Dto
{
    public class PosmWorkflowDto
    {


        public Guid? Id { get; set; }

        public string? title { get; set; }

        public int? created_by { get; set; }

        public DateTime? created_at { get; set; }


        public ClientDto? Client { get; set; }

        public Guid? ClientId { get; set; }
    }
}
