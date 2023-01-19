using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

                WebDriverWait wait = new WebDriverWait(webdriver, new TimeSpan(0, 0, 1));

                var button = webdriver.FindElement(By.Id("filetest_button"));
                button.Click();

                string sysPath;

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    sysPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                }
                else
                {
                    sysPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                }
                sysPath = Path.Combine(sysPath, "H4TestOgSikkerhed");
                sysPath = Path.Combine(sysPath, "Data");
                sysPath = Path.Combine(sysPath, "test.txt");
                bool fileExists = File.Exists(sysPath);

                Assert.True(fileExists);
            }



        }
        [Fact]
        public void IsFileCreated()
        {
            using(var webdriver = new ChromeDriver())
            {
                webdriver.Navigate().GoToUrl("https://localhost:7084/filetest");

                WebDriverWait wait = new WebDriverWait(webdriver, new TimeSpan(0, 0, 3));

                var button = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("filetest_button")));
                button.Click();
                //wait = new WebDriverWait(webdriver, new TimeSpan(0, 0, 3));

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("success")));




            }
        }
        [Fact]
        public void IsFileFailed()
        {
            using (var webdriver = new ChromeDriver())
            {
                webdriver.Navigate().GoToUrl("https://localhost:7084/filetest");

                WebDriverWait wait = new WebDriverWait(webdriver, new TimeSpan(0, 0, 3));

                var button = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("filetest_button")));
                button.Click();
                //wait = new WebDriverWait(webdriver, new TimeSpan(0, 0, 3));

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("fail")));

                


            }

        }




    }
}
