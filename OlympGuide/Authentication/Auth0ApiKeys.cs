using OlympGuide.Domain.Features.User;

namespace OlympGuide.Authentication
{
    public static class Auth0ApiKeys
    {
        public static Dictionary<string, UserRole> PermissionMap = new Dictionary<string, UserRole>
        {
            { "access:admin", UserRole.Administrator },
            { "access:user", UserRole.DefaultUser }
        };

        public static List<string> UserInformationKeys = new List<string> { "sub", "name", "nickname", "email" };

        public static string UserIdentifierKey = "sub";
        public static string NameKey = "name";
        public static string DisplayNameKey = "nickname";
        public static string EmailKey = "email";
    }
}
