using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop_agendamento_procedimentos_esteticos
{
    class Texto
    {
        public string Caminho = Path.Combine(Environment.CurrentDirectory, "BancoDados.txt");
        public string Dados;

        public void Gravar()
        {
            StreamWriter arquivoTXT;

            if (Caminho == null)
            {
                arquivoTXT = File.CreateText(Caminho);
            }
            else
            {
                arquivoTXT = File.AppendText(Caminho);
            }

            arquivoTXT.WriteLine(Dados);
            arquivoTXT.Close();
        }


        public List<string>  LerArquivo()
        {
            StreamReader arquivoTXT;
            arquivoTXT = File.OpenText(Caminho);

            List<string> linhas = new List<string>();

            while (!arquivoTXT.EndOfStream)
            {
                string linha = arquivoTXT.ReadLine();
                linhas.Add(linha);
            }

            arquivoTXT.Close();

            return linhas;
        }

        public List<string> BuscarDados(string entrada)
        {
            StreamReader arquivoTXT;
            arquivoTXT = File.OpenText(Caminho);

            List<string> arquivo = new List<string>();

            while (!arquivoTXT.EndOfStream)
            {
                string linha = arquivoTXT.ReadLine();
                arquivo.Add(linha);
            }

            arquivoTXT.Close();

            List<string> busca = arquivo.FindAll(l => l.Contains(entrada));

            return busca;
        }
    }
}
