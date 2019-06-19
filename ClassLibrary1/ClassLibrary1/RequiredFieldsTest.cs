using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using System.IO;
using SeleniumHelper;



namespace SeleniumTest
{
    [TestFixture]
    public class InterviewTest
    {

        string FirstName, LastName, url;
        int PhoneNumber;
        SeleniumFunctions Selenium;

        [SetUp]
        public void Startup()
        {

            FirstName = "FirstName_Test";
            LastName = "LastName_Test";
            PhoneNumber = 1112223333;
            url = "https://checkin.universalplant.com/";
            Selenium = new SeleniumFunctions();
            Selenium.SetupDrivers();
        }

        [Test]
        public void AllRequiredFields()
        {
            //Goto checkin Enter FirstName & LastName then submit
            Selenium.GoToUrl(url);
            Selenium.FindElement("fname", FirstName);
            Selenium.FindElement("/html/body/app-root/newprospectregistration/body/div/div/div/form/p[2]/input", LastName);
            Selenium.FindElement("/html/body/app-root/newprospectregistration/body/div/div/div/form/div[5]/button", true);

            //Validate Error Message Shows 
            Selenium.WaitByXpath("/html/body/app-root/newprospectregistration/body/div[1]/strong");
            //Could then validate that the error message is showing correctily by checking the text values of the message vs requirements.

            //Now enter phone number & submit.
            Selenium.FindElement("k-textbox", true);
            Selenium.FindElement("k-textbox", PhoneNumber.ToString());
            Selenium.FindElement("/html/body/app-root/newprospectregistration/body/div/div/div/form/div[5]/button", true);

            //Waiting to make sure that the page after we submitted comes up.
            Selenium.WaitByXpath("/html/body/app-root/thankyou/div/p[2]/a");
        }

        [TearDown]
        public void ShutDown()
        {
            Selenium.ShutDownDrivers();
        }

    }
}