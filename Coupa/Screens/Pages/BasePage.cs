using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Screens.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Screens.Pages
{
    public abstract class BasePage : Base
    {
        #region Properties
        List<IWebElement> Header { get; set; }
        List<IWebElement> Footer { get; set; }
        #endregion
    
    }
}
