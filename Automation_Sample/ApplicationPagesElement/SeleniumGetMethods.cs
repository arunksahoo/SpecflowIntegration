
using Automation_Sample.Utilites;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTesting.CustomMethods
{
    class SeleniumGetMethods
    {
        //Enter Text
        public static string GetText(string element, PropertyType elementtype)
        {
            if (elementtype == PropertyType.Id)
                return ParallelTestExecution.Driver.FindElement(By.Id(element)).GetAttribute("value");
            if (elementtype == PropertyType.Name)
                return ParallelTestExecution.Driver.FindElement(By.Name(element)).GetAttribute("value");
            else return String.Empty;
        }
    
    //Enter Text
    public static string DropdownListText(string element, PropertyType elementtype)
    {
            if (elementtype == PropertyType.Id)
                return new SelectElement(ParallelTestExecution.Driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault().Text;
            if (elementtype == PropertyType.Name)
                return new SelectElement(ParallelTestExecution.Driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;
            else return String.Empty;
    }
}
}
