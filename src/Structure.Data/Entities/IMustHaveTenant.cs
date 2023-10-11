namespace Structure.Data
{
    public interface IMustHaveTenant
    {
        public Guid? TenantId { get; set; }
    }
}
