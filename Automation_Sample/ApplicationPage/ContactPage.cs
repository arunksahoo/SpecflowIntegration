using Automation_Sample.Utilites;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Sample.ApplicationPage
{
    public class ContactPage
    {
        public static dynamic contactPage_element = ReadingFile.RdWrJsonFile("ContactPage");
        string InputValue = contactPage_element;
        public ContactPage()
        {
            PageFactory.InitElements(ParallelTestExecution.Driver, this);
        }


        // WebElement Contact number of Hyderbad
        public static IWebElement HyderbadConatctNumber_Element(String locator)
        {
            var HyderbadConatctNumber_Element = CutomizedBasePage.FindElement(By.XPath(locator), 30);
            return HyderbadConatctNumber_Element;
        }

        /*
         Contact Page All Functonalites Method
       */
        // Get text for Contact number of Hyderbad
        public static IWebElement HyderbadConatctNumbergetText()
        {
            try
            {
                string InputValue = contactPage_element.Hyderbad_ConatctNumber_Element;
                IWebElement getTextHyderbadPhonenumber = HyderbadConatctNumber_Element(InputValue);
                return getTextHyderbadPhonenumber;

            }
            catch (Exception e)
            {
                throw (e);
            }


        }

    }



}

