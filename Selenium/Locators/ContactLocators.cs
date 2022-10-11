using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace StoriTest.Locators
{
    internal class StoriLocator
    {
        protected static Actions Builder;
        protected static IWebDriver Driver;
        public StoriLocator()
        {
            Driver = Selenium.Driver.Driver.Browser;
            Builder = new Actions(Driver);
        }

        public IWebElement AlertBtn => Driver.FindElement(By.CssSelector("#alertbtn"));

        public IWebElement AlertInput => Driver.FindElement(By.CssSelector("#name.inputs"));

        public IWebElement ConfirmBtn => Driver.FindElement(By.CssSelector("#confirmbtn"));

        public IWebElement DropDownExample => Driver.FindElement(By.XPath("//fieldset/select"));

        public IWebElement iFrameExample => Driver.FindElement(By.XPath("//*[@id='courses-iframe']"));

        public IWebElement iFrameTxt => Driver.FindElement(By.XPath("//div[@class='price-title']//div[2]//li[2]"));

        public IWebElement OpenTabBtn => Driver.FindElement(By.CssSelector("#opentab"));

        public IWebElement OpenWindowBtn => Driver.FindElement(By.Id("openwindow"));

        public IWebElement SuggestionClassExample => Driver.FindElement(By.XPath("//*[@id='autocomplete']"));

        public IWebElement ThirtyDayTitleTxt => Driver.FindElement(By.CssSelector("div.col-xs-12.col-sm-12 div.col-sm-9 > h3"));

        public IWebElement Title => Driver.FindElement(By.CssSelector("body > h1"));

        public IList<IWebElement> WebTableExampleList => Driver.FindElements(By.CssSelector("#product[name ='courses'] > tbody > tr"));

        public IList<IWebElement> WebTableFixedHeaderList => Driver.FindElements(By.CssSelector("div.tableFixHead #product tr"));

        public IWebElement ABtn(string field) => Driver.FindElement(By.XPath($"//a[.='{field}']"));

        public void AcceptAlert() => Driver.SwitchTo().Alert().Accept();

        public void Close() => Driver.Close();

        public IWebElement CourseValue(int row) => Driver.FindElement(By.CssSelector($"#product[name ='courses'] > tbody > tr:nth-child({row}) > td:nth-child(2)"));

        public string CurrentTab() => Driver.CurrentWindowHandle;

        public IWebElement DropDownExampleSelect(int field) => Driver.FindElement(By.XPath($"//fieldset/select/option[{field}]"));

        public string GetTextAlert() => Driver.SwitchTo().Alert().Text;

        public IWebElement NameValue(int row) => Driver.FindElement(By.XPath($"//*[@class='tableFixHead']//tbody/tr[{row}]/td[1]"));

        public IWebElement PositionValue(int row) => Driver.FindElement(By.XPath($"//*[@class='tableFixHead']//tbody/tr[{row}]/td[2]"));

        public IWebElement PriceValue(int row) => Driver.FindElement(By.CssSelector($"#product[name ='courses'] > tbody > tr:nth-child({row}) > td:nth-child(3)"));

        public void ScrollUntil(IWebElement element)
        {
            Builder.MoveToElement(element);
            Builder.Perform();
        }

        public IWebElement SuggestionClassExampleSelector(string field) => Driver.FindElement(By.XPath($"//ul/li/div[.='{field}']"));

        public void SwichToDefault() => Driver.SwitchTo().DefaultContent();

        public void SwitchToFirst() => Driver.SwitchTo().Window(Driver.WindowHandles.First());

        public void SwitchToFrame(IWebElement Iframe) => Driver.SwitchTo().Frame(Iframe);

        public void SwitchToLast() => Driver.SwitchTo().Window(Driver.WindowHandles.Last());

        public void SwitchToOriginalWindowsTab(string originalWindow) => Driver.SwitchTo().Window(originalWindow);

        public void TakeAScreenshot(string name)
        {
            Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();

            ss.SaveAsFile($"{Directory.GetCurrentDirectory()}\\{name}.png",
            ScreenshotImageFormat.Png);
        }
    }
}
