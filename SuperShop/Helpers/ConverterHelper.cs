﻿using SuperShop.Data.Entities;
using SuperShop.Models;
using System;
using System.IO;

namespace SuperShop.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Product ToProduct(ProductViewModel model, Guid imageId, bool isNew)
        {
            return new Product
            {
                Id = isNew ? 0 : model.Id,
                ImageId = imageId,
                IsAvailable = model.IsAvailable,
                LastPurchased = model.LastPurchased,
                LastSale = model.LastSale,
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
                User = model.User,
            };
        }

        public ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                ImageId = product.ImageId,
                IsAvailable = product.IsAvailable,
                LastPurchased = product.LastPurchased,
                LastSale = product.LastSale,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                User = product.User,
            };
        }
    }
}
