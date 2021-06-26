namespace SharedTrip.Data
{
    public class DataConstants
    {
        public const int IdMaxLength = 40;
        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;

        public const int UserMinPassword = 6;
        public const int UserMaxPassword = 20;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const int TripDescriptionMaxLength = 80;
        public const int TripSeatsMin = 2;
        public const int TripSeatsMax = 6;
    }
}
