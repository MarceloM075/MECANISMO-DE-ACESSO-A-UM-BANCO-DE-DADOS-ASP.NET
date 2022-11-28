# MECANISMO-DE-ACESSO-A-UM-BANCO-DE-DADOS-ASP.NET

Este é um projeto que fiz na faculdade de um sistema em C#, utilizando o framework ASP.NET.
O objetivo é desenvolver um mecanismo de acesso a um banco de dados e uma interface que de ao usuário as funções CRUD (Create, Read, Updade e Delete).

<hr>
<h3> O DIAGRAMA DE CLASSES </h3>

As classes desenvolvidas foram baseadas em um diagrama de classes proposto pela instituição. E seus devidos relacionamentos.

<br>
<div align="center">
  <img align="center" src="img/diagrama-de-classes.JPG">
</div>
<br>

A classe PessoaDAO foi feita utilizando o padrão repository pattern, separando a parte lógica da camada de acesso aos dados do banco. Não foi proposto a utilização deste pela faculdade, e sim apenas minha escolha. 
É nesta classe que estão contidos os métodos CRUD.

<hr>

<h3> O BANCO DE DADOS </h3>

O bando de dados escolhido para o armazenamento dos dados foi o SQLite, pois é um banco de fácil e simples utilização.

<hr>

<h3> AS VIEWS </h3>
