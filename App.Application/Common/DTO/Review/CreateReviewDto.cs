namespace App.Application.Common.DTO.Review;

public class CreateReviewDto
{
    public string Name { get; set; }
    public Guid ClientId { get; set; }
    public Guid WorkerId { get; set; }
    public int Stars { get; set; }
}