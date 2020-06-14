using OpenQA.Selenium;
using SimpleBrowser.WebDriver;

namespace SeleniumCursoPratica
{
    public class AcessoInstagram
    {
        public void Processar()
        {
            using (IWebDriver driver = new SimpleBrowserDriver())
            {
                driver.Navigate().GoToUrl("https://www.alura.com.br/");
                
                var html = driver.PageSource;

                driver.FindElement(By.ClassName("header__nav__link--entrar--home")).Click();
                
                html = driver.PageSource;

                driver.Quit();
            }
        }
    }
}
