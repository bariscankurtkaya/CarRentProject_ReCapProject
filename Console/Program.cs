﻿//Written by : Barışcan KURTKAYA
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductsManager productsManager = new ProductsManager(new InMemoryProductsDal());

            foreach (var product in productsManager.GetAll())
            {
                string brandName = productsManager.GetProductBrand(product.BrandId);
                string colorName = productsManager.GetProductColor(product.ColorId);
                string sexName = productsManager.GetProductSex(product.SexId);
                string productType = productsManager.GetProductType(product.ProductTypeId);
                Console.WriteLine(
                    "{0}: Brand: {1}  --- Color: {2} --- Sex:{3}  --- Price:{4} --- Type: {5}"
                    , product.ProductId, brandName, colorName, sexName, product.Price, productType
                    );
            }

            Console.WriteLine("4'th products color: " + productsManager.GetProductColor(productsManager.GetById(4).ColorId));

            Products product1 = productsManager.GetById(6);
            Console.WriteLine("6'th products brand: " + productsManager.GetProductBrand(product1.BrandId));
        }
    }
}
