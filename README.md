# A MELHORIA DE ATENDIMENTO COM BASE NA DETECÇÃO DE EMOÇÕES VIA RECONHECIMENTO FACIAL PARA A EVOLUÇÃO DAS EMPRESAS

Este repositório contém todos os arquivos utilizados na produção do documento oficial do TCC para o curso de Ciência da Computação - Universidade Paulista.

## Documentação científica e desenvolvimento 
tcc/.docs/A_MELHORIA_DE_ATENDIMENTO_COM_BASE_NA_DETECCAO_DE_EMOCOES_VIA_RECONHECIMENTO_FACIAL_PARA_A_EVOLUCAO_DAS_EMPRESAS.pdf

## Manual do usuário
A solução em questão é composta por duas API’s, banco de dados e microcontrolador ESP32-CAM, cada peça com suas características de instalação e utilização. Com isso em mente, este guia cobrirá a instalação e a utilização para cada um dos sistemas, que é divido em API Inteligência Artificial, API Bridge, banco de dados e hardware.

Ambas as API’s foram construídas utilizando a linguagem de programação C# e sistema operacional Windows 10/11, mas outras ferramentas são necessárias para que operem corretamente em um ambiente local. Na tabela abaixo estão as aplicações e endereços para download que devem ser instaladas para prosseguir.

![image](https://user-images.githubusercontent.com/56414441/207091837-d792e27c-40bc-43b5-a1a6-cf7feef000b5.png)

Como próximo passo é necessário realizar o download dos projetos no repositório localizado em “https://github.com/pedrooplx/tcc”.

Inicialmente, é necessário abrir a solução “Software/API_IA/ProxyIA.sln” na IDE Visual Studio e aguardar o download das dependências. Logo após, construa a solução e copie o arquivo “.DLL” da instalação do python e cole na pasta localizada em “ProxyIA\bin\Debug\netcoreapp3.1” e então rode o projeto. Para o funcionamento adequado deste projeto é necessário que o python, versão 3.8.9, já esteja instalado na máquina, juntamente a biblioteca tensorflow 2.9.

Após essa etapa, um banco de dados denominado “AnaliseAtendimento” deve ser criado utilizando a ferramenta de distribuição de banco de dados “MySQL”.

Ao criar o banco de dados e iniciar o projeto API IA, é necessário abrir a solução da API Bridge em “tcc/Software/API_Bridge/ TCC.API.sln” na IDE Visual Studio, aguardar o download das dependências, acessar o arquivo ”Software\API_Bridge\TCC.API\appsettings.json” e alterar as variáveis “MySqlConnectionString” com a string de conexão do banco de dados criado e “IA_MS_ENDPOINT” com o endereço da API IA, previamente configurada.

Dado as configurações acima, acesse o recurso “Package Manager Console” na IDE Visual Studio, selecione o projeto “src/TCC.Infra” como projeto padrão e execute o comando “update-database” para que o banco de dados seja configurado com as tabelas, colunas e relações necessárias. Esse fluxo é automatizado devido o uso da biblioteca Entity Framework Core, que já está devidamente configurada no projeto.

Por fim, rode a API Bridge, dado as configurações nas variáveis de ambiente, ela já estará apta a se comunicar com o banco de dados e com a API de Inteligência Artificial.

Ao realizar as configurações acima, em ambas as API’s e banco de dados, é necessário realizar o upload do código no ESP32-CAM e para isso, é necessário instalar e configurar a interface de desenvolvimento Arduino IDE.

Após a instalação do software Arduino IDE, deve-se acessar as configurações de preferências da interface de desenvolvimento, adicionar a URL “https://dl.espressif.com/dl/package_esp32_index.json” em “URLs adicionais para gerenciadores de placas” como na imagem abaixo.

![image](https://user-images.githubusercontent.com/56414441/207092277-e33faf7a-7126-4c17-ad50-721395b59b4f.png)

Ao referenciar a URL adicional para gerenciamento da placa ESP32 CAM, listado acima, deve-se ir em “Ferramentas > Gerenciador de Placas”, filtrar por “ESP32” e instalar a versão mais recente, atualmente a 1.0.6, conforme imagem abaixo.

![image](https://user-images.githubusercontent.com/56414441/207092366-a7c3bf0d-0e41-4f50-9a93-3a7b7b0b9ba1.png)

Após a instalação do “ESP32”, deve-se ir ao menu “Ferramentas” para selecionar a placa “ESP32 Al Thinker ESP-32CAM” e em seguida, ainda no menu
“Ferramentas”, utilizando um cabo USB realize a conexão do protótipo com qualquer porta USB do computador e selecione a porta de comunicação (Porta COM) que estará disponível.

![image](https://user-images.githubusercontent.com/56414441/207092466-1c408985-56bc-425a-a047-9b68d460d417.png)

Caso todas as configurações estejam corretas deve ser possível acessar a tela “Monitor Serial”. Nesse menu é possível enviar comandos ou alterar parâmetros no microcontrolador.

Finalizado as configurações da Arduino IDE, listadas acima, deve-se entrar no arquivo “tcc/Hardware/src/ESP32_CAM/ESP32_CAM.ino” para alterar o endereço da API Bridge e as credenciais para acesso a rede via Wifi, para isso altere os valores das variáveis “ssid” com o nome da rede e “password” com a senha da rede e em seguida altere o valor da variável “serverpath” com o endereço HTTP da API Bridge na rota “/analise-expressoes/classificacoes”.

Por fim, basta enviar o código do arquivo “ESP32_CAM.ino” para o microcontrolador ESP32, para isso basta apertar no botão “Carregar”, localizado no canto superior esquerdo na Arduino IDE. Ao finalizar, deve-se abrir o “Monitor Serial” para dar inicio ao processo de captura e envio de imagens para a API Bridge.

Dado o exposto, a esteira de comunicação já estaria em um estado “saudável”, ou seja, a comunicação deve estar apta entre todas as peças, consequentemente, capturando imagens, enviando-as para a API Bridge, executando as análises via API IA e salvando dados gerados no banco de dados.
