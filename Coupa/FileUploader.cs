using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Coupa
{
    class FileUploader
    {
        private static String uploadLocation = "http://ar-devwmis01:5200/invoke/auEnterpriseTm1.schedulers:transferBudget";

        public void startBrowser()
        {
            FirefoxDriver w = new FirefoxDriver();
            // Added Comment
            w.Url = uploadLocation;
            w.Manage().Window.Maximize();
            Thread.Sleep(5000);
            w.Quit();
        }

    }
}
