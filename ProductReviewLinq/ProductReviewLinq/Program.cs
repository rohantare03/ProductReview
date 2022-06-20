namespace ProductReviewLinq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Product Review Management");
            ProductManagement productManagement = new ProductManagement();
            productManagement.AddProductList();
            productManagement.DisplayProductReviewList();
        }
    }
}