using System;
using System.Collections.Generic;
using System.Linq;

namespace _28._10._26
{
    public sealed class ReportService
    {
        private readonly List<Category> _categories;
        private readonly List<Product> _products;
        private readonly List<Sale> _sales;

        public ReportService(
            List<Category> categories,
            List<Product> products,
            List<Sale> sales)
        {
            _categories = categories;
            _products = products;
            _sales = sales;
        }

        // 1. Поиск товаров по названию
        public List<Product> SearchProducts(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return _products.ToList();

            return _products
                .Where(p => p.Name.IndexOf(
                    searchText,
                    StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        // 2. Фильтрация товаров по категории
        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _products
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }

        // 3. Товары, которых осталось мало
        public List<Product> GetLowStockProducts(int limit)
        {
            return _products
                .Where(p => p.Stock <= limit)
                .OrderBy(p => p.Stock)
                .ToList();
        }

        // 4. Товары с учетом скидки категории
        public List<CategoryProductsDto> GetProductsWithDiscount()
        {
            var query =
                from product in _products
                join category in _categories
                    on product.CategoryId equals category.Id
                select new CategoryProductsDto
                {
                    CategoryName = category.Name,
                    ProductName = product.Name,
                    Price = product.Price,
                    DiscountRate = category.DiscountRate,
                    FinalPrice = product.Price *
                        (1 - category.DiscountRate)
                };

            return query.ToList();
        }

        // 5. Сводка по категориям
        public List<CategorySummaryDto> GetCategorySummary()
        {
            var query =
                from category in _categories
                join product in _products
                    on category.Id equals product.CategoryId
                    into categoryProducts
                select new CategorySummaryDto
                {
                    CategoryName = category.Name,
                    ProductCount = categoryProducts.Count(),
                    TotalStock = categoryProducts.Sum(p => p.Stock),
                    AveragePrice = categoryProducts.Any()
                        ? categoryProducts.Average(p => p.Price)
                        : 0
                };

            return query.ToList();
        }

        // 6. Отчет по продажам
        public List<SaleReportDto> GetSalesReport()
        {
            var query =
                from sale in _sales
                join product in _products
                    on sale.ProductId equals product.Id
                join category in _categories
                    on product.CategoryId equals category.Id
                select new SaleReportDto
                {
                    SaleId = sale.Id,
                    ProductName = product.Name,
                    CategoryName = category.Name,
                    CustomerName = sale.CustomerName,
                    Quantity = sale.Quantity,
                    SaleDate = sale.SaleDate,
                    Channel = sale.Channel,
                    Total = sale.Quantity * product.Price
                };

            return query
                .OrderByDescending(s => s.SaleDate)
                .ToList();
        }

        // 7. Выручка по каналам продаж
        public List<ProductChannelDto> GetRevenueByChannel()
        {
            var query =
                from sale in _sales
                join product in _products
                    on sale.ProductId equals product.Id
                group new { sale, product } by sale.Channel
                into channelGroup
                select new ProductChannelDto
                {
                    Channel = channelGroup.Key,
                    TotalQuantity = channelGroup.Sum(
                        x => x.sale.Quantity),
                    TotalRevenue = channelGroup.Sum(
                        x => x.sale.Quantity * x.product.Price)
                };

            return query.ToList();
        }
    }
}
