using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4TestOgSikkerhedTest
{
    public class FileTestPage
    {
        [Fact]
        public void Testfile()
        {
            using (var webdriver = new ChromeDriver())
            {
                webdriver.Navigate().GoToUrl("https://localhost:7084/filetest");

                var button = webdriver.FindElement(By.Id("filetest_button"));
                button.Click();
            }
        }





    }
}
