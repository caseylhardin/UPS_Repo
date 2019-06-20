using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SeleniumHelper
{
    class SeleniumFunctions
    {
        WebDriverWait mWaitDriver;
        IWebDriver mDriver;


        public void SetupDrivers()
        {
            mDriver = new ChromeDriver();
            mWaitDriver = new WebDriverWait(mDriver, TimeSpan.FromSeconds(20));
        }

        public void ShutDownDrivers()
        {
            mDriver.Close();
        }

        public void GoToUrl(string URL)
        {
            mDriver.Navigate().GoToUrl(URL);
        }


        public bool ValidateElementText(string Element, string TextCompare)
        {
            if (FindElement(Element).Text == TextCompare)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public IWebElement FindElement(string ID_Name_ClassName_XPath)
        {
            try
            {
                return this.mDriver.FindElement(By.Id(ID_Name_ClassName_XPath));
            }
            catch (Exception)
            {
                try
                {
                    return this.mDriver.FindElement(By.Name(ID_Name_ClassName_XPath));
                }
                catch (Exception)
                {
                    try
                    {
                        return this.mDriver.FindElement(By.ClassName(ID_Name_ClassName_XPath));
                    }
                    catch (Exception)
                    {
                        try
                        {
                            return this.mDriver.FindElement(By.XPath(ID_Name_ClassName_XPath));
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
            }
        }
        public void FindElement(string ID_Name_ClassName_XPath, bool Click)
        {
            try
            {
                this.mDriver.FindElement(By.Id(ID_Name_ClassName_XPath)).Click();
                return;
            }
            catch (Exception)
            {
                try
                {
                    this.mDriver.FindElement(By.Name(ID_Name_ClassName_XPath)).Click();
                    return;
                }
                catch (Exception)
                {
                    try
                    {
                        this.mDriver.FindElement(By.ClassName(ID_Name_ClassName_XPath)).Click();
                        return;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            this.mDriver.FindElement(By.XPath(ID_Name_ClassName_XPath)).Click();
                            return;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }

                }
            }
        }

        public void FindElement(string ID_Name_ClassName_XPath, string StringtoEnter)
        {
            try
            {
                this.mDriver.FindElement(By.Id(ID_Name_ClassName_XPath)).SendKeys(StringtoEnter);
                return;
            }
            catch (Exception)
            {
                try
                {
                    this.mDriver.FindElement(By.Name(ID_Name_ClassName_XPath)).SendKeys(StringtoEnter);
                    return;
                }
                catch (Exception)
                {
                    try
                    {
                        this.mDriver.FindElement(By.ClassName(ID_Name_ClassName_XPath)).SendKeys(StringtoEnter);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            this.mDriver.FindElement(By.XPath(ID_Name_ClassName_XPath)).SendKeys(StringtoEnter);
                            return;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
            }
        }


        // WaitBY element once it is found return the element , click, send string to it.
        public IWebElement WaitByID(string ID)
        {
            return this.mWaitDriver.Until(ExpectedConditions.ElementToBeClickable(By.Id(ID)));
        }
        public void WaitByID(string ID, bool Click)
        {
            try
            {
                this.mWaitDriver.Until(ExpectedConditions.ElementToBeClickable(By.Id(ID)));
                this.mDriver.FindElement(By.Id(ID)).Click();
            }
            catch
            {

            }

        }
        public void WaitByID(string ID, string StringtoEnter)
        {
            this.mWaitDriver.Until(ExpectedConditions.ElementToBeClickable(By.Id(ID)));
            this.mDriver.FindElement(By.Id(ID)).SendKeys(StringtoEnter);
        }
        public IWebElement WaitByName(string Name)
        {
            return this.mWaitDriver.Until(ExpectedConditions.ElementToBeClickable(By.Name(Name)));
        }
        public void WaitByName(string Name, bool Click)
        {
            this.mWaitDriver.Until(ExpectedConditions.ElementToBeClickable(By.Name(Name)));
            this.mDriver.FindElement(By.Name(Name)).Click();
        }
        public void WaitByName(string Name, string StringtoEnter)
        {
            this.mWaitDriver.Until(ExpectedConditions.ElementToBeClickable(By.Name(Name)));
            this.mDriver.FindElement(By.Name(Name)).SendKeys(StringtoEnter);
        }
        public IWebElement WaitByClassName(string ClassName)
        {
            return this.mWaitDriver.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(ClassName)));
        }
        public void WaitByClassName(string ClassName, bool Click)
        {
            this.mWaitDriver.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(ClassName)));
            this.mDriver.FindElement(By.ClassName(ClassName)).Click();
        }
        public void WaitByClassName(string ClassName, string StringtoEnter)
        {
            this.mWaitDriver.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(ClassName)));
            this.mDriver.FindElement(By.ClassName(ClassName)).SendKeys(StringtoEnter);
        }
        public IWebElement WaitByCSS(string CSS_Selector)
        {
            return this.mWaitDriver.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CSS_Selector)));

        }
        public void WaitByCSS(string CSS_Selector, bool Click)
        {
            this.mWaitDriver.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CSS_Selector)));
            this.mDriver.FindElement(By.CssSelector(CSS_Selector)).Click();
        }
        public void WaitByCSS(string CSS_Selector, string StringtoEnter)
        {
            this.mWaitDriver.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(CSS_Selector)));
            this.mDriver.FindElement(By.CssSelector(CSS_Selector)).SendKeys(StringtoEnter);

        }
        public IWebElement WaitByXpath(string xPath)
        {
            return this.mWaitDriver.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xPath)));
        }
        public void WaitByXpath(string xPath, bool Click)
        {
            this.mWaitDriver.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xPath))).Click();
            this.mDriver.FindElement(By.XPath(xPath)).Click();
        }
        public void WaitByXpath(string xPath, string StringtoEnter)
        {
            this.mWaitDriver.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xPath)));
            this.mDriver.FindElement(By.XPath(xPath)).SendKeys(StringtoEnter);

        }
    }
}