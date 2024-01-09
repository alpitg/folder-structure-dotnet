
namespace Structure.Data.Dto
{
    public class UsersDto
    {

        public Guid Id { get; set; }

        public string? userName { get; set; }

        public ClientDto? client { get; set; }

        public Guid? clientId { get; set; }

    }
}
