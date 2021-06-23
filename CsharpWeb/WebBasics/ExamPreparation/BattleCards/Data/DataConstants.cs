namespace BattleCards.Data
{
    public class DataConstants
    {
        public const int IdMaxLength = 40;

        public const int DefaultMinLength = 5;
        public const int DefaultMaxLength = 20;

        public const int UserPasswordMinLength = 5;
        public const int UserPasswordMaxLength = 20;
        public const string UserEmailValidator = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public const int CardNameMaxLength = 15;
        public const int CardDefaultMinStat = 0;
        public const int CardDescriptionMaxLength = 200;

    }
}
