using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;


namespace AppiumCalculatorTests
{
    public class CalculatorTests
    {
        //private WebDriver driver
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"C:\Users\Lenovo\SummatorDesktopApp.exe";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions appiumOptions;

        [SetUp]
        public void OpenApplication()
        {
            this.appiumOptions = new AppiumOptions(); 
            //here we specify what app we will test and on what OS (Windows)
            appiumOptions.AddAdditionalCapability("app", appLocation);
            appiumOptions.AddAdditionalCapability("PlatformName", "Windows");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);
        }

        [TearDown]
        public void CloseApplication()
        {
            driver.Quit();
        }

        [Test]
        public void Test_Sum_TwoPositiveNumbers()
        {
            Assert.Pass();
        }
    }
}