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
    }
}