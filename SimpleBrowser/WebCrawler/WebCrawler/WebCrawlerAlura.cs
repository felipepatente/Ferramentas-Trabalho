using SimpleBrowser;

namespace WebCrawler
{
    public class WebCrawlerAlura
    {
        public void Processar()
        {
            var b = new Browser();
            b.Navigate("https://www.alura.com.br");

            var html = b.CurrentHtml;

            var url = "https://cursos.alura.com.br/loginForm";

            b.Navigate(url);
            b.BasicAuthenticationLogin(url, "felipepatente2016@gmail.com", "bfef48f6");

            html = b.CurrentHtml;

            var login = b.Find("login-email");
            login.Value = "felipepatente2016@gmail.com";

            var senha = b.Find("password");
            senha.Value = "bfef48f6";

            var btnEntrar = b.Find(ElementType.Button, FindBy.Class, "btn-login");
            btnEntrar.Click();

            html = b.CurrentHtml;

            var elementosDesktop = b.Find("section", FindBy.Class, "headerBusca-desktop");

            var procurar = elementosDesktop.Select("#headerBusca-campoBusca");
            procurar.Value = "Cursos de Java";

            var btnProcurar = elementosDesktop.Select(".headerBusca-submit");
            btnProcurar.Click();

            html = b.CurrentHtml;
        }
    }
}
