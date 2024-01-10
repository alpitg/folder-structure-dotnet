

namespace Structure.Data
{
    public class PosmStatus : BaseEntity
    {

        public Guid Id { get; set; }    

        public string? StatusCode { get; set; } 

        public string? StatusDescription { get; set; }

    }
}
