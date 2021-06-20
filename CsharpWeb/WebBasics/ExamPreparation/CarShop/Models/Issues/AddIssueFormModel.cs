namespace CarShop.Models.Issues
{
    public class AddIssueFormModel
    {
        public string Id { get; init; }
        public string Description { get; init; }

        public string CarId { get; set; }

        public bool IsFixed { get; init; } = false;
    }
}
