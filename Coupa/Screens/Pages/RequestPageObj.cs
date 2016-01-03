using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Screens.Pages
{
    class RequestPageObj : BasePage
    {
        public IWebDriver Driver { get; private set; }

        #region Findsby
        [FindsBy(How = How.ClassName, Using = "primary")]
        IList<IWebElement> pageMenu;
        #endregion

        #region Code
                    
        #endregion
        #region Snapshot
        protected override void snapshot() { }
        #endregion
        #region Constructor

        public RequestPageObj(IWebDriver w)
        {
            Driver = w;
            PageFactory.InitElements(w, this);
        }
        #endregion
    }
}
