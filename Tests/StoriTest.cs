using System.IO;
using StoriTest.Classes;
using StoriTest.Selenium.Pages;
using Xunit;
using Xunit.Abstractions;

namespace StoriTest
{
    public class StoriTest : TestsBase
    {
        private readonly StoriPage _storiPage;
        private readonly ITestOutputHelper _output;

        public StoriTest(ITestOutputHelper output)
        {
            _output = output;
            _storiPage = new StoriPage();
            _storiPage.Navigate();
        }

        [Fact(DisplayName = "Task 1")]
        public void Task1()
        {
            _storiPage.VerifyIndexPage();
        }

        [Fact(DisplayName = "Task 2")]
        public void Task2()
        {
            _storiPage.VerifySuggessionClassExample();
        }

        [Fact(DisplayName = "Task 3")]
        public void Task3()
        {
            _storiPage.VerifyDropdownExample();
        }

        [Fact(DisplayName = "Task 4")]
        public void Task4()
        {
            _storiPage.VerifySwitchWindowExample();
        }

        [Fact(DisplayName = "Task 5")]
        public void Task5()
        {
            _storiPage.VerifySwitchTabExample();
            _output.WriteLine($"The picture is saved on {Directory.GetCurrentDirectory()}\\Task 5.png");
        }

        [Fact(DisplayName = "Task 6")]
        public void Task6()
        {
            _storiPage.VerifySwichAlertButton(_output);
        }

        [Fact(DisplayName = "Task 7")]
        public void Task7()
        {
            _storiPage.VerifyWebTableExample(_output);
        }

        [Fact(DisplayName = "Task 8")]
        public void Task8()
        {
            _storiPage.VerifyWebTableFixedHeader(_output);
        }

        [Fact(DisplayName = "Task 9")]
        public void Task9()
        {
            _storiPage.VerifyIFrame(_output);
        }
    }
}