using System;
namespace Structure.Data
{
	public class Gender : BaseEntity
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? DisplayName { get; set; }

    }
}

