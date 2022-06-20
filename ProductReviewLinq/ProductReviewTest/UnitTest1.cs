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
    }
}