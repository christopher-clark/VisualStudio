using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using System.Collections;
using Screens.Pages;
using OpenQA.Selenium.Support.UI;


namespace Coupa
{
    class program
    {
        private static List<String> pages = new String[] { "Home", "Requests", "Orders", "Invoices", "Inventory", "Sourcing", "Suppliers", "Items", "Reports", "Setup" }.ToList();
        
        static void Main(string[] args)
        {
            IWebDriver w;
           
            String username = "cclark@australianunity.com.au";
            String password = "1Ev0st0r!";
            String sideDoor = "https://australianunity.coupahost.com/sessions/support_login";
            String coupaLogin = "https://australianunity.coupahost.com";

            w = new FirefoxDriver();
            w.Manage().Window.Maximize();
            //w.Navigate().GoToUrl(login);
            w.Navigate().GoToUrl(sideDoor);
           
            CoupaHomePageObj cpo = new CoupaHomePageObj(w);
            cpo.login(username, password);
            cpo.signin();

            IList<IWebElement> pageMenu = cpo.pagesMenu().ToList();
            
            cpo.navigateToPage(w, "Invoices");
                               
            cpo.expandTable();
            cpo.sortInvoices();

            
            IList<String> headers = cpo.header();
            IList<IWebElement> body = cpo.body();
                        
            //foreach (var menu in pages)
            //{
            //    cpo.navigateToPage(w, menu);
            //    Thread.Sleep(300);
            //    if ((!menu.Equals("Home")) && (!menu.Equals("Reports")) && (!menu.Equals("Setup")))
            //    {
            //        cpo.testDropdown();
            //    }
            //}

            cpo.closeBrowser(w);
        }
    }
}
