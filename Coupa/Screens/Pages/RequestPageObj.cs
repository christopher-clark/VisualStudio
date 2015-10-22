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

        [FindsBy(How = How.Id, Using = "requisition_header_filter")]
        IWebElement filt;
        #endregion

        #region Code
        public void filterBy(String filter)
        {
            SelectElement se = new SelectElement(filt);
            se.SelectByText(filter);
        }

        public void testDropdown()
        {
            // Anchor to header of View part of Screen
            // Assign anchor to a Select WebElement then grab the Options into a List
            SelectElement se = new SelectElement(filt);
            List<IWebElement> selects = se.Options.ToList();
            // Iterate through the available Options
            foreach (var dropdowns in selects)
            {
                dropdowns.Click();
                Thread.Sleep(1000);
            }
        }
               
    #endregion
    #region Snapshot
    protected override void snapshot() { }
        #endregion
        #region 

        public RequestPageObj(IWebDriver w)
        {
            Driver = w;
            PageFactory.InitElements(w, this);
        }
        #endregion
    }
}
