namespace hrms.hrms.Models
{
    public static class HardcodedUsers
    {
        public static User AdminUser = new User
        {
            Username = "admin",
            Password = "000000"  // In a real application, use a hashed password
        };
    }

}
