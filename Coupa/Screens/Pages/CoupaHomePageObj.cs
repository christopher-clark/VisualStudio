using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Screens.Pages;

namespace Screens.Pages
{
    class CoupaHomePageObj : BasePage
    {

         #region Findsby
        [FindsBy(How = How.ClassName, Using = "primary")]
        IList<IWebElement> pageMenu;

        [FindsBy(How = How.Id, Using = "//*[@id='topNav']/text()")]
        IWebElement user;
        
        [FindsBy(How = How.Id, Using = "user_login")]
        IWebElement userName;

        [FindsBy(How = How.Id, Using = "user_password")]
        IWebElement pwd;

        [FindsBy(How = How.XPath, Using = "//*[@id='login_form']/button/span")]
        IWebElement signIn;

        public IWebDriver Driver { get; private set; }
        #endregion

        #region Methods
        public void login(String username, String password)
        {
            userName.SendKeys(username);
            pwd.SendKeys(password);
        }
        public void signin()
        {
            signIn.Click();
        }
       
        // Select Top level menu option
        public void navigateToPage(IWebDriver w, String option)
        {
            w.FindElement(By.PartialLinkText(option)).Click();
        }
        public void closeBrowser(IWebDriver w)
        {
            w.Quit();
        }
        #endregion
        #region Snapshot
        protected override void snapshot() { }
        #endregion
        #region Init
        public CoupaHomePageObj(IWebDriver w)
        {
            Driver = w;
            PageFactory.InitElements(w, this);
        }
        #endregion
    }
}
