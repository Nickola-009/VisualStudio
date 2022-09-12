using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace VisualStudio_Testing
{
    [TestClass]
    public class Selenium
    {
        [TestMethod]
        public void searchgoogle()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("headless");
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), option))
            {
                driver.Navigate().GoToUrl("https:www.google.com");
                IWebElement query = driver.FindElement(By.Name("q"));
                query.SendKeys("Cheese");
                query.Submit();
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d=> d.Title.StartsWith("Cheese",StringComparison.OrdinalIgnoreCase));
                //Assert.AreEqual(driver.Title, "Cheese - Google Search");
            }
        }
    }
}
