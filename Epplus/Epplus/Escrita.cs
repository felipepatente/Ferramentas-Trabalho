using OfficeOpenXml;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Epplus
{
    public class Escrita
    {
        private List<string> GetCabecalho()
        {
            List<string> cabecalhos = new List<string>()
            {
                "Telefone",
                "Valor",
                "Conta",
                "Transação"
            };

            return cabecalhos;
        }

        public void Processar()
        {
            string diretorio = ConfigurationManager.AppSettings["diretorioExcel"].ToString();

            FileInfo caminhoNomeArquivo = new FileInfo(diretorio);
            ExcelPackage excelPack = new ExcelPackage(caminhoNomeArquivo);

            ExcelWorksheet planilha = excelPack.Workbook.Worksheets[0];
            
            List<string> cabecalhos = GetCabecalho();

            int linha = 1;
            
            for (int coluna = 1; coluna <= cabecalhos.Count; coluna++)
            {                
                planilha.Cells[linha, coluna].Style.Font.Size = 13;
                planilha.Cells[linha, coluna].Style.Font.Bold = true;

                planilha.Cells[linha, coluna].Value = cabecalhos[coluna - 1];
            }

            List<SMS> sms = new ListaSMS().GetListaSMS();

            for (int coluna = 2; coluna <= sms.Count + 1; coluna++)
            {
                planilha.Cells[coluna, 1].Value = sms[coluna - 2].Telefone;
                planilha.Cells[coluna, 2].Value = sms[coluna - 2].Valor;
                planilha.Cells[coluna, 3].Value = sms[coluna - 2].Conta;
                planilha.Cells[coluna, 4].Value = sms[coluna - 2].Transacao;
                
            }

            //Pegando a ultima linha preenchida do excel
            var wb = excelPack.Workbook;
            var ws = wb.Worksheets.FirstOrDefault();
            int lastRows = ws.Dimension.Rows;

            //salvando e fechando o arquivo
            excelPack.Save();
            excelPack.Dispose();

        }
    }
}
