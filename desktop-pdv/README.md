# 💻 PDV

O PDV é um sistema de ponto de venda desenvolvido como atividade do módulo de Desenvolvimento de Aplicações Desktop do curso Técnico em Desenvolvimento de Sistemas do Senac.

<div align="center">
  <img width="100%" src="https://raw.githubusercontent.com/camilafbc/curso-tecnico-desenvolvimento-de-sistemas-senac/main/desktop-pdv/to-readme.png" />
</div>

Este sistema oferece uma interface amigável para a gestão de produtos e vendas, incluindo funcionalidades como cadastro e busca de produtos, detalhamento e edição de produtos, visualização e pesquisa de vendas, além de um PDV interativo para o registro de vendas em tempo real, gestão de estoque, e finalização de vendas com diferentes formas de pagamento.

## Funcionalidades

O PDV possui as seguintes funcionalidades principais:

* **Produtos:** Permite cadastrar novos produtos e buscar por produtos cadastrados. É possível visualizar os detalhes de um produto e editar suas informações ao dar um duplo clique na linha desejada da tabela.

* **Vendas:** Permite verificar as informações das vendas realizadas e buscar vendas por número ou data. Detalhes das vendas podem ser visualizados individualmente através de um duplo clique.

* **PDV:** Permite registrar vendas em tempo real. Os produtos são adicionados à compra informando o código do produto e a quantidade desejada. Para remover um item, basta selecioná-lo na tela e clicar no botão "Remover Item". O sistema controla o estoque e calcula automaticamente o valor total da compra. Após a conclusão da venda, os dados são armazenados no banco de dados.

## Instalação

Para começar a utilizar o PDV, siga as etapas abaixo:

1. Clone o repositório para o seu ambiente local;
   
2. Certifique-se de ter um gerenciador de banco de dados MySQL em execução em sua máquina local.

3. Certifique-se de ter um servidor local configurado, como o XAMPP, que inclui o Apache e o MySQL.

4. Após instalar e configurar o XAMPP, inicie o Apache e o MySQL usando o painel de controle do XAMPP.

5. Crie um banco de dados MySQL com o nome "pdv". 

6. Em sua ferramenta de gerenciamento de banco de dados MySQL, execute os scripts SQL contidos no arquivo "config_database.txt" localizado no diretório do projeto. Esses scripts criarão as tabelas necessárias e inserirão alguns dados iniciais.

7. Abra o projeto no Visual Studio 2019 ou superior.

8. Abra o arquivo "Config_example.cs" e preencha as informações de conexão com o banco de dados, como nome do servidor, nome do banco de dados, porta, nome de usuário e senha.

9. Compile o projeto e execute-o no Visual Studio 2019 ou superior.

10. Para fazer login na aplicação, utilize o seguinte conjunto de credenciais:

* Email: usuario@email.com
* Senha: 123456


# Tecnologias Utilizadas

* C#
* .NET Framework v4.7.2
* MySQL
