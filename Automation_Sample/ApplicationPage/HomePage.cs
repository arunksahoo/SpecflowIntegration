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
    public class HomePage
    {
        public static dynamic homepage_element = ReadingFile.RdWrJsonFile("HomePage");
        string InputValue = homepage_element;
        public HomePage()
        {
            PageFactory.InitElements(ParallelTestExecution.Driver, this);
        }


        // UI Header Contact Button
        public static IWebElement UIHeaderContactButton_Element(String locator)
        {
            var UIHeaderContactButton_Element = CutomizedBasePage.FindElement(By.XPath(locator), 30);
            return UIHeaderContactButton_Element;
        }

        // UI Header Works Button
        public static IWebElement UIHeaderWORKS_Button_Element(String locator)
        {
            var UIHeaderWORKS_Button_Element = CutomizedBasePage.FindElement(By.XPath(locator), 30);
            return UIHeaderWORKS_Button_Element;
        }
        
        /*
         Home Page All Functonalites Method
       */
        // Click on the Contact link
        public static void ClickOnContact()
        {
            try
            {
                string InputValue = homepage_element.Contact_Element;
                IWebElement clickOnContact = UIHeaderContactButton_Element(InputValue);
                clickOnContact.Click();
                
            }
            catch (Exception e)
            {
                throw (e);
            }


        }
        // Click ON Works Button in Header section
        public static void ClickOnWorksButton()
        {
            try
            {
                string InputValue = homepage_element.Works_Headers_Element;
                IWebElement clickOnWorksButton = UIHeaderWORKS_Button_Element(InputValue);
                clickOnWorksButton.Click();

            }
            catch (Exception e)
            {
                throw (e);
            }


        }
    }



}