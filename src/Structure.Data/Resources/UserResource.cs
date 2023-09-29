namespace Structure.Data.Resources
{
    public class UserResource : ResourceParameter
    {
        public UserResource() : base("Email")
        {
        }

        public Guid? TenantId { get; set; }
        public string? Name { get; set; }
    }
}
