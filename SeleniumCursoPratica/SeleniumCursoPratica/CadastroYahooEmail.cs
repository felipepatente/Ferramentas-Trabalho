using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System;

namespace SeleniumCursoPratica
{
    public class CadastroYahooEmail
    {
        public void Processar()
        {
            using (var driver = new SimpleBrowserDriver())
            {
                driver.Navigate().GoToUrl("https://login.yahoo.com/account/create?lang=pt-BR&done=https%3A%2F%2Fmail.yahoo.com%2F%3F.lang%3Dpt-BR%26guce_referrer%3DaHR0cHM6Ly93d3cuZ29vZ2xlLmNvbS8%26guce_referrer_sig%3DAQAAAIL9JPUXgS9Z7gg7DPbuV7GdBpIr7a5av0ZzRWU61T-OLQOVNRK1kQlRyW5Gr7pKtctATO1D5r984AvglM5bjqE-UWAgNtEb_CmPmXkozHZcksEynFCuPjuy5RGk9l11YX7DQJ34lZGPS5iB5Ll3Uokc6Qvm4YQEj_NWRtCBXGby&src=ym&specId=yidReg");

                var html = driver.PageSource;

                var firstName = driver.FindElement(By.Id("usernamereg-firstName"));
                firstName.SendKeys("Roberto");

                var lastName = driver.FindElement(By.Id("usernamereg-lastName"));
                lastName.SendKeys("Patente");

                var usuarioID = driver.FindElement(By.Id("usernamereg-yid"));
                usuarioID.SendKeys("Patente2020");

                var senha = driver.FindElement(By.Id("usernamereg-password"));
                senha.SendKeys("46692201!@ASDasd");

                var telefone = driver.FindElement(By.Id("usernamereg-phone"));
                telefone.SendKeys("11958803873");

                var mesNascimento = driver.FindElement(By.Id("usernamereg-month"));
                mesNascimento.SendKeys("3");

                var diaNascimento = driver.FindElement(By.Id("usernamereg-day"));
                diaNascimento.SendKeys("26");

                var anoNascimento = driver.FindElement(By.Id("usernamereg-year"));
                anoNascimento.SendKeys("1993");

                var btnCadastrar = driver.FindElement(By.Id("reg-submit-button"));
                btnCadastrar.Click();

                html = driver.PageSource;

            }
        }
    }
}
