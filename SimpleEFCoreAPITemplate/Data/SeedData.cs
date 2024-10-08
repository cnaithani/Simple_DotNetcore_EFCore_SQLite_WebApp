﻿using SimpleEFCoreAPITemplate.Models;

namespace SimpleEFCoreAPITemplate.Data
{
    public static class SeedData
    {
        public static void Initialize(DBCtx db)
        {
            var products = new Product[]
            {
                new Product {
                    Name = "Apple IPhone",
                    Description = "Apple IPhone",
                    BasePrice = 500.50m,
                },
                new Product {
                    Name = "Samsung Galaxy M",
                    Description = "Samsung Galaxy M Series",
                    BasePrice = 100.00m,
                },
                new Product {
                    Name = "Samsung Galaxy S",
                    Description = "Samsung Galaxy S Series",
                    BasePrice = 400.00m,
                },
                new Product {
                    Name = "Google Pixel",
                    Description = "Google Pixel",
                    BasePrice = 500.25m,
                }
            };

            var productDetails = new ProductDetail[]
           {
                new ProductDetail {
                    ProductId = 1,
                    Length = 12.0m,
                    Width = 50.0m,
                    Height = 21.0m
                },
                new ProductDetail {
                    ProductId = 2,
                    Length = 10.0m,
                    Width = 22.0m,
                    Height = 21.0m
                },
                new ProductDetail {
                    ProductId = 3,
                    Length = 11.0m,
                    Width = 30.0m,
                    Height = 12.0m
                },
                new ProductDetail {
                    ProductId = 4,
                    Length = 27.0m,
                    Width = 60.0m,
                    Height = 21.0m
                }
           };

            db.Products.AddRange(products);
            db.ProductDetails.AddRange(productDetails);
            db.SaveChanges();
        }
    }
}
