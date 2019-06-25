using AventStack.ExtentReports;
using Automation_Sample.Utilites;
using log4net;
using log4net.Config;
using NUnit.Framework;
using System;
using Automation_Sample.ApplicationPage;

namespace Automation_Sample.TestScripts
{

    class SampleAutomationTest
    {


        EReports report = new EReports();
        protected ILog logger = LogManager.GetLogger(typeof(SampleAutomationTest));
        public static dynamic validationData = ReadingFile.RdWrJsonFile("ValidationData");
        [OneTimeSetUp]
        public void File()
        {

            report.StartReports();
        }
        [SetUp]
        public void Intilize()
        {
            string URL = ReadingFile.RdWrJsonFile("ApplicationSetUp").Application_URL;
            report.BeforeTest();
            ParallelTestExecution.BrowserInstance(BrowseType.Chrome);
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

