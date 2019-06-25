using AventStack.ExtentReports;
using Automation_Sample.Utilites;
using log4net;
using log4net.Config;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Automation_Sample.ApplicationPage;


namespace Automation_Sample.StepDefination
{
    [Binding]
    class ImagineApplicationAutomation
    {

        public static dynamic validationData = ReadingFile.RdWrJsonFile("ValidationData");
        public ILog logger = LogManager.GetLogger(typeof(ImagineApplicationAutomation));

        [Given(@"User is at the Imaginea HomePage")]
        public void GivenUserIsAtTheImagineaHomePage()
        {
            string URL = ReadingFile.RdWrJsonFile("ApplicationSetUp").Application_URL;
            ParallelTestExecution.BrowserInstance(BrowseType.Chrome);
            logger.Debug("Lunched Browser");
            ParallelTestExecution.Driver.Manage().Window.Maximize();
            ParallelTestExecution.Driver.Navigate().GoToUrl(URL);
            CutomizedBasePage.WaitonPage(5);
            logger.Info("Navigate to UI");
        }

        [Given(@"Click on the Contact button")]
        public void GivenClickOnTheContactButton()
        {
            HomePage.ClickOnContact();
        }

        [Then(@"Verify the Contact Number For Hyderbad Location")]
        public void ThenVerifyTheContactNumberForHyderbadLocation()
        {
            var contactNumber = ContactPage.HyderbadConatctNumbergetText().Text;
            String ActualContact = contactNumber.ToString().TrimStart();
            string ExpectedAddress = validationData.Hyderbad_ConatctNumber_Text;
            Assert.AreEqual(ActualContact, ExpectedAddress);
        }

        [When(@"Click on the Works Button")]
        public void WhenClickOnTheWorksButton()
        {
            HomePage.ClickOnWorksButton();
        }

        [Then(@"Verify if User redierct to WORKS page")]
        public void ThenVerifyIfUserRedierctToWORKSPage()
        {
            var filterMenuName = WorksPage.Filtertitle_getText().Text;
            String ActualfilterMenuName = filterMenuName.ToString().TrimStart();
            string ExpectedfilterMenuName = validationData.WorksPage_FilterMenu_Text;
            Assert.AreEqual(ActualfilterMenuName, ExpectedfilterMenuName);

        }
  
       
    }
}
