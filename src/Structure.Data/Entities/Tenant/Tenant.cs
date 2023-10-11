
namespace Structure.Data
{

    public class Tenant : BaseEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ConnectionString { get; set; }
    }
}
