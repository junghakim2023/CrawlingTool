using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CrawlingTool{

    class WebDriver{

        IWebDriver driver;
        const int waitSeconds = 60 * 5;
        WebDriverWait wait;

        WebDriver() {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless"); // 브라우저 창 숨기기

            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitSeconds);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(waitSeconds);
        }

        ~WebDriver() {
            try{
                driver.Close();
                driver.Quit();
                driver.Dispose();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }

        void ToURL(String url) {
            driver.Url = url;
        }

        IWebElement FindElementByXPath(String xpath) {
            return driver.FindElement(By.XPath(xpath));
        }

        public void WaitForElement(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
        }

    }
}
