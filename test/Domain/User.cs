namespace CQRStest.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PublicAccess { get; set; }
        public string PasswordAccess { get; set; }
        public string SystemLanguage { get; set; }
        public int PermissionId { get; set; } //Rol
        public Permission Permission { get; set; }
    }
}
