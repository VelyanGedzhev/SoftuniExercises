namespace CarShop.Data
{
    public class DataConstants
    {
        public const int IdMaxLength = 40;
        public const int DefaultMaxLength = 20;

        public const int CarModelMinLength = 5;
        public const int CarPlateNumberMaxLength = 8;
        public const string CarPlateNumberValidator = @"[A-Z]{2}[0-9]{4}[A-Z]{2}";
        public const int CarYearMinValue = 1886;
        public const int CarYearMaxValue = 2100;

        public const int UsernameMinLength = 4;
        public const int UserPasswordMinLength = 5;
        public const string UserTypeMechanic = "Mechanic";
        public const string UserTypeClient = "Client";
        public const string UserEmailValidator = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public const int IssueDescriptionMinLength = 5;
    }
}
