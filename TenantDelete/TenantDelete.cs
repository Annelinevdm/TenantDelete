using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;

namespace TenantDelete
{
    public class Tests
    {
        IWebDriver driver = new ChromeDriver(@"C:\\Users\\Anneline\\source\\repos\\");
        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://cams.azurewebsites.net/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Console.WriteLine(driver.Title);
        }
        [TestCase]
        public void Login()
        {
            //Enter the Login details
            IWebElement UserName = driver.FindElement(By.Id("LoginInput_UserNameOrEmailAddress"));
            UserName.SendKeys("admin");
            IWebElement PassWord = driver.FindElement(By.Id("LoginInput_Password"));
            PassWord.SendKeys("1q2w3E*");
            IWebElement LoginButton2 = driver.FindElement(By.CssSelector("body > div.d-flex.align-items-center > div > div > div > div.card > div.card-body > div > form > button"));
            LoginButton2.Click();

            //Click on Administration
            IWebElement AdminiStration = driver.FindElement(By.XPath("//*[@id='mCSB_1_container']/nav/ul/li[3]/a/span[2]"));
            AdminiStration.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //Click on SaaS
            IWebElement SaAs = driver.FindElement(By.XPath("//*[@id='MenuItem_Abp.Application.Main.Administration']/li[1]/a/span[2]"));
            SaAs.Click();

            //Click on Tenants
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            IWebElement TeNant = driver.FindElement(By.XPath("//*[@id='MenuItem_SaasHost']/li[1]/a/span[2]"));
            TeNant.Click();

            //Click on the Tenant
            IWebElement ClickTenant = driver.FindElement(By.XPath("//*[@id='TenantsGrid']/div[3]/table/tbody/tr[2]/td[2]/div/div[1]"));
            ClickTenant.Click();

            //Click on Delete link
            IWebElement DeleteLInk = driver.FindElement(By.XPath("/html/body/div[4]/ul/li/a[5]/span[2]"));
            DeleteLInk.Click();

            //Click on the OK button
            IWebElement DeletButton = driver.FindElement(By.XPath("/ html / body / div[6] / div[3] / button[1]"));
            DeletButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

         }
        [TearDown]
        public void Logout()
        {
            //Logout
            Actions action1 = new Actions(driver);
            action1.MoveToElement(driver.FindElement(By.Id("dropdownMenuUser"))).Build().Perform();
            IWebElement manageProfile = driver.FindElement(By.Id("MenuItem_Account.Logout"));
            manageProfile.Click();
            driver.Quit();
        }
    }
}