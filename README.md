<h1 align="center">Monitoramento de eventos</h1>

<p align="center">Este projeto oferece uma solução simples para facilitar a visualização de eventos ocorridos através de sensores. Sendo assim, ele dispõe de um método GET onde o mesmo gera 36 eventos aleatórios. Após a criação de tais eventos, eles são tratados conforme o valor recebido para verificar se foi processado ou se deu erro.
Vale lembrar que ao tratar os eventos, algumas decisões foram tomadas, como por exemplo, separar os sensores no geral com o sensores por região.
</p>
‼ Alguns detalhes adicionais está no repositório

## Features

- ✅ Inserção de eventos
- ✅ Visualização de eventos

## 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [Docker](https://www.docker.com/)
- [.NET](https://dotnet.microsoft.com/)
- [ElasticSearch](https://www.elastic.co/)
- [Kibana](https://www.elastic.co/pt/kibana/)

## Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Docker](https://docs.docker.com/get-docker/) e [docker-compose](https://docs.docker.com/compose/install/).

Caso deseje não utilizar docker, instale o [.net3.1](https://dotnet.microsoft.com/download/dotnet/3.1).

Utilize a IDE que você se sentir melhor. [RIDER](https://www.jetbrains.com/pt-br/rider/)

### 🎲 Rodando o Back End (servidor)

```bash
# Clone este repositório
$ git clone git@gitlab.com:wandellamaiao/radix-analyst-challenge.git

# Acesse a pasta do projeto no terminal/cmd
$ cd radix-analyst-challenge

# Build das imagens docker do projeto
$ docker-compose build

# Executar serviços
$ docker-compose up -d
```
A API estará disponível na porta através do link [http://localhost:8080](http://localhost:8080).

### 📊 Visualização dos gráficos
<ul>
    <li>Acesse o endereço: http://localhost:5601/app/kibana_overview#/ </li>
	<li>Clique no menu laterla que está no canto superior esquerdo.</li>
    <li>Clique em "Stack Management"</li>
	<li>Vá na Seção "Kibana" e clique em "Saved Objects"</li>
	<li>Clique no botão "Import" e em seguida clique na imagem "Import"</li>
	<li>Clique no objeto "Monitoramento de eventos".
    <li>Feito isso, vá na pasta do projeto raiz em que está o projeto e abra o arquivo "dashboarEventos.ndjson" e clique em "importar".
</li>
	<li>Pronto! Agora vá no menu lateral esquerdo do Kibana e selecione o dashboard cujo nome é "Monitoramento de eventos" e pronto, você poderá utilizar o serviço.</li>
</ul>
Vale lembrar que os gráficos atualizam a cada 1 minuto.

### 📡 Inserindo os eventos
Após executar os comandos descritos na seção "Back End" e "Visualização dos gráficos", podemos dar mais um passo na aplicação. Com isso, será necessário inserir os eventos no elasticsearh. Para isso, copie e cole esta URL em seu navegador: http://localhost:8080/api/Event


### 🎯 Trabalhos futuros
Melhorias a serem feitas:
<ul>
    <li>Adicionar outros métodos para oferecer outros caminhos de adição de eventos ou até exclusão de alguns.</li>
	<li>Fazer um fluxo mais real e mais automatizado. Para isso, seria criado um serviço com método Post onde o usuário enviaria um evento. Sendo assim, a solução salvaria este evento em um banco de dados e teria um outro serviço, o de PUB/SUB(Azure, Kafka ou outros) que enviaria uma mensagem paracenviar tais eventos para o elasticsearch.
	</li>
	<li>Mudar a forma como é inserido os documentos no elasticsearh para envio de muitos documentos por insert.</li>
	<li>Refatoração de código.</li>
</ul>
# Autor

Feito com ❤️ por Wandella Maia 👋🏽 Entre em contato!
