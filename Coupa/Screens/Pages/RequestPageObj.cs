using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Screens.Pages;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Coupa.Screens.Pages
{
    class RequestPageObj : BasePage
    {
        public IWebDriver Driver { get; private set; }

        #region Findsby
        [FindsBy(How = How.ClassName, Using = "primary")]
        IList<IWebElement> pageMenu;

        [FindsBy(How = How.XPath, Using = "//*[@id='requisition_header_filter")]
        IWebElement filter;
        #endregion

        #region Code
        // Select Top level menu option
        public void selectReqOption(IWebDriver w, String option)
        {
            w.FindElement(By.LinkText(option)).Click();
        }
        // Select filter dropdown
        public void selectFilter(String option)
        {
            SelectElement se;
        }
        #endregion
        #region Snapshot
        protected override void snapshot() { }
        #endregion
        #region Init
        public RequestPageObj(IWebDriver w)
        {
            Driver = w;
            PageFactory.InitElements(w, this);
        }
        #endregion
    }
}
