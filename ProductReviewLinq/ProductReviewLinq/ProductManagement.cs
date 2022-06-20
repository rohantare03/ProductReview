using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewLinq
{
    public class ProductManagement
    {
        List<ProductReview> ProductReviewsList = new List<ProductReview>();
        DataTable productdt = new DataTable();

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
        // <summary>
        /// UC 8 :Creates the data table of product review.
        /// </summary>
        public int CreateDataTable()
        {
            AddProductList();
            productdt = new DataTable();
            productdt.Columns.Add("ProductId", typeof(Int32));
            productdt.Columns.Add("UserId", typeof(Int32));
            productdt.Columns.Add("Rating", typeof(Int32));
            productdt.Columns.Add("Review", typeof(string));
            productdt.Columns.Add("IsLike", typeof(bool));

            foreach (var data in ProductReviewsList)
            {
                productdt.Rows.Add(data.ProductID, data.UserID, data.Rating, data.Review, data.IsLike);
            }
            return productdt.Rows.Count;
        }
        /// <summary>
        ///UC9: Retrieves the record with likes.
        /// </summary>
        public string RetrievedetailsWithLikes()
        {
            List<ProductReview> ProductReviewsList = new List<ProductReview>();
            CreateDataTable();
            string productsList = "";
            var res = from product in productdt.AsEnumerable() where product.Field<bool>("IsLike") == true select product;
            foreach (var products in res)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} ", products["ProductId"], products["UserId"], products["Rating"], products["Review"], products["IsLike"]);
                productsList += products["UserId"] + " ";
            }
            return productsList;
        }
        //<summary>
        //UC10 : Average rating
        //</summary>
        public string RetrieveAverageRating()
        {
            string result = "";
            CreateDataTable();
            var res = from product in productdt.AsEnumerable() group product by product.Field<int>("ProductId") into temp select new { productid = temp.Key, Average = Math.Round(temp.Average(x => x.Field<int>("Rating")), 1) };
            foreach (var product in res)
            {
                Console.WriteLine("Product id: {0} Average Rating: {1}", product.productid, product.Average);
                result += product.Average + " ";
            }
            return result;
        }
        //<summary>
        //UC11 : Retrieve nice reviews
        //</summary>
        public string RetrieveAllNiceReviews()
        {
            CreateDataTable();
            List<ProductReview> ProductReviewsList = new List<ProductReview>();

            string productsList = "";
            var res = from product in productdt.AsEnumerable() where product.Field<string>("Review") == "nice" select product;
            foreach (var products in res)
            {
                Console.WriteLine("{0} ; {1} ; {2} ; {3} ; {4} ", products["ProductId"], products["UserId"], products["Rating"], products["Review"], products["IsLike"]);
                productsList += products["UserId"] + " ";
            }
            return productsList;
        }
        /// <summary>
        /// UC 12: Retrieves all product reviews by user identifier and order by rating.
        /// </summary>
        public string RetrieveAllProductReviews_ByUserIDAndOrderByRating()
        {
            CreateDataTable();
            string productsList = "";
            var res = (from product in productdt.AsEnumerable() where product.Field<Int32>("UserId") == 10 orderby product.Field<int>("Rating") select product).ToList();
            foreach (var products in res)
            {
                Console.WriteLine("{0} ; {1} ; {2} ; {3} ; {4} ", products["ProductId"], products["UserId"], products["Rating"], products["Review"], products["IsLike"]);
                productsList += products["Rating"] + " ";
            }
            return productsList;
        }
    }
}
