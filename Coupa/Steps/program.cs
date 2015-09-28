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
using Coupa.Screens.Pages;

namespace Coupa
{
    class program
    {
        private static List<String> pages = new String[] { "Requests", "Orders", "Invoices", "Inventory", "Sourcing", "Suppliers", "Items", "Reports", "Setup", "Home" }.ToList();

        static void Main(string[] args)
        {

            IWebDriver w;

            String username = "CCLark@australianunity.com.au";
            String password = "1Ev0st0r!";
            String coupaLogin = "https://australianunity-test.coupahost.com/sessions/support_login";

            w = new FirefoxDriver();
            w.Manage().Window.Maximize();
            w.Navigate().GoToUrl(coupaLogin);
            //List<IWebElement> pageMenu = w.FindElements(By.ClassName("inner")).ToList();
            //List<IWebElement> secondLevelMenu = w.FindElements(By.Id("secondary")).ToList();

            FileUploader fu = new FileUploader();
            CoupaPageObj cpo = new CoupaPageObj(w);
            
            cpo.login(username, password);
            cpo.signin();

            cpo.navigateToPage(w, "Requests");
            RequestPageObj rpo = new RequestPageObj(w);
            rpo.selectReqOption(w, "Other requests");
            Thread.Sleep(300);
            rpo.selectReqOption(w, "Requisitions");
            Thread.Sleep(300);
            rpo.selectReqOption(w, "Requisition Lines");
            Thread.Sleep(300);
            List<IWebElement> toolTable = w.FindElements(By.ClassName("toolbar")).ToList();


            Thread.Sleep(300);
            cpo.navigateToPage(w, "Orders");
            Thread.Sleep(300);
            cpo.navigateToPage(w, "Invoices");
            Thread.Sleep(300);
            cpo.navigateToPage(w, "Inventory");
            Thread.Sleep(300);
            cpo.navigateToPage(w, "Sourcing");
            Thread.Sleep(300);
            cpo.navigateToPage(w, "Suppliers");
            Thread.Sleep(300);
            cpo.navigateToPage(w, "Items");
            Thread.Sleep(300);
            cpo.navigateToPage(w, "Reports");
            Thread.Sleep(300)
            Thread.Sleep(300);
            cpo.navigateToPage(w, "Setup");
            Thread.Sleep(300);
            cpo.closeBrowser(w);
        }
    }
}
