using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.IO;
using System.Reflection;
using System.Threading;

namespace SeleniumCursoPratica
{
    public class SiteAlura
    {
        public void Processar()
        {
            //IWebDriver driver = new InternetExplorerDriver();
            //Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)

            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            IWebDriver driver = new InternetExplorerDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);

            driver.Navigate().GoToUrl("https://www.alura.com.br/");

            Thread.Sleep(9000);
            var pesquisar = driver.FindElement(By.Id("header-barraBusca-form-campoBusca"));
            pesquisar.SendKeys("Java");

            var botao = driver.FindElement(By.TagName("button"));
            botao.Click();

            var valores = driver.FindElements(By.ClassName("footer_categorias_categoria"));

            foreach (var valor in valores)
            {
                System.Console.WriteLine(valor.Text);
            }

            Thread.Sleep(8000);

            driver.Quit();
        }
    }
}
