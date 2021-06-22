namespace Git.Data
{
    public class DataConstants
    {
        public const int IdMaxLength = 40;

        public const int UserDefaultMaxLength = 20;
        public const int UsernameMinLength = 5;
        public const int UserPasswordMinLength = 6;
        public const string UserEmailValidator = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public const int RepositoryNameMinLength = 3;
        public const int RepositoryNameMaxLength = 10;
        public const string RepositoryPublicType = "Public";
        public const string RepositoryPrivateType = "Private";

        public const int CommitDescriptionMinLength = 5;
    }
}
