namespace EfAPI.Model.Product
{
    public class ProductReponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public DateTime? DateUpdated { get; set; } = DateTime.Now;
        public int IdCategory { get; set; }
    }
}
