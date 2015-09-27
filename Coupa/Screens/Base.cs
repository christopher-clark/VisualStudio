using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Screens
{
    public abstract class Base
    {
        protected Dictionary<string, string> SnapShot = new Dictionary<string, string>();

        public Dictionary<string, string> Snapshot { get { return SnapShot; } }

        protected abstract void snapshot();

        static IWebDriver driver = null;
        public IWebDriver Driver
        {
            set
            {
                if (driver == null || !driver.Equals(value)) driver = value;
            }
            get
            {
                return driver;
            }
        }

    }
}