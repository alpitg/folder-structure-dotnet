

namespace Structure.Data
{
    public class PosmWorkFlow : BaseEntity
    {

        public Guid? Id { get; set; }

        public string? Title { get; set; }

        public int Created_by { get; set; } 

        public DateTime Created_at { get; set; }    


        public Client? Client { get; set; }

        public Guid? ClientId { get; set; }

    }
}
