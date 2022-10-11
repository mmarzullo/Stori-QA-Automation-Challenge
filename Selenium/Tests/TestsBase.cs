using System;
using StoriTest.Selenium.Driver;

namespace StoriTest.Classes
{
    public abstract class TestsBase : IDisposable
    {
        protected TestsBase() => Driver.StartBrowser();

        public void Dispose() => Driver.StopBrowser();
    }
}
