using OpenQA.Selenium;

namespace WebLetoBank.Utilities
{
    public class RegistrationHelper
    {
        public static void AcceptTermsButtonClick()
        {
            Browser.GetDriver().FindElement(By.XPath("//button[1]")).Click();
        }

        public static void ChooseRegistrationType(string RegistrationType)
        {
            if(RegistrationType == "account") 
                Browser.GetDriver().FindElement(By.XPath("//button[2]")).Click();
            if(RegistrationType == "card")
                Browser.GetDriver().FindElement(By.XPath("//button[1]")).Click(); ;
        }

        public static void EnterAccountCredentials(string AccountNumber, string AccessCode)
        {
            Browser.GetDriver().FindElement(By.Id("account")).Clear();
            Browser.GetDriver().FindElement(By.Id("account")).SendKeys(AccountNumber);
            Browser.GetDriver().FindElement(By.Id("accesscode")).Clear();
            Browser.GetDriver().FindElement(By.Id("accesscode")).SendKeys(AccessCode);
        }

        public static void EnterCardCredentials(string CardNumber, string AccessCode)
        {
            Browser.GetDriver().FindElement(By.Id("pan")).Clear();
            Browser.GetDriver().FindElement(By.Id("pan")).SendKeys(CardNumber);
            Browser.GetDriver().FindElement(By.Id("accesscode")).Clear();
            Browser.GetDriver().FindElement(By.Id("accesscode")).SendKeys(AccessCode);
        }

        public static void NextButtonClick()        {
            Browser.GetDriver().FindElement(By.XPath("//button[1]")).Click();
        }

        public static void ForgotAccessCodeButtonClick()
        {
            Browser.GetDriver().FindElement(By.XPath("//button[2]")).Click();
        }

        public static void EnterOTR(string otr)        {
            Browser.GetDriver().FindElement(By.Id("otp")).Clear();
            Browser.GetDriver().FindElement(By.Id("otp")).SendKeys(otr);
        }

        public static void EnterUsername(string username)
        {
            Browser.GetDriver().FindElement(By.Id("login")).Clear();
            Browser.GetDriver().FindElement(By.Id("login")).SendKeys(username);
        }

        public static void EnterPassword(string password, string passwordconfirmation)
        {
            Browser.GetDriver().FindElement(By.Id("password")).Clear();
            Browser.GetDriver().FindElement(By.Id("password")).SendKeys(password);
            Browser.GetDriver().FindElement(By.Id("passwordconfirmation")).Clear();
            Browser.GetDriver().FindElement(By.Id("passwordconfirmation")).SendKeys(passwordconfirmation);
        }

        public static void EnterProtectCode(string code, string codeconfirmation)
        {
            Browser.GetDriver().FindElement(By.Id("protectcode")).Clear();
            Browser.GetDriver().FindElement(By.Id("protectcode")).SendKeys(code);
            Browser.GetDriver().FindElement(By.Id("protectcodeconfirmation")).Clear();
            Browser.GetDriver().FindElement(By.Id("protectcodeconfirmation")).SendKeys(codeconfirmation);
        }

        public static void DismissProtectCodeButtonClick()        {
            Browser.GetDriver().FindElement(By.XPath("//button[2]")).Click();
        }
    }
}
