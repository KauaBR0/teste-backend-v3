# Theatrical Players API

API REST para geração de extratos de uma companhia de teatro. Esta API expõe endpoints para gerar extratos em formato texto e XML.

## Endpoints

### 1. Gerar Extrato em Texto
- **URL**: `/api/statement/text`
- **Método**: `POST`
- **Formato**: JSON

### 2. Gerar Extrato em XML
- **URL**: `/api/statement/xml`
- **Método**: `POST`
- **Formato**: JSON

## Exemplo de Request

```json
{
  "customer": "BigCo",
  "performances": [
    {
      "playId": "hamlet",
      "audience": 55
    },
    {
      "playId": "as-like",
      "audience": 35
    },
    {
      "playId": "othello",
      "audience": 40
    }
  ],
  "plays": {
    "hamlet": {
      "name": "Hamlet",
      "lines": 4024,
      "type": "tragedy"
    },
    "as-like": {
      "name": "As You Like It",
      "lines": 2670,
      "type": "comedy"
    },
    "othello": {
      "name": "Othello",
      "lines": 3560,
      "type": "tragedy"
    }
  }
}
```

## Como Executar

1. Tendo o .NET 6.0 SDK instalado
2. Clone o repositório
3. Na pasta do projeto API, execute:
   ```bash
   dotnet run
   ```
4. Acesse a documentação Swagger em: `http://localhost:5059/swagger`

