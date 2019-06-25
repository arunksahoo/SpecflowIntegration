using Automation_Sample.Utilites;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTesting.CustomMethods
{
    class SeleniumSetMethods
    {
        //Enter Text
        public static void EnterText(string element, string value, PropertyType elementtype)
        {
            if (elementtype == PropertyType.Id)
                ParallelTestExecution.Driver.FindElement(By.Id(element)).SendKeys(value);
            if (elementtype == PropertyType.Name)
                ParallelTestExecution.Driver.FindElement(By.Name(element)).SendKeys(value);
        }


        // Click into a button ,checkbox , option etc
        public static void Click(string element, PropertyType elementtype)
        {
            if (elementtype == PropertyType.Id)
                ParallelTestExecution.Driver.FindElement(By.Id(element)).Click();
            if (elementtype == PropertyType.Name)
                ParallelTestExecution.Driver.FindElement(By.Name(element)).Click();
        }

        // Selecting a dropdown control
        public static void SelectDropdown(string element, string value, PropertyType elementtype)
        {
            if (elementtype == PropertyType.Id)
                new SelectElement(ParallelTestExecution.Driver.FindElement(By.Id(element))).SelectByText(value);
            if (elementtype == PropertyType.Name)
                new SelectElement(ParallelTestExecution.Driver.FindElement(By.Name(element))).SelectByText(value);
        }


    }
}

