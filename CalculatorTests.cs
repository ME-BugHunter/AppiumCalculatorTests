using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
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
        //private AppiumLocalService appiumLocalService;

        [OneTimeSetUp]
        public void OpenApplication()
        {
            this.appiumOptions = new AppiumOptions(); 
            //here we specify what app we will test and on what OS (Windows)
            appiumOptions.AddAdditionalCapability("app", appLocation);
            appiumOptions.AddAdditionalCapability("PlatformName", "Windows");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);

            

            //Another set up - Start the Appium server as local Node.js app
            /*this.appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            appiumLocalService.Start();
            this.appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", appLocation);
            appiumOptions.AddAdditionalCapability("PlatformName", "Windows");
            this.driver = new WindowsDriver<WindowsElement>(appiumLocalService,appiumOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);*/
        }

        [OneTimeTearDown]
        public void CloseApplication()
        {
            driver.CloseApp();
            driver.Quit();
        }

        [TestCase("5", "15", "20")]
        [TestCase("5", "alabala", "error")]
        [TestCase("alabala", "15", "error")]
        [TestCase("30", "15", "45")]
        [TestCase("-30", "15", "-15")]
        public void Test_SumNumbers(string firstNumber, string secondNumber, string result)
        {
            //Arrange
            var firstNum = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondNum = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calculateButton = driver.FindElementByAccessibilityId("buttonCalc");
 
            //Act
            firstNum.Clear();
            secondNum.Clear();
            firstNum.SendKeys(firstNumber);
            secondNum.SendKeys(secondNumber);
            calculateButton.Click();

            //Assert
            Assert.That(resultField.Text, Is.EqualTo(result));
        }
    }
}