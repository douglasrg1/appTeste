using System;
using App.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace App.Test.Entities
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void GivenAnOutOfStockProductSholdReturnFalse()
        {
            var user = new User("douglas","123456789");
            var customer = new Customer("douglas","Rocha",DateTime.Now,"douglas@teste.com",user);
            var mouse = new Product("Mouse",10,0,"mouse.img");

            var order = new Order(customer,5,0);
            order.AddItem(new OrderItem(mouse,1,10));

            Assert.IsFalse(order.Valid);
        }

        [TestMethod]
        public void GivenAnInOfStockProductSholdDecreaseQuantityOnHand()
        {
            var user = new User("douglas","123456789");
            var customer = new Customer("douglas","Rocha",DateTime.Now,"douglas@teste.com",user);
            var mouse = new Product("Mouse",10,20,"mouse.img");

            var order = new Order(customer,5,0);
            order.AddItem(new OrderItem(mouse,2,10));

            Assert.IsTrue(mouse.QuantityOnHand == 18);
        }

        [TestMethod]
        public void TestTotalOrder()
        {
            var user = new User("douglas","123456789");
            var customer = new Customer("douglas","Rocha",DateTime.Now,"douglas@teste.com",user);
            var mouse = new Product("Mouse",10,20,"mouse.img");

            var order = new Order(customer,5,0);
            order.AddItem(new OrderItem(mouse,2,10));

            Assert.IsTrue(order.Total() == 25);
        }
    }
}