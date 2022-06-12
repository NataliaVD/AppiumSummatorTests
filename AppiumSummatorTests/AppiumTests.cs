using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumSummatorTests
{
    public class AppiumTests
    {

        private WindowsDriver<WindowsElement> driver;
        private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;

        [SetUp]
        public void OpenApp()
        {
            this.options = new AppiumOptions() { PlatformName = "Windows" };
            options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\WindowsFormsApp.exe");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer), options);
        }

        [TearDown]
        public void CloseApp()
        {
            this.driver.Quit();
        }
        [Test]
        public void TestSumTwoPositiveNumbers()
        {
            var firstNum = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondNum = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var result = driver.FindElementByAccessibilityId("textBoxSum");
            var calculate = driver.FindElementByAccessibilityId("buttonCalc");
            firstNum.Click();
            firstNum.SendKeys("19");
            secondNum.Click();
            secondNum.SendKeys("9");
            calculate.Click();

            Assert.That(result.Text, Is.EqualTo("28"));
        }
    }
}