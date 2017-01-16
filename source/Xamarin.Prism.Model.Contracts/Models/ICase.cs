namespace Xamarin.Prism.Model.Contracts.Models
{
    public interface ICase
    {
        string Id { get; set; }
        string CaseNumber { get; set; }
        string Origin { get; set; }
        string OwnerId { get; set; }
        string Reason { get; set; }
        string Description { get; set; }
        string Priority { get; set; }
        string Status { get; set; }
        string Subject { get; set; }
    }
}
