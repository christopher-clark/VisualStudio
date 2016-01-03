using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Screens.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Screens.Pages
{
    public abstract class BasePage : Base
    {
        #region Properties
        List<IWebElement> Header { get; set; }
        List<IWebElement> Footer { get; set; }
        #endregion

        #region Selectors
      //  [FindsBy(How = How.Id, Using = "requisition_header_filter")]
        [FindsBy(How = How.Name, Using = "filter")]
        IWebElement filters;
        #endregion

        #region Code
        public void filterBy(String filter)
        {
            SelectElement se = new SelectElement(filters);
            se.SelectByText(filter);
        }

        public void testDropdown()
        {
            // Anchor to header of View part of Screen
            // Assign anchor to a Select WebElement then grab the Options into a List
            SelectElement se = new SelectElement(filters);
            List<IWebElement> selects = se.Options.ToList();

            // Iterate through the available Options
            foreach (var dropdowns in selects)
            {
                dropdowns.Click();
                Thread.Sleep(1000);
            }
        }
        #endregion

    }
}
