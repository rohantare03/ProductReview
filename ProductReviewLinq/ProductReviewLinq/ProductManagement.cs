using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewLinq
{
    public class ProductManagement
    {
        List<ProductReview> ProductReviewsList = new List<ProductReview>();

        ///<summary>
        ///UC1 : Create product review class with 25 default values
        ///</summary>
        public int AddProductList()
        {
            ProductReviewsList.Add(new ProductReview() { ProductID = 1, UserID = 1, Rating = 1, Review = "good", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 1, UserID = 1, Rating = 1, Review = "good", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 3, UserID = 2, Rating = 1, Review = "good", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 4, UserID = 2, Rating = 2, Review = "bad", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 5, UserID = 3, Rating = 2, Review = "bad", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 5, UserID = 3, Rating = 2, Review = "good", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 7, UserID = 4, Rating = 3, Review = "bad", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 7, UserID = 4, Rating = 3, Review = "good", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 9, UserID = 5, Rating = 3, Review = "bad", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 10, UserID = 5, Rating = 4, Review = "good", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 10, UserID = 6, Rating = 4, Review = "nice", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 10, UserID = 6, Rating = 4, Review = "bad", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 10, UserID = 7, Rating = 5, Review = "good", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 1, UserID = 7, Rating = 5, Review = "nice", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 4, UserID = 8, Rating = 5, Review = "good", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 16, UserID = 8, Rating = 1, Review = "good", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 18, UserID = 9, Rating = 1, Review = "good", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 18, UserID = 9, Rating = 1, Review = "very bad", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 19, UserID = 10, Rating = 2, Review = "bad", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 20, UserID = 10, Rating = 3, Review = "good", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 21, UserID = 11, Rating = 2, Review = "average", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 9, UserID = 11, Rating = 5, Review = "bad", IsLike = false });
            ProductReviewsList.Add(new ProductReview() { ProductID = 25, UserID = 12, Rating = 3, Review = "good", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 25, UserID = 12, Rating = 3, Review = "average", IsLike = true });
            ProductReviewsList.Add(new ProductReview() { ProductID = 25, UserID = 12, Rating = 4, Review = "average", IsLike = true });
            return ProductReviewsList.Count;
        }
        public void DisplayProductReviewList()
        {
            foreach (var product in ProductReviewsList)
            {
                Console.WriteLine("Product ID :" + product.ProductID);
                Console.WriteLine("User ID :" + product.UserID);
                Console.WriteLine("Rating :" + product.Rating);
                Console.WriteLine("Review :" + product.Review);
                Console.WriteLine("Liked :" + product.IsLike);
            }
        }
        //<summary>
        //UC2 : Top 3 Records
        //</summary>
        public int RetrieveTop3ByRating()
        {
            AddProductList();
            var res = (from product in ProductReviewsList orderby product.Rating descending select product).Take(3).ToList();
            DisplayProductReviewList();
            return res.Count;
        }
        //<summary>
        //UC3 : Greater than 3
        //</summary>
        public string RetrieveAllByRatingAndProductID()
        {
            AddProductList();
            string productsList = "";
            var productList = (from product in ProductReviewsList where product.Rating > 3 && (product.ProductID == 1 || product.ProductID == 4 || product.ProductID == 9) select product);
            foreach (var product in productList)
            {
                productsList += product.UserID + " ";
                Console.WriteLine("Product ID :" + product.ProductID);
                Console.WriteLine("User ID :" + product.UserID);
                Console.WriteLine("Rating :" + product.Rating);
                Console.WriteLine("Review :" + product.Review);
                Console.WriteLine("Liked :" + product.IsLike);
            }
            return productsList;
        }
        //<summary>
        //UC4 : Review Present
        //</summary>
        public string RetrieveReviewCountForProductId()
        {
            string productsList = "";
            AddProductList();
            var productList = ProductReviewsList.GroupBy(x => x.ProductID).Select(a => new { ProductID = a.Key, count = a.Count() });
            foreach (var element in productList)
            {
                Console.WriteLine("ProductID " + element.ProductID + " " + "Count " + " " + element.count);
                productsList += element.count + " ";
            }
            return productsList;
        }
        //<summary>
        //UC5 : ProductID and review
        //</summary>
        public string RetrieveProductIdAndReview()
        {
            string result = "";
            AddProductList();
            var productList = ProductReviewsList.Select(product => new { ProductID = product.ProductID, Review = product.Review }).ToList();
            foreach (var element in productList)
            {
                Console.WriteLine("ProductId: " + element.ProductID + "\tReview: " + element.Review);
                result += element.ProductID + " ";
            }
            return result;
        }
        //<summary>
        //UC6 : Skip first 5 parameter from the list
        //</summary>
        public string RetrieveProductReviewSkippingTop5()
        {
            string productsList = "";
            AddProductList();
            var result = (from product in ProductReviewsList orderby product.Rating descending select product).Skip(5).ToList();
            foreach (var element in result)
            {
                productsList += element.ProductID + " ";
            }
            return productsList;
        }
    }
}
