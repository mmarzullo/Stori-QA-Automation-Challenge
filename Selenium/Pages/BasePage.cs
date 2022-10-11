using StoriTest.Selenium.Driver;
using StoriTest.Shared;
using Xunit;

namespace Selenium.Pages
{
    public abstract class BasePage
    {
        protected readonly double Timeout = 15;
        protected string BaseUrl = ConfigurationReader.GetInstance()["ContactUrl"];
        protected string Url = "";

        public void Navigate() => Driver.Browser.Navigate().GoToUrl(BaseUrl + Url);

        public void VerifyPageUrl() => Assert.Contains(BaseUrl, Driver.Browser.Url);
    }
}
