namespace Expert.Core.Requests
{
    public class AddProductRequest
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string? Description { get; set; }
        public decimal Price { get; set; } = default!;
        public int CategoryId { get; set; }
    }
}
