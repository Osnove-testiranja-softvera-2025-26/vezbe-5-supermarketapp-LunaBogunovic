using NUnit.Framework;
using OTS_Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS_Supermarket.Test
{
    [TestFixture]
    public class CartTest
    {
        [Test]
        public void AddOneToCart_ShouldAddItemToCart_Success() //naziv testa treba da sadrzi ime metode koja se testira, uslov i ocekivani rezultat
        {
            //ARANGE
            Cart cart = new Cart();
            Monitor monitor = new Monitor();
            //ACT
            cart.AddOneToCart(monitor);
            //ASSERT
            Assert.That(cart.Size, Is.EqualTo(1));
            Assert.That(cart.Amount, Is.EqualTo(100));

            //svaki test ima ova tri dela
            //testiranje najmanje jedinice - jedne metode
            //jednim testom proveravamo samo jednu stvar 
        }
        [Test]
        public void AddOneToChart_OneMonitorToChart_Success()
        {
            //ARANGE
            Cart cart = new Cart();
            Monitor monitor = new Monitor();
            //ACT
            cart.AddOneToCart(monitor);
            //ASSERT
            Assert.That(1, Is.EqualTo(cart.Monitor_counter));
        }
        [Test]
        public void AddOneToChart_ShouldAddMultipleItemsToCart_Success()
        {
            //ARANGE
            Cart cart = new Cart();
            Monitor monitor = new Monitor();
            Keyboard keyboard = new Keyboard();
            Laptop laptop = new Laptop();
            Computer computer = new Computer();
            Chair chair = new Chair();
            //ACT
            cart.AddOneToCart(monitor);
            cart.AddOneToCart(keyboard);
            cart.AddOneToCart(laptop);
            cart.AddOneToCart(computer);
            cart.AddOneToCart(chair);
            //ASSERT
            Assert.That(cart.Size, Is.EqualTo(5));
        }
        [Test]
public void AddOneToCart_AddMultipleItemsToCartAndCalculateAmount_Success()
{
    // Arrange
    Cart cart = new Cart();

    Monitor monitor = new Monitor("Samsung", 100);
    Keyboard keyboard = new Keyboard("Logitech", 50);
    Laptop laptop = new Laptop("HP", 500);
    Computer computer = new Computer("Dell", 700);
    Chair chair = new Chair("Office", 150);

    // Act
    cart.AddOneToCart(monitor);
    cart.AddOneToCart(keyboard);
    cart.AddOneToCart(laptop);
    cart.AddOneToCart(computer);
    cart.AddOneToCart(chair);

    // Assert
    Assert.That(cart.Amount, Is.EqualTo(1500).Within(0.01));
}

        public void Print_WhenCartIsEmpty_ShouldThrowException()
        {
            // Arrange
            Cart cart = new Cart(); // Velicina ce biti 0

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => cart.Print());
            Assert.That(exception.Message, Is.EqualTo("Cannot print empty cart!"));
        }

        [Test]
        public void Calculate_WithInvalidDateFormat_ShouldThrowException()
        {
            // Arrange
            Cart cart = new Cart();
            string invalidDate = "25.12.2025.";

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => cart.Calculate(invalidDate));
            Assert.That(exception.Message, Is.EqualTo("Wrong date format! Date must be in format yyyy-MM-dd"));
        }
        // PICT MODEL

        /*
        budget: 5000,4000
        days: 1
        computers: 3
        monitors: 3
        keyboards: 3
        */

        [TestCase(5000, 3245)]
        [TestCase(4000, 2245)]
        public void Calculate_PictModel(double budget, double expectedBudget)
        {
            Cart cart = new Cart();
            cart.Budget = budget;

            cart.AddMultipleToCart(new Computer("Dell", 400), 3);
            cart.AddMultipleToCart(new Monitor("Samsung", 200), 3);
            cart.AddMultipleToCart(new Keyboard("Logitech", 50), 3);

            string date = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");

            cart.Calculate(date);

            Assert.That(cart.Budget, Is.EqualTo(expectedBudget).Within(0.01));
        }
    }
}

//TestCase sa ulaznim parametrima (razlicitim), za jedan test moze biti vise testcase-ova
//ExpectedResult - ocekivani rezultat, koji se proverava sa Assert-om, pise se uz testcase
//na testu treba iskoristiti i testcase i sve sto radimo
//TestCaseSource - kada imam fajl sa test podacima, onda koristim TestCaseSource, a ne TestCase, i onda u testu koristim te podatke
//pict model - kada imamo vise testova koji testiraju istu funkcionalnost, onda mozemo da koristimo pict model, koji nam generise testove na osnovu ulaznih podataka, i onda te testove koristimo u testiranju
//na testu kreiras txt fajl koji sadrzi pict model, naosnovu tih podataka se generisu testovi, i onda te testove koristis u testiranju
//CarttxtParser - klasa koja parsira txt fajl i vraca listu objekata, koji se koriste u testiranju
//splitovanje po tabu, izmedju drugog i treceg taba je treci clan

