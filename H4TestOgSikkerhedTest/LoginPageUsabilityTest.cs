using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium.Edge;

namespace H4TestOgSikkerhedTest
{
    public class LoginPageUsabilityTest
    {
        [Fact]
        public void LoginWithoutTwoFactorTest()
        {
            // Create a new instance of the Edge driver
            using (var driver = new EdgeDriver())
            {
                // Navigate to the login page
                driver.Navigate().GoToUrl("https://localhost:7084/Identity/Account/Login");

                // Find the username text field
                var usernameField = driver.FindElement(By.Id("Input_Email"));

                // Set the username
                usernameField.SendKeys("test1@test.dk");

                // Find the password text field
                var passwordField = driver.FindElement(By.Id("Input_Password"));

                // Set the password
                passwordField.SendKeys("123-Qwer");

                // Find the login button
                var loginButton = driver.FindElement(By.Id("login-submit"));

                // Click the login button
                loginButton.Click();

                // Check if the application redirects to the home page
                var homePage = driver.Title;
                Assert.Equal("Index", homePage);
            }
        }

        [Fact]
        public void LoginWithTwoFactorTest()
        {
            // Create a new instance of the Edge driver
            using (var driver = new EdgeDriver())
            {
                // Navigate to the login page
                driver.Navigate().GoToUrl("https://localhost:7084/Identity/Account/Login");

                // Find the username text field
                var usernameField = driver.FindElement(By.Id("Input_Email"));

                // Set the username
                usernameField.SendKeys("test2@test.dk");

                // Find the password text field
                var passwordField = driver.FindElement(By.Id("Input_Password"));

                // Set the password
                passwordField.SendKeys("123-Qwer");

                // Find the login button
                var loginButton = driver.FindElement(By.Id("login-submit"));

                // Click the login button
                loginButton.Click();

                // Check if the application redirects to the home page
                var twoFactorPage = driver.Title;
                Assert.Equal("Two-factor authentication - H4TestOgSikkerhed", twoFactorPage);
            }
        }
    }
}