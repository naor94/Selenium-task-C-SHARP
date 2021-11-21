using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;  // include the System.IO namespace



namespace Selenium_task
{
    public class Tests
    {
        string url = "https://traderqa1.iforex.com";
        IWebDriver driver;
        //string userName = "GameUserFih111";
       // string password = "jn5t9z4cxf";
        ValidCredentials vc = new ValidCredentials();

        public void login()
        {
            var txtUserName = driver.FindElement(By.Name("UserName"));
            var txtPassword = driver.FindElement(By.Name("Password"));
            var clickButton = driver.FindElement(By.Id("btnOkLogin"));
            txtUserName.SendKeys(vc.getUser());
            txtPassword.SendKeys(vc.getPassword());
            clickButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            try
            {
                //element that exist only after login
                var accountPart = driver.FindElement(By.Id("account"));

            }
            catch (Exception)
            {
                Console.WriteLine("The page was not loaded in less than 10 ");
            }



        }
        [SetUp]
        public void Setup()
        {
            vc.setUserPassword();


            //open browser
            driver = new ChromeDriver();
            //Navigate to site
            try
            {
                driver.Navigate().GoToUrl(vc.getUrl());
            }
            catch(Exception e)
            {
                Console.WriteLine("There was an error" + e);
            }
        }

        [Test]
        public void loginTest()
        {
          //  vc.setUserPassword();
            login();
            Assert.Pass();
        }
        [Test]

        public void logOutTest()
        {
            login();
            var accountPart = driver.FindElement(By.Id("account"));
            accountPart.Click();
            var logoutBtn = driver.FindElement(By.XPath("//*[@id=\"logout\"]/span[2]"));
            logoutBtn.Click();
            var confirmLogoutBtn = driver.FindElement(By.XPath(" //*[@id=\"ExitAlertbutton0\"]"));
            confirmLogoutBtn.Click();
            var quesionMarkHover = driver.FindElement(By.XPath(" //*[@id=\"lblUname\"]/i"));
            String text = quesionMarkHover.GetAttribute("title");
            writeToFile(text);

        }

        public void writeToFile(string text)
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("filename.txt");
                //Write a line of text
                sw.WriteLine(text);
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        [TearDown]
        //Close browser
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}