using OpenQA.Selenium;

namespace WebLetoBank.Utilities
{
    public class AuthPageHelper
    {      

        public static void FillAuthenticationFields(string userName, string password)
        {
             Browser.GetDriver().FindElement(By.Id("username")).Clear();
             Browser.GetDriver().FindElement(By.Id("username")).SendKeys(userName);
             Browser.GetDriver().FindElement(By.Id("password")).Clear();
             Browser.GetDriver().FindElement(By.Id("password")).SendKeys(password);
        }

        public static void RegistrationButtonClick()
        {
            Browser.GetDriver().FindElement(By.XPath("//button[3]")).Click();
        }

        public static void Authentication(string userName, string password)
        {
            Browser.GetDriver().FindElement(By.Id("username")).Clear();
            Browser.GetDriver().FindElement(By.Id("username")).SendKeys(userName);
            Browser.GetDriver().FindElement(By.Id("password")).Clear();
            Browser.GetDriver().FindElement(By.Id("password")).SendKeys(password);
            Browser.GetDriver().FindElement(By.XPath("//button[1]")).Click();
        }

        public static void EnterButtonClick(){
            Browser.GetDriver().FindElement(By.XPath("//button[1]")).Click();
        }

        public static void ForgotLoginPasswordButtonClick(){
            Browser.GetDriver().FindElement(By.XPath("//button[2]")).Click();
        }

        public static void SetProtectCodeCheckboxClick()        {
            Browser.GetDriver().FindElement(By.Id("setprotectcode")).Click();
        }

    }
}
