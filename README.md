# 🏦 Sistema Bancário — SGBD

Sistema de gerenciamento bancário desenvolvido em **C# / .NET** como projeto prático de aprendizado, aplicando conceitos de Programação Orientada a Objetos, LINQ e tratamento de exceções.

## Sobre o projeto

Este projeto simula um sistema bancário via console, permitindo criar contas, realizar movimentações financeiras e consultar extratos. Foi desenvolvido com foco em boas práticas de POO, encapsulamento e separação de responsabilidades.

## Funcionalidades

- ✅ Criação de conta **Corrente** e **Poupança**
- ✅ **Depósito** com validação de valor
- ✅ **Saque** com regras diferentes por tipo de conta
- ✅ **TED** com taxa de R$ 5,00 por operação
- ✅ **Pix** com restrição de horário (06h às 22h)
- ✅ **Extrato** com histórico completo de transações
- ✅ **Relatório VIP** — lista clientes com saldo acima de R$ 50.000
- ✅ Geração automática de número de conta sem repetição

## Conceitos aplicados

| Conceito | Onde foi aplicado |
|---|---|
| Herança | `ContaCorrente` e `ContaPoupanca` herdam de `Conta` |
| Polimorfismo | Método `Sacar()` com comportamento diferente por tipo |
| Classe abstrata | `Conta` define contrato com `Sacar()` abstrato |
| Encapsulamento | `private set` e `protected set` nas propriedades |
| LINQ | Relatório VIP com `Where` e `OrderByDescending` |
| Dictionary | Armazenamento e busca O(1) de contas por número |
| Tratamento de exceções | `try/catch` em todas as operações do menu |
| Separação de responsabilidades | Camadas `Models/` e `Services/` |

## Estrutura do projeto

sistema-bancario-sgbd/
│
├── Models/
│   ├── Conta.cs            # Classe abstrata base
│   ├── ContaCorrente.cs    # Conta com taxa de saque e cheque especial
│   ├── ContaPoupanca.cs    # Conta sem saldo negativo
│   └── Transacao.cs        # Registro de cada movimentação
│
├── Services/
│   └── Banco.cs            # Gerencia todas as contas
│
└── Program.cs              # Menu principal e interação com o usuário

## Como executar

**Pré-requisitos:** .NET 6.0 ou superior

```bash
# Clone o repositório
git clone https://github.com/duardo3120/sistema-bancario-sgbd.git

# Acesse a pasta
cd sistema-bancario-sgbd

# Execute o projeto
dotnet run

## Regras de negócio

**Conta Corrente**
- Saque com taxa de R$ 2,50 por operação

**Conta Poupança**
- Saque sem taxa, mas não permite saldo negativo

**TED**
- Taxa de R$ 5,00 por transferência

**Pix**
- Disponível apenas entre 06h e 22h
- Sem taxa

## Aprendizados

Este projeto foi desenvolvido como parte do meu processo de aprendizado em C# e .NET. Durante o desenvolvimento, pratiquei:

- Aplicação de **POO** em um contexto real
- Uso de **classes abstratas** para definir contratos
- Gerenciamento de **coleções** com `List<T>` e `Dictionary<K,V>`
- **Tratamento de erros** com exceções personalizadas
- Organização de código em **camadas** (`Models` e `Services`)
- Versionamento com **Git e GitHub**

## 👨‍💻 Autor

**Eduardo** — estudante de Ciência da Computação
[GitHub](https://github.com/duardo3120)
