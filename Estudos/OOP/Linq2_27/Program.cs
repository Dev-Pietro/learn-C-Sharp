﻿using System;
using System.Collections.Generic;
using System.Linq;
using Linq2_27.Entities;

namespace Linq2_27
{
    class Program
    {
        static void Print<T>(string message, IEnumerable<T> list) {
            Console.WriteLine(message);
            foreach(T obj in list) {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Category c1 = new Category() {Id = 1, Name = "Tools", Tier = 2};
            Category c2 = new Category() {Id = 2, Name = "Computers", Tier = 1};
            Category c3 = new Category() {Id = 3, Name = "Eletronics", Tier = 1};

            List<Product> products = new List<Product>() {
                new Product() {Id = 1, Name = "Computer", Price = 1100, Category = c2},
                new Product() {Id = 2, Name = "Hammer", Price = 90, Category = c1},
                new Product() {Id = 3, Name = "TV", Price = 1700, Category = c3},
                new Product() {Id = 4, Name = "Notebook", Price = 1300, Category = c2},
                new Product() {Id = 5, Name = "Saw", Price = 80, Category = c1},
                new Product() {Id = 6, Name = "Tablet", Price = 700, Category = c2},
                new Product() {Id = 7, Name = "Camera", Price = 700, Category = c3},
                new Product() {Id = 8, Name = "Printer", Price = 350, Category = c3},
                new Product() {Id = 9, Name = "MacBook", Price = 1800, Category = c2},
                new Product() {Id = 10, Name = "Sound Bar", Price = 700, Category = c3},
                new Product() {Id = 11, Name = "Level", Price = 70, Category = c1}
            };

            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900);
            Print("TIER 1 AND PRICE < 900", r1);

            var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            Print("NAME OF PRODUCTS FROM TOOLS", r2);

            var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new {p.Name, p.Price, CategoryName = p.Category.Name});
            Print("NAMES STARTED WITH C AND ANONYMOUS OBJECT", r3);

            var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME", r4);

            var r5 = r4.Skip(2).Take(4);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4", r5);
            
            var r6 = products.FirstOrDefault();
            Console.WriteLine("First test 1: " + r6);
            var r7 = products.Where(p => p.Price > 3000).FirstOrDefault();
            Console.WriteLine("First test 2: " + r7);

            Console.WriteLine("");

            var r8 = products.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine("Single or Default test 1: " + r8);

            Console.WriteLine("");

            var r9 = products.Max(p => p.Price);
            Console.WriteLine("Max Price: " + r9);
            var r10 = products.Min(p => p.Price);
            Console.WriteLine("Min Price: " + r10);
            var r11 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine("Category 1 Sum prices: " + r11);
            var r12 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
            Console.WriteLine("Category 1 Average prices: " + r12);
            var r13 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate((x, y) => x + y);
            Console.WriteLine("Category 1 Aggregate Sum: " + r13);
            Console.WriteLine("");

            var r14 = products.GroupBy(p => p.Category);
            foreach(IGrouping<Category, Product> group in r14) {
                Console.WriteLine("Category: " + group.Key.Name);
                foreach(Product p in group) {
                    Console.WriteLine(p);
                }
            }
            
        }
    }
}