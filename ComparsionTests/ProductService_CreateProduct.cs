using System;
using TariffComparison.Services;
using Xunit;


namespace TariffComparison.ComparsionTests
{
    public class ProductService_CreateProduct
    {
        public ProductService service { get; set; } = new ProductService("../../../../TariffComparison/products.json");

        [Fact]
        public void Return_FirstProduct_830AnnualCost()
        {
            var product = service.CreateProduct(0, 3500);
            Assert.Equal(830, product.AnnualCosts);
        }

        [Fact]
        public void Return_FirstProduct_1050AnnualCost()
        {
            var product = service.CreateProduct(0, 4500);
            Assert.Equal(1050, product.AnnualCosts);
        }

        [Fact]
        public void Return_FirstProduct_1380AnnualCost()
        {
            var product = service.CreateProduct(0, 6000);
            Assert.Equal(1380, product.AnnualCosts);
        }

        [Fact]
        public void Return_SecondProduct_800AnnualCost()
        {
            var product = service.CreateProduct(1, 3500);
            Assert.Equal(800, product.AnnualCosts);
        }

        [Fact]
        public void Return_SecondProduct_950AnnualCost()
        {
            var product = service.CreateProduct(1, 4500);
            Assert.Equal(950, product.AnnualCosts);
        }

        [Fact]
        public void Return_SecondProduct_1400AnnualCost()
        {
            var product = service.CreateProduct(1, 6000);
            Assert.Equal(1400, product.AnnualCosts);
        }
    }


}
