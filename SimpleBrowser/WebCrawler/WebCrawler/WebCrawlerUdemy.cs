using SimpleBrowser;
using System.Collections.Generic;

namespace WebCrawler
{
    public class WebCrawlerUdemy
    {
        public void Processar()
        {
            var b = new Browser();
            b.Navigate("https://www.udemy.com/");

            var html = b.CurrentHtml;

            var btnFazerLogin = b.Find(ElementType.Button, FindBy.Class, "btn-quaternary");
            btnFazerLogin.Click();

            html = b.CurrentHtml;

            var url = "https://www.udemy.com/join/login-popup/?locale=pt_BR&response_type=json&next=https%3A%2F%2Fwww.udemy.com%2F&ref=&xref=&display_type=popup";
            
            b.Navigate(url);
            b.BasicAuthenticationLogin(url, "felipepatente@yahoo.com.br", "46692201!@ASDFasdf");

            html = b.CurrentHtml;

            var login = b.Find("id_email");
            login.Value = "felipepatente@yahoo.com.br";

            var senha = b.Find("id_password");
            senha.Value = "46692201!@ASDFasdf";

            var btnEntrar = b.Find("submit-id-submit");
            btnEntrar.Click();

            b.Navigate("https://www.udemy.com/");

            html = b.CurrentHtml;

            var campoPesquisa = b.Find("header-search-field");
            campoPesquisa.Value = "C#";
            
            var pesquisarCursos = b.Find("span", FindBy.Class, "udi-search");
            pesquisarCursos.Click();

            html = b.CurrentHtml;

            b.Navigate("https://www.udemy.com/courses/search/?src=ukw&q=C#");

            html = b.CurrentHtml;

            b.Navigate("https://www.udemy.com/api-2.0/search-courses/?fields[locale]=simple_english_title&src=ukw&q=C#");

            html = b.CurrentHtml;

            string jsonTitulo = b.CurrentHtml.ToJson();
            jsonTitulo = jsonTitulo.Replace("published_title", "*");
            string[] titulos = jsonTitulo.Split('*');

            List<string> titulosCurso = new List<string>();

            foreach (var titulo in titulos)
            {
                string conteudoCurso = titulo.Replace("\\\":\\\"", "");
                int finalString = conteudoCurso.IndexOf("\\\"");

                if (finalString > 0)
                {
                    string curso = conteudoCurso.Substring(0, finalString);

                    if (curso.Length > 2)
                    {
                        titulosCurso.Add(curso);
                    }
                }                
            }

            foreach (var titulo in titulosCurso)
            {
                System.Console.WriteLine(titulo);
            }
        }
    }
}