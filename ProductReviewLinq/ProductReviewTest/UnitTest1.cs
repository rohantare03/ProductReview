using NUnit.Framework;
using ProductReviewLinq;
using System.Collections.Generic;

namespace ProductReviewTest
{
    public class Tests
    {
        List<ProductReview> ProductReviewsList;
        ProductManagement products;
        [SetUp]
        public void Setup()
        {
            products = new ProductManagement();
            ProductReviewsList = new List<ProductReview>();
        }
        //<summary>
        //UC1 : Add List
        //</summary>
        [Test]
        public void GivenFunction_returnCountofListCreated()
        {
            int expected = 25;
            int actual = products.AddProductList();
            Assert.AreEqual(expected, actual);
        }
        //<summary>
        //UC2 : Retrieve
        //</summary>
        [Test]
        public void RetrieveTop3_byRating_FromList()
        {
            int expected = 3;
            var actual = products.RetrieveTop3ByRating();
            Assert.AreEqual(expected, actual);
        }
        //<summary>
        //TC 3 : Retrive All Data by ratings and Product id
        //</summary>
        [Test]
        public void TestMethodForRetrieveRecordsBasedOnRatingAndProductId()
        {
            string expected = "7 8 11 ";
            string actual = products.RetrieveAllByRatingAndProductID();
            Assert.AreEqual(expected, actual);
        }
        //<summary>
        //TC4 : Retrieve Review count for each product id 
        //</sumamry>
        [Test]
        public void RetrieveCountOfReviewForEachProduct()
        {
            string expected = "3 1 2 2 2 2 4 1 2 1 1 1 3 ";
            string actual = products.RetrieveReviewCountForProductId();
            Assert.AreEqual(expected, actual);
        }
        //<summary>
        //TC 5: Retrieve only product id and review
        //</summary>
        [Test]
        public void RetrieveOnlyProductIDAndReview()
        {
            string expected = "1 1 3 4 5 5 7 7 9 10 10 10 10 1 4 16 18 18 19 20 21 9 25 25 25 ";
            string actual = products.RetrieveProductIdAndReview();
            Assert.AreEqual(expected, actual);
        }
        //<summary>
        //TC 6: Skip 5 Records
        //</summary>
        [Test]
        public void Skipping_Top5_Records()
        {
            string expected = "10 10 25 7 7 9 20 25 25 4 5 5 19 21 1 1 3 16 18 18 ";
            string actual = products.RetrieveProductReviewSkippingTop5();
            Assert.AreEqual(expected, actual);
        }
        //<summary>
        //TC 8: Add Review to Data Table
        //</summary>
        [Test]
        public void GivenFunctionforDT_returnCountofListCreated()
        {
            int expected = 25;
            int actual = products.CreateDataTable();
            Assert.AreEqual(expected, actual);
        }
    }
}