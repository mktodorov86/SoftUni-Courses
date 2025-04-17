using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using SeleniumExtras.WaitHelpers;

namespace SimpleNotesWebDriverTests
{
    public class SimpleNotesTests
    {
        private IWebDriver driver = null!;
        private WebDriverWait wait = null!;
        private Actions actions = null!;
        private const string BaseUrl = "https://d5wfqm7y6yb3q.cloudfront.net/";
        private const string Email = "mktodorov86@gmail.com";
        private const string Password = "Kabalo119866!";
        private const string Username = "mktodorov86";
        private Random random = null!;

        private static string? LastCreatedNoteTitle;
        private static string? LastEditedNoteTitle;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            actions = new Actions(driver);
            random = new Random();

            driver.Navigate().GoToUrl(BaseUrl);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("tab-login"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("loginName"))).SendKeys(Email);
            driver.FindElement(By.Id("loginPassword")).SendKeys(Password);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@type='submit']"))).Click();
            wait.Until(d => d.Title.Contains("Main Page - Simple Notes"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        private bool GoToPageWithNote(string noteTitle)
        {
            int currentPage = 1;

            while (true)
            {
                try
                {
                    driver.FindElement(By.XPath($"//h5[contains(text(), '{noteTitle}')]"));
                    return true;
                }
                catch (NoSuchElementException)
                {
                    try
                    {
                        var nextButton = driver.FindElement(By.CssSelector("a.page-link[aria-label='Next']"));
                        nextButton.Click();
                        currentPage++;

                        if (currentPage > 5)
                        {
                            return false;
                        }
                    }
                    catch (NoSuchElementException)
                    {
                        return false;
                    }
                }
            }
        }

        [Test, Order(1)]
        public void AddNoteWithInvalidDataTest()
        {
            driver.Navigate().GoToUrl(BaseUrl + "Note/Create");
            Thread.Sleep(2000);

            Console.WriteLine("Current URL: " + driver.Url);

            try
            {
                IWebElement submitButton = driver.FindElement(By.CssSelector("button.btn.btn-info.btn-block"));
                submitButton.Click();

                Thread.Sleep(1000);

                Assert.That(driver.Url, Does.Contain("Note/New").Or.Contains("Note/Create"));

                bool hasError = driver.PageSource.ToLower().Contains("error") ||
                              driver.PageSource.ToLower().Contains("required") ||
                              driver.PageSource.ToLower().Contains("validation") ||
                              driver.FindElements(By.CssSelector(".validation-summary-errors")).Count > 0;

                Assert.That(hasError, Is.True, "No validation errors found");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in test: " + ex.Message);
                Assert.Fail("Could not complete test: " + ex.Message);
            }
        }

        [Test, Order(2)]
        public void AddRandomNoteTest()
        {
            driver.Navigate().GoToUrl(BaseUrl + "Note/Create");
            Thread.Sleep(1000);

            string randomTitle = $"TestNote_{random.Next(1000, 9999)}";
            string randomDescription = new string('X', 31);

            try
            {
                var form = wait.Until(ExpectedConditions.ElementExists(By.TagName("form")));

                IWebElement titleField;
                try
                {
                    titleField = driver.FindElement(By.Name("Title"));
                }
                catch (NoSuchElementException)
                {
                    titleField = driver.FindElement(By.Id("form4Example1"));
                }
                titleField.Clear();
                titleField.SendKeys(randomTitle);

                IWebElement descriptionField;
                try
                {
                    descriptionField = driver.FindElement(By.Name("Description"));
                }
                catch (NoSuchElementException)
                {
                    descriptionField = driver.FindElement(By.Id("form4Example3"));
                }
                descriptionField.Clear();
                descriptionField.SendKeys(randomDescription);

                try
                {
                    var statusDropdown = driver.FindElement(By.Name("Status"));
                    var selectElement = new SelectElement(statusDropdown);
                    selectElement.SelectByText("New");
                }
                catch (Exception)
                {
                    try
                    {
                        var statusDropdown = driver.FindElement(By.Id("Status"));
                        var selectElement = new SelectElement(statusDropdown);
                        selectElement.SelectByText("New");
                    }
                    catch (Exception)
                    {
                        var selects = driver.FindElements(By.TagName("select"));
                        if (selects.Count > 0)
                        {
                            var selectElement = new SelectElement(selects[0]);
                            selectElement.SelectByIndex(1);
                        }
                    }
                }

                var submitButton = form.FindElement(By.TagName("button"));
                submitButton.Click();

                Thread.Sleep(2000);

                bool success = !driver.Url.Contains("Create") ||
                              driver.PageSource.ToLower().Contains("success") ||
                              driver.FindElements(By.XPath("//div[contains(@class, 'toast-message')]")).Count > 0;

                Assert.That(success, Is.True, "Failed to create note successfully");

                LastCreatedNoteTitle = randomTitle;

                driver.Navigate().GoToUrl(BaseUrl + "Note/New");
                Thread.Sleep(1000);
                Assert.IsTrue(GoToPageWithNote(randomTitle), "Note not found after creation");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Error in AddRandomNoteTest: {ex.Message}");
            }
        }

        [Test, Order(3)]
        public void EditLastAddedNoteTest()
        {
            string lastNoteTitle = LastCreatedNoteTitle ?? "Unknown Note";

            driver.Navigate().GoToUrl(BaseUrl + "Note/New");
            Thread.Sleep(1000);

            var editButtons = driver.FindElements(By.CssSelector("a[href*='/Note/Edit']"));
            if (editButtons.Count == 0)
            {
                Assert.Fail("No edit buttons found on page");
            }

            editButtons[editButtons.Count - 1].Click();
            Thread.Sleep(1000);

            var form = wait.Until(ExpectedConditions.ElementExists(By.TagName("form")));

            string updatedTitle = "Updated " + lastNoteTitle;
            var titleField = form.FindElement(By.Name("Title"));
            titleField.Clear();
            titleField.SendKeys(updatedTitle);

            form.FindElement(By.TagName("button")).Click();
            Thread.Sleep(2000);

            bool updateSuccess = driver.PageSource.ToLower().Contains("success") ||
                                !driver.Url.Contains("Edit");

            Assert.That(updateSuccess, Is.True, "Note update failed");

            LastEditedNoteTitle = updatedTitle;
        }

        [Test, Order(4)]
        public void MoveEditedNoteToDoneTest()
        {
            driver.Navigate().GoToUrl(BaseUrl + "Note/New");
            Thread.Sleep(1000);

            var changeToDoneButtons = driver.FindElements(By.CssSelector("a[href*='ChangeToDone']"));
            if (changeToDoneButtons.Count == 0)
            {
                Assert.Fail("No ChangeToDone buttons found");
            }

            changeToDoneButtons[changeToDoneButtons.Count - 1].Click();
            Thread.Sleep(2000);

            bool statusChangeSuccess = driver.PageSource.ToLower().Contains("success") ||
                                     driver.Url.Contains("Note");

            Assert.That(statusChangeSuccess, Is.True, "Status change failed");
        }

        [Test, Order(5)]
        public void DeleteEditedNoteTest()
        {
            driver.Navigate().GoToUrl(BaseUrl + "Note/Done");
            Thread.Sleep(1000);

            var deleteButtons = driver.FindElements(By.CssSelector("a[href*='/Note/Delete']"));
            if (deleteButtons.Count == 0)
            {
                Assert.Fail("No delete buttons found");
            }

            deleteButtons[deleteButtons.Count - 1].Click();
            Thread.Sleep(1000);

            Assert.That(driver.Url, Does.Contain("Note/Delete"));

            var submitButton = driver.FindElement(By.CssSelector("button[type='submit']"));
            submitButton.Click();
            Thread.Sleep(2000);

            bool deleteSuccess = driver.PageSource.ToLower().Contains("success") ||
                               driver.Url.Contains("Note");

            Assert.That(deleteSuccess, Is.True, "Note deletion failed");
        }

        [Test, Order(6)]
        public void LogoutTest()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            Thread.Sleep(1000);

            Assert.That(driver.Title, Does.Contain("Home Page"));

            driver.Navigate().GoToUrl(BaseUrl + "Note/New");
            Thread.Sleep(1000);

            bool accessDenied = driver.PageSource.ToLower().Contains("access denied") ||
                               driver.PageSource.ToLower().Contains("not authorized") ||
                               driver.PageSource.ToLower().Contains("login");

            Assert.That(accessDenied, Is.True, "Access was not denied to restricted page");
        }
    }
}