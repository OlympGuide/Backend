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

        public static List<string> UserInformationKeys = new List<string> { "given_name", "family_name", "nickname", "email" };

        public static string SurnameKey = "given_name";
        public static string LastnameKey = "family_name";
        public static string DisplayNameKey = "nickname";
        public static string EmailKey = "email";

    }
}
