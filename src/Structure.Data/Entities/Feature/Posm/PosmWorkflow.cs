

namespace Structure.Data
{
    public class PosmWorkFlow : BaseEntity
    {

        public Guid? Id { get; set; }

        public string? title { get; set; }

        public int created_by { get; set; } 

        public DateTime created_at { get; set; }    


        public Client? Client { get; set; }

        public Guid? ClientId { get; set; }

    }
}
