
namespace Structure.Data.Dto
{
    public class ConfigurationSettings
    {
        public string AllowedHosts { get; set; }
        public JwtSettings JwtSettings { get; set; }
        public string AesEncryptionKey { get; set; }
        public string ReminderFromEmail { get; set; }
        public TenantSettings TenantSettings { get; set; }
    }

}
