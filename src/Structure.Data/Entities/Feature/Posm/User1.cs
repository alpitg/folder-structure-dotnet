

namespace Structure.Data
{
    public class User1 : BaseEntity
    {

        public Guid Id { get; set; }

        public string? userName { get; set; }       

        public Client? client { get; set; }  

        public Guid? clientId { get; set; }


    }
}
