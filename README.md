# Projeto final de LP3 - WHISPER Api
Projeto final da disciplina "LP3". Criação de um projeto multicamadas disponibilizando uma API RESTfull.

 O objetivo é desenvolver uma aplicação de uma conversa entre 2 usuários. Densenvolvemos a WHISPER API para fornecer acesso aos recursos necessários para o aplicativo de "chat".

## Documentação multicamadas

### MODEL

 Camada reponsável pela contrato do projeto contendo as classes de acordo com um mesmo padrão.
 Classes presentes:
 - Usuário (ID, username, password);
 - Chat (ID, IDusuario1, IDusuario2);
 - Mensagem (ID, IDchat, IDusuario, mensagem).

### DAL

Camada responsável pela comunicação com o banco através do dbContext.

### BLL

Camada responsável pela lógica da aplicação.
Repositórios presentes:
- UserRepository;
- ChatRepository;
- MesageRepository.

Cada um responsável por tratar a lógica de cada tabela.

### Service

Camada responsável por disponibilizar métodos HTTP capazes de utilizar os recursos do projeto. Métodos presentes:
- UserController;
- ChatController;
- MesageController;

## Interface

A interface está separada no repositório: https://github.com/jabriboy/projetoFinal-lp3.Interface
