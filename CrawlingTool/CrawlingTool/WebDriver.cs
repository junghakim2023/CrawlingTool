﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CrawlingTool{

    class WebDriver{

        IWebDriver driver;
        const int waitSeconds = 60 * 5;

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

    }
}