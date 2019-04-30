using System;
using App.Domain.Entities;
using App.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace App.Test.Entities
{
    [TestClass]
    public class OrderTests
    {        
        Name name = new Name("douglas","Rocha");
        Email email = new Email("teste@teste.com");
        User user = new User("douglas","123456789");
        Document documentInvalid = new Document("12345678911");
        Document document = new Document("09752725600");
        

        [TestMethod]
        public void GivenAnOutOfStockProductSholdReturnFalse()
        {
            Customer customer = new Customer(name,document,DateTime.Now,email,user);
            var mouse = new Product("Mouse",10,0,"mouse.img");

            var order = new Order(customer,5,0);
            order.AddItem(new OrderItem(mouse,1,10));

            Assert.IsFalse(order.Valid);
        }

        [TestMethod]
        public void GivenAnInOfStockProductSholdDecreaseQuantityOnHand()
        {
            Customer customer = new Customer(name,document,DateTime.Now,email,user);
            var mouse = new Product("Mouse",10,20,"mouse.img");
            var order = new Order(customer,5,0);
            order.AddItem(new OrderItem(mouse,2,10));

            Assert.IsTrue(mouse.QuantityOnHand == 18);
        }

        [TestMethod]
        public void TestTotalOrder()
        {
            Customer customer = new Customer(name,document,DateTime.Now,email,user);
            var mouse = new Product("Mouse",10,20,"mouse.img");

            var order = new Order(customer,5,0);
            order.AddItem(new OrderItem(mouse,2,10));

            Assert.IsTrue(order.Total() == 25);
        }

        [TestMethod]
        public void ShouldReturnInvalidWhenOrderIsNotValid()
        {
            Customer customer = new Customer(name,documentInvalid,DateTime.Now,email,user);
            var mouse = new Product("Mouse",10,20,"mouse.img");

            var order = new Order(customer,5,0);
            order.AddItem(new OrderItem(mouse,2,10));

            Assert.IsTrue(order.Invalid);
        }
    }
}