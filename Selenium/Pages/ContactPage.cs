using System;
using System.IO;
using System.Linq;
using System.Threading;
using Selenium.Pages;
using StoriTest.Locators;
using Xunit;
using Xunit.Abstractions;

namespace StoriTest.Selenium.Pages
{
    public class StoriPage : BasePage
    {
        private readonly StoriLocator _storiLocators;

        public StoriPage()
        {
            _storiLocators = new StoriLocator();
        }

        public static void DeleteFile(string fileName)
        {
            try
            {
                File.Delete(Directory.GetFiles(Directory.GetCurrentDirectory(), fileName)[0]);
            }
            catch (Exception)
            {
                return;
            }
        }

        public void VerifyDropdownExample()
        {
            _storiLocators.DropDownExample.Click();
            Thread.Sleep(200);
            _storiLocators.DropDownExampleSelect(3).Click();
            Thread.Sleep(200);
            _storiLocators.DropDownExample.Click();

            Thread.Sleep(500);

            Assert.Equal("option2", _storiLocators.DropDownExample.GetAttribute("value"));

            _storiLocators.DropDownExample.Click();
            Thread.Sleep(200);
            _storiLocators.DropDownExampleSelect(4).Click();
            Thread.Sleep(200);
            _storiLocators.DropDownExample.Click();

            Thread.Sleep(500);

            Assert.Equal("option3", _storiLocators.DropDownExample.GetAttribute("value"));
        }

        public void VerifyIFrame(ITestOutputHelper _output)
        {
            _storiLocators.SwitchToFrame(_storiLocators.iFrameExample);

            var text = _storiLocators.iFrameTxt.Text;

            _storiLocators.SwichToDefault();

            _output.WriteLine("- Text:");
            _output.WriteLine(text);

            _output.WriteLine("- Odd indexes Text:");

            var result = string.Concat(text.Where((c, i) => i % 2 == 1));

            _output.WriteLine(result);
        }

        public void VerifyIndexPage()
        {
            Assert.True(_storiLocators.Title.Displayed);
            Assert.Equal("Practice Page", _storiLocators.Title.Text);
            VerifyPageUrl();
        }

        public void VerifySuggessionClassExample()
        {
            _storiLocators.SuggestionClassExample.SendKeys("me");
            _storiLocators.SuggestionClassExampleSelector("Mexico").Click();

            Assert.Equal("Mexico", _storiLocators.SuggestionClassExample.GetAttribute("value"));
        }

        public void VerifySwichAlertButton(ITestOutputHelper _output)
        {
            var storiCard = "Stori Card";
            _storiLocators.AlertInput.SendKeys(storiCard);
            _storiLocators.AlertBtn.Click();

            Assert.Equal($"Hello {storiCard}, share this practice page and share your knowledge",
                _storiLocators.GetTextAlert());

            _output.WriteLine($"Alert: {_storiLocators.GetTextAlert()}");

            _storiLocators.AcceptAlert();

            _storiLocators.AlertInput.SendKeys("Stori Card");
            _storiLocators.ConfirmBtn.Click();

            Assert.Equal($"Hello {storiCard}, Are you sure you want to confirm?",
                _storiLocators.GetTextAlert());

            _output.WriteLine($"Alert: {_storiLocators.GetTextAlert()}");

            _storiLocators.AcceptAlert();
        }

        public void VerifySwitchTabExample()
        {
            _storiLocators.OpenTabBtn.Click();
            _storiLocators.SwitchToLast();
            Thread.Sleep(600);
            _storiLocators.ScrollUntil(_storiLocators.ABtn("VIEW ALL COURSES"));

            Assert.True(_storiLocators.ABtn("VIEW ALL COURSES").Displayed);

            Thread.Sleep(500);
            DeleteFile("Task 5");
            _storiLocators.TakeAScreenshot("Task 5");
            _storiLocators.SwitchToFirst();
        }

        public void VerifySwitchWindowExample()
        {
            string mainWindow = _storiLocators.CurrentTab();

            _storiLocators.OpenWindowBtn.Click();
            _storiLocators.SwitchToLast();

            Assert.Equal("30 DAY MONEY BACK GUARANTEE", _storiLocators.ThirtyDayTitleTxt.Text);
            Assert.True(_storiLocators.ThirtyDayTitleTxt.Displayed);

            _storiLocators.Close();
            _storiLocators.SwitchToOriginalWindowsTab(mainWindow);
        }

        public void VerifyWebTableExample(ITestOutputHelper _output)
        {
            var count = 0;
            var courses = "";

            for (int r = 2; r <= (_storiLocators.WebTableExampleList.Count); r++)
            {
                if (_storiLocators.PriceValue(r).Text.Contains("25"))
                {
                    count++;
                    courses += _storiLocators.CourseValue(r).Text + Environment.NewLine;
                }
            }

            _output.WriteLine($"- Number of courses: {count}");
            _output.WriteLine("- Course names:");
            _output.WriteLine(courses);
        }

        public void VerifyWebTableFixedHeader(ITestOutputHelper _output)
        {
            for (int r = 1; r < (_storiLocators.WebTableFixedHeaderList.Count); r++)
            {
                if (_storiLocators.PositionValue(r).Text.Contains("Engineer"))
                {
                    _output.WriteLine($"- Engineer: {_storiLocators.NameValue(r).Text}");
                }
            }
        }
    }
}
