namespace Structure.Data
{
    public class Page : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public List<Action> Actions { get; set; }
    }
}
