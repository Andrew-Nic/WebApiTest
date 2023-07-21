namespace CQRStest.Domain
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<Permission> Permissions { get; set; } = new HashSet<Permission>();
    }
}
