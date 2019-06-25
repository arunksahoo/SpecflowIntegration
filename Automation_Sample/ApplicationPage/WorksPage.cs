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
    class WorksPage
    {
        public static dynamic contactPage_element = ReadingFile.RdWrJsonFile("WorksPage");
        string InputValue = contactPage_element;
        public WorksPage()
        {
            PageFactory.InitElements(ParallelTestExecution.Driver, this);
        }


        //  UI All Works Filter Menu Text
        public static IWebElement Filtertitle_Element(String locator)
        {
            var Filtertitle_Element = CutomizedBasePage.FindElement(By.XPath(locator), 30);
            return Filtertitle_Element;
        }

        /*
         Works Page All Functonalites Method
       */
        // GetText for All Works Filter Menu Text
        public static IWebElement Filtertitle_getText()
        {
            try
            {
                string InputValue = contactPage_element.Filtertitle_Element;
                IWebElement getTextFilterMenu = Filtertitle_Element(InputValue);
                return getTextFilterMenu;

            }
            catch (Exception e)
            {
                throw (e);
            }


        }

    }
}
