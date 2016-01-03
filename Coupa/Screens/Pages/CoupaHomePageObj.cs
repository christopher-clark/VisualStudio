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
using OpenQA.Selenium.Support.UI;

namespace Screens.Pages
{
    class CoupaHomePageObj : BasePage
    {
        public IWebDriver Driver { get; private set; }
        public WebDriverWait Wait { get; set; }

        #region Findsby
        [FindsBy(How = How.Id, Using = "//*[@id='topNav']/text()")]
        IWebElement user;
        
        [FindsBy(How = How.Id, Using = "user_login")]
        IWebElement userName;

        [FindsBy(How = How.Id, Using = "user_password")]
        IWebElement pwd;

        [FindsBy(How = How.XPath, Using = "//*[@id='login_form']/button/span")]
        IWebElement signIn;

        [FindsBy(How = How.Id, Using = "invoice_header_expand")]
        IWebElement expand;

        [FindsBy(How = How.ClassName, Using = "next_page")]
        IWebElement nextPage;

        [FindsBy(How = How.ClassName, Using = "primary")]
        IList <IWebElement> pageMenu;
      
        [FindsBy(How = How.XPath, Using = "//*[@id='invoice_header_table_tag']")]
        IList<IWebElement> invoiceHeaderandBody;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='invoice_header_table_tag']/thead")]
        IList <IWebElement> invoiceTableHeader;

        [FindsBy(How = How.XPath, Using = "//*[@id='invoice_header_tbody']")]
     //   [FindsBy(How = How.XPath, Using = "//*[@id='invoice_header_table_tag']/tbody")]
        IList <IWebElement> invoiceTableBody;

        //*[@id="invoice_header_tbody"]
        [FindsBy(How = How.XPath, Using = "//*[@id='ch_invoice_number']")]
        IWebElement invoiceButton;


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
        public void expandTable()
        {
            expand.Click();
        }
        public void sortInvoices()
        {
            invoiceButton.Click();
        }
        public void getNextPage()
        {
            nextPage.Click();
        }
        public IList<IWebElement> pagesMenu()
        {
            return pageMenu;
        }
        public IList<IWebElement> invTableHeader()
        {
            return invoiceTableHeader;
        }
        public IList<IWebElement> invTableBody()
        {
            return invoiceTableBody;
        }
        public IList<IWebElement> invHeadandBody()
        {
            return invoiceHeaderandBody;
        }

        public List<IWebElement> body() {

            List<IWebElement> bodyList = new List<IWebElement>();
            // element contains all of the rows of the Table body
            foreach (var element in invoiceTableBody)
            {
                // trlist contains an array[0]-[89] rows of data when foreach loop is entered
                List<IWebElement> rowList = element.FindElements(By.TagName("tr")).ToList();
                foreach (var row in rowList)
                {
                  //  Thread.Sleep(200);
                    List<IWebElement> dataList = row.FindElements(By.TagName("td")).ToList();
                    // cell is the element in the row
                    foreach (var cell in dataList)
                    {
                        cell.GetAttribute("td");
                      //  bodyList.Add(cell.Text);
                    }
                    
                }
            }
            return bodyList;
        }
        public List<String> header() {

            List<String> headerList = new List<String>();
            
            // foreach (var element in invoiceTableBody)
            // element has - Invoice # Supplier Created By Created Date Payment Due Date Total With Taxes 
            // Status Invoice Source Delivery Method Supplier Default Commodity Unanswered Comments Actions
            foreach (var element in invoiceTableHeader)
            {   // trList is a list of [0] has - Invoice # Supplier Created By Created Date Payment Due Date Total With Taxes 
                // Status Invoice Source Delivery Method Supplier Default Commodity Unanswered Comments Actions
                List<IWebElement> rowList = element.FindElements(By.TagName("tr")).ToList();
                foreach (var row in rowList)
                {                         
                    List<IWebElement> headingList = row.FindElements(By.TagName("th")).ToList();
                    foreach (var heading in headingList)
                    {
                         headerList.Add(heading.Text);
                 //        heading.Click();
                    }
                }
            }
            return headerList;
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
