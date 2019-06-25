using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Sample.Utilites
{
    public static class CutomizedBasePage
    {


        public static void WaitonPage(int seconds)
        {
            System.Threading.Thread.Sleep(seconds);
        }

        // Waiton Page Until Element Is Visable
        public static IWebElement WaitonPageUntilElementIsVisable(By locator)
        {
            return new WebDriverWait(ParallelTestExecution.Driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementExists(locator));
        }

        // Wait on Pag eTill Element Appear
        public static IWebElement WaitonPageTillElementAppear(By locator)
        {

            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(ParallelTestExecution.Driver);
            wait.Timeout = TimeSpan.FromMinutes(2);
            wait.PollingInterval = TimeSpan.FromSeconds(5);
            IWebElement element = wait.Until(ExpectedConditions.ElementExists(locator));
            return element;

        }

        //  Find Single Element In The Web Page
        public static IWebElement FindElement(By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(ParallelTestExecution.Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return ParallelTestExecution.Driver.FindElement(by);
        }

        // Find Multiple Element In The Web Page
        public static ReadOnlyCollection<IWebElement> FindElements(By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(ParallelTestExecution.Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
            }
            return ParallelTestExecution.Driver.FindElements(by);
        }



        public static String waitForSpinnerDisable()
        {
            String display_Value = "";
            for (int i = 0; i < 10; i++)
            {
                WaitonPage(1000);
                display_Value = ParallelTestExecution.Driver.FindElement(By.XPath("//div[@id='page-wait-outer' and contains(@ng-show,'isLoading || showSpinner')]")).GetCssValue("display");
                if (display_Value.Equals("none"))
                {
                    break;
                }
                i++;
            }
            return display_Value;
        }

    }
}