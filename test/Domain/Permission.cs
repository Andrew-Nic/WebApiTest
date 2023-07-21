namespace CQRStest.Domain
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public HashSet<User> Users { get; set; } = new HashSet<User>();
        public HashSet<Module> Modules { get; set; } = new HashSet<Module>();
    }
}
