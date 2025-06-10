Processo Seletivo Itaú Unibanco – Fase 2

Candidato: Joana Nishimura Narazaki

Data: 09/06/2025

# Sistema de Controle de Investimentos

Este projeto foi desenvolvido como parte do Processo Seletivo Itaú Unibanco – Fase 2 (Teste Técnico) e implementa um sistema completo para controle de investimentos em renda variável.

## Funcionalidades

1. **Modelagem de Banco Relacional**

   * Tabelas: `usuarios`, `ativos`, `operacoes`, `cotacoes`, `posicoes`
   * Tipos de dados justificados para otimização de armazenamento e performance.

2. **Índices e Performance**

   * Índices recomendados para consultas de operações dos últimos 30 dias.
   * Query otimizada para cálculo de posição em tempo real.

3. **Aplicação .NET Core (C#)**

   * Camadas bem definidas (Domain, Application, Infrastructure, API).
   * Acesso a dados via Entity Framework Core (ou Dapper) com `async/await`.

4. **Lógica de Negócio – Preço Médio**

   * Método para cálculo de preço médio ponderado de aquisição de ativos.
   * Tratamento de entradas inválidas.

5. **Testes Unitários**

   * Bateria de testes com xUnit/MSTest para o método de preço médio.
   * Testes positivos e de erro (quantidade zero, listas vazias).

6. **Testes Mutantes**

   * Explicação do conceito de testes mutantes.
   * Exemplo de mutação que faria um teste falhar.

7. **Integração via Kafka**

   * Worker Service .NET para consumo de cotações em tempo real.
   * Estratégias de retry e idempotência configuradas.

8. **Engenharia do Caos**

   * Implementação de Circuit Breaker e fallback para indisponibilidade do serviço de cotações.
   * Observabilidade (logs e métricas).

9. **Escalabilidade e Performance**

   * Auto-scaling horizontal configurável.
   * Estratégias de balanceamento de carga comparadas (round-robin vs latência).

10. **APIs REST & Documentação**

    * Endpoints para:

      * Obter última cotação de um ativo
      * Consultar preço médio por usuário
      * Consultar posição de um cliente
      * Valor ganho pela corretora em corretagens
      * Top 10 clientes por posição e por corretagem
    * Documentação em OpenAPI 3.0 (YAML).

## Pré-requisitos

* .NET 7.0 SDK ou superior
* MySQL Server (ou outro RDBMS compatível)
* Apache Kafka (para integração de cotações)
* Visual Studio 2022 / VS Code

## Instalação e Execução

1. Clone o repositório:

   ```bash
   git clone https://github.com/seu-usuario/controle-investimentos.git
   cd controle-investimentos
   ```

2. Configure o banco de dados MySQL e execute o script de criação das tabelas:

   ```sql
   -- scripts/create_tables.sql
   ```

3. Ajuste a string de conexão no arquivo `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=investimentos;User=root;Password=senha;"
   }
   ```

4. Execute as migrações e inicie a aplicação:

   ```bash
   dotnet ef database update
   dotnet run --project src/Api
   ```

5. (Opcional) Inicie o Worker Service para Kafka:

   ```bash
   dotnet run --project src/Worker
   ```

## Estrutura de Pastas

```
/controle-investimentos
├── src
│   ├── Api            # Projeto Web API
│   ├── Application    # Regras de negócio e serviços
│   ├── Domain         # Entidades e interfaces
│   ├── Infrastructure # Acesso a dados (EF Core/Dapper)
│   └── Worker         # Consumo de cotações via Kafka
├── tests              # Projetos de testes unitários
└── scripts            # Scripts SQL e utilitários
```

## Documentação da API

Acesse `/swagger` na aplicação para visualizar a documentação interativa em OpenAPI 3.0.

## Contribuição

1. Fork o projeto
2. Crie uma feature branch (`git checkout -b feature/nova-funcionalidade`)
3. Commit suas alterações (`git commit -m 'Adiciona nova funcionalidade'`)
4. Push para a branch (`git push origin feature/nova-funcionalidade`)
5. Abra um Pull Request

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
