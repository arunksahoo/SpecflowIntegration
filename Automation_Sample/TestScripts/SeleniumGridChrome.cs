using AventStack.ExtentReports;
using Automation_Sample.Utilites;
using log4net;
using log4net.Config;
using NUnit.Framework;
using System;
using Automation_Sample.ApplicationPage;
using OpenQA.Selenium.Remote;

namespace Automation_Sample.TestScripts
{
    class SeleniumGridChrome
    {


        EReports report = new EReports();
        protected ILog logger = LogManager.GetLogger(typeof(SeleniumGridChrome));
        public static dynamic validationData = ReadingFile.RdWrJsonFile("ValidationData");
        [OneTimeSetUp]
        public void File()
        {

            report.StartReports();
        }
        [SetUp]
        public void Intilize()
        {
            DesiredCapabilities capability = new DesiredCapabilities();
            capability.SetCapability("platform", "WIN10");
            capability.SetCapability("browserName", "chrome");
            //Hub URL
            String huburl = "http://172.16.48.53:4546/wd/hub";

            // Create driver with hub address and capability
            ParallelTestExecution.Driver = new RemoteWebDriver(new Uri(huburl), capability);

            string URL = ReadingFile.RdWrJsonFile("ApplicationSetUp").Application_URL;
            report.BeforeTest();
            logger.Debug("Lunched Browser");
            ParallelTestExecution.Driver.Manage().Window.Maximize();
            ParallelTestExecution.Driver.Navigate().GoToUrl(URL);
            CutomizedBasePage.WaitonPage(5);
            logger.Info("Navigate to UI");
        }

        // Create a Portfolio and Then Delete the Portfolio functinality
        [Test]
        public void Applicationflow()
        {
            HomePage.ClickOnContact();
            var contactNumber = ContactPage.HyderbadConatctNumbergetText().Text;
            String ActualContact = contactNumber.ToString().TrimStart();
            string ExpectedContact = validationData.Hyderbad_ConatctNumber_Text;
            Assert.AreEqual(ActualContact, ExpectedContact);

            HomePage.ClickOnWorksButton();
            var filterMenuName = WorksPage.Filtertitle_getText().Text;
            String ActualfilterMenuName = filterMenuName.ToString().TrimStart();
            string ExpectedfilterMenuName = validationData.WorksPage_FilterMenu_Text;
            Assert.AreEqual(ActualfilterMenuName, ExpectedfilterMenuName);


        }
        [TearDown]
        public void CloseBrowser()
        {

            ParallelTestExecution.Driver.Quit();
            logger.Debug("Browser is closed");

        }
        [OneTimeTearDown]
        public void EndReport()
        {
            report.AfterClass();
        }
    }
}

