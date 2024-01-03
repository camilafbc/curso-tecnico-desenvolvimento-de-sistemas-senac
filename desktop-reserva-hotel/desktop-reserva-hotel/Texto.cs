using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace desktop_reserva_hotel
{
    class Texto
    {
        public string Caminho = Path.Combine(Environment.CurrentDirectory, "BancoDeDados.txt");
        public string Dados;

        public void Gravar()
        {
            StreamWriter arquivoTXT;

            if (!File.Exists(Caminho))
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

        public List<string> LerArquivo()
        {
            List<string> linhas = new List<string>();

            if (File.Exists(Caminho))
            {
                StreamReader arquivoTXT;
                arquivoTXT = File.OpenText(Caminho);

                while (!arquivoTXT.EndOfStream)
                {
                    string linha = arquivoTXT.ReadLine();
                    linhas.Add(linha);
                }

                arquivoTXT.Close();
            }

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

        public void ApagarDado(string busca)
        {
            List<string> arquivo = LerArquivo();

            // O RemoveAll remove as linhas que contenham o termo a ser buscado
            arquivo.RemoveAll(l => l.Contains(busca));

            // Novo arquivo é gerado para substituir o arquivo anterior
            StreamWriter novoArquivo = new StreamWriter(Caminho);

            // Percorre o list e escreve as linhas (sem a linha removida) no novo arquivo
            foreach (string linha in arquivo)
            {
                novoArquivo.WriteLine(linha);
            }

            novoArquivo.Close();
        }
    }
}
