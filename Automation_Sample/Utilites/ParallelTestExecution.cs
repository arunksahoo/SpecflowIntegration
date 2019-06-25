using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
namespace Automation_Sample.Utilites
{

   public enum BrowseType
    {
    Chrome,
    IE,
    Firefox
    }
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        ClassName
    }

    class ParallelTestExecution
    {
        public readonly IObjectContainer _0bjectContainer;
  
        public BrowseType broswerType;

        
        // Webdriver Installation 
            // Auto-implememted property
         public static IWebDriver Driver { get; set; }

        

        public ParallelTestExecution(IObjectContainer objectContainer){
            _0bjectContainer = objectContainer;
       }


        public ParallelTestExecution(BrowseType browser)
        {

            broswerType = browser;
        }

        public void IntializeBrowser()
        {
            BrowserInstance(broswerType);
            _0bjectContainer.RegisterInstanceAs<IWebDriver>(ParallelTestExecution.Driver);
        }

        // Browser Instance to Lunch
        public static void BrowserInstance(BrowseType browserInstance)
        {

            if (browserInstance == BrowseType.Chrome)
                ParallelTestExecution.Driver = new ChromeDriver();
            else if (browserInstance == BrowseType.Firefox)
                ParallelTestExecution.Driver = new FirefoxDriver();
            else if (browserInstance == BrowseType.IE)
                ParallelTestExecution.Driver = new InternetExplorerDriver();


        }

    }
       
}
