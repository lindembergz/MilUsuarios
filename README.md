<h2>Desafio Técnico: Performance e Análise de Dados via API</h2>

Objetivo<br>

Você tem que criar uma API que recebe um arquivo JSON com 100.000 usuários e oferece endpoints performáticos e bem estruturados para análise dos dados.<br>

Exemplos de respostas esperadas na API<br>
Arquivo com 100 mil usuários para importar<br>
Arquivo com 1 mil usuário para teste<br>
JSON de entrada<br>
<br><br>
O JSON contém uma lista de usuários com a seguinte estrutura:<br>

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

<h2>Observações:</h2> 

Para ter acesso as ferramentas de metricas, você precisará do Docker para a execução do docker-compose.yaml

docker-compose up --build<br>
docker ps

Criação do Arquivo machine-id (para o cadvisor)<br>

O cadvisor precisa de um machine-id para evitar o erro de UUID. Crie o arquivo no mesmo diretório do docker-compose.yaml:<br>

No Windows, use o PowerShell ou um terminal para gerar um UUID<br>
powershell -Command "[guid]::NewGuid().ToString().Replace('-', '') | Out-File -FilePath machine-id"<br>

Linux:<br>
<br>sudo systemd-machine-id-setup   ou  
<br>sudo sh -c 'uuidgen | tr -d "\n" > /etc/machine-id'<br>

Isso criará um arquivo machine-id com um UUID válido.

Boa sorte

localhost:8080/swagger (Swagger da aplicação)
localhost:8081 (cAdvisor)
localhost:9100 (Node Exporter)
localhost:9090 (Prometheus)
localhost:3000 (Grafana, login: admin/admin)
