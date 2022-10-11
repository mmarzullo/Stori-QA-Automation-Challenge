using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using StoriTest.Shared;

namespace StoriTest.Selenium.Driver
{
    public static class Driver
    {
        private static IConfigurationRoot _configuration;
        private static WebDriverWait? _browserWait;
        private static IWebDriver? _webDriver;

        public static IWebDriver Browser
        {
            get
            {
                if (_webDriver == null)
                {
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method Start.");
                }

                return _webDriver;
            }
            private set
            {
                _webDriver = value;
            }
        }

        public static WebDriverWait BrowserWait
        {
            get
            {
                if (_browserWait == null || _webDriver == null)
                {
                    throw new NullReferenceException("The WebDriver browser wait instance was not initialized. You should first call the method Start.");
                }

                return _browserWait;
            }
            private set
            {
                _browserWait = value;
            }
        }

        private static IWebDriver GetChromeDriver()
        {
            ChromeOptions options = new();

            options.AddArguments(new List<string>()
            {
                "start-maximized"
            });
            options.AddUserProfilePreference("download.default_directory", Directory.GetCurrentDirectory());
            options.AddUserProfilePreference("intl.accept_languages", "nl");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("disable-popup-blocking", true);
            options.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddArguments("safebrowsing-disable-extension-blacklist");
            options.AddArgument("--window-size=1920,1080");
            options.AddUserProfilePreference("safebrowsing.enabled", true);

            if (_configuration["HeadlessMode"] == "True")
            {
                options.AddArgument("headless");
            }

            return new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, options);
        }

        private static IWebDriver GetFirefoxDriver()
        {
            FirefoxOptions options = new();

            options.AddArgument("--width=1920");
            options.AddArgument("--height=1080");
            options.AddArgument("--safebrowsing-disable-download-protection");
            options.AddArgument("safebrowsing-disable-extension-blacklist");
            options.SetPreference("browser.download.dir", Directory.GetCurrentDirectory());
            options.SetPreference("browser.download.downloadDir", Directory.GetCurrentDirectory());
            options.SetPreference("browser.download.defaultFolder", Directory.GetCurrentDirectory());
            options.SetPreference("browser.helperApps.alwaysAsk.force", false);
            options.SetPreference("browser.download.useDownloadDir", true);
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("pdfjs.disabled", true);
            options.SetPreference("plugin.scan.Acrobat", "99.0");
            options.SetPreference("plugin.scan.plid.all", false);
            options.SetPreference("download.prompt_for_download", false);
            options.SetPreference("download.directory_upgrade", true);
            options.SetPreference("safebrowsing.enabled", false);
            options.SetPreference("devtools.jsonview.enabled", false);

            if (_configuration["HeadlessMode"] == "True")
            {
                options.AddArgument("--headless");
            }

            return new FirefoxDriver(AppDomain.CurrentDomain.BaseDirectory, options, TimeSpan.FromMinutes(2));
        }

        private static IWebDriver GetSafariDriver() => new SafariDriver();

        public static void StartBrowser(int defaultTimeOut = 30, int defaultImplicitWait = 10)
        {
            _configuration = ConfigurationReader.GetInstance();

            var driverType = Environment.GetEnvironmentVariable("DriverType") ?? _configuration["DriverType"];

            Browser = (driverType) switch
            {
                "Chrome" => GetChromeDriver(),
                "Firefox" => GetFirefoxDriver(),
                "Safari" => GetSafariDriver(),
                string browser => throw new NotSupportedException($"{browser} is not a supported browser"),
                _ => throw new NotSupportedException("not supported browser: <null>"),
            };
            BrowserWait = new WebDriverWait(Browser, TimeSpan.FromSeconds(defaultTimeOut));

            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(defaultImplicitWait);
        }

        public static void StopBrowser()
        {
            Browser.Quit();
            Browser.Dispose();
            Browser = null;
            BrowserWait = null;
        }
    }
}
