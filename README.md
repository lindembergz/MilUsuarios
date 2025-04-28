<h2>Desafio Técnico: Performance e Análise de Dados via API</h2>

Objetivo

Você tem 1 hora para criar uma API que recebe um arquivo JSON com 100.000 usuários e oferece endpoints performáticos e bem estruturados para análise dos dados.

Exemplos de respostas esperadas na API
Arquivo com 100 mil usuários para importar
Arquivo com 1 mil usuário para teste
JSON de entrada

O JSON contém uma lista de usuários com a seguinte estrutura:

{
  "id": "uuid",
  "name": "string",
  "age": "int",
  "score": "int",
  "active": "bool",
  "country": "string",
  "team": {
    "name": "string",
    "leader": "bool",
    "projects": [{ "name": "string", "completed": "bool" }]
  },
  "logs": [{ "date": "YYYY-MM-DD", "action": "login/logout" }]
}

Endpoints obrigatórios

POST /users

Recebe e armazena os usuários na memória. Pode simular um banco de dados em memória.

GET /superusers
Filtro: score >= 900 e active = true
Retorna os dados e o tempo de processamento da requisição.
