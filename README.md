# 🌐 Pulse360 – Intelligent Credit & Risk Orchestration

Pulse360 is a cloud-native, microservices-based platform that simulates enterprise-grade credit scoring, fraud detection, and real-time alerting. Built with .NET 8, Angular 21, and deployed across Azure services, it demonstrates secure, scalable, and observable architecture.

![C#](https://img.shields.io/badge/language-C%23-green)
![Angular](https://img.shields.io/badge/frontend-Angular-red)
![Azure](https://img.shields.io/badge/cloud-Azure-blue)
![Microservices](https://img.shields.io/badge/architecture-Microservices-purple)


## 🧠 Features

- 🔐 Azure AD Authentication
- 🧮 Microservices with .NET 8 Web APIs
- ⚡ Asynchronous orchestration via Service Bus & Event Hub
- 🗝️ Secure secrets via Azure Key Vault
- 📊 Real-time monitoring with Azure Monitor & App Insights
- 📁 Hybrid storage: Blob, File, Table, Queue
- 🧾 SQL + NoSQL: Azure SQL & Cosmos DB
- 🧪 Serverless alerts via Azure Functions
- 🔄 ETL pipelines with Azure Data Factory
- 🚀 CI/CD via GitHub Actions → Azure Web App

## 🧩 Architecture

![Architecture Diagram](https://via.placeholder.com/800x400.png?text=Pulse360+Architecture)

## 📦 Microservices

| Service | Description |
|--------|-------------|
| CreditService | Calculates and caches credit scores |
| RiskService | Flags anomalies from Event Hub stream |
| NotificationService | Sends alerts via Azure Function |
| AuditService | Logs API calls and retries failed events |

## 🚀 Getting Started

1. Clone the repo
2. Set up Azure resources via Bicep templates
3. Configure secrets in Azure Key Vault
4. Deploy microservices to Azure Web App
5. Wire up Azure API Management routes
6. Monitor via Azure Monitor & App Insights

## 🛠️ Tech Stack

- .NET 8, Angular 21
- Azure AD, Key Vault, API Management
- Azure SQL, Cosmos DB
- Azure Storage (Blob, File, Table, Queue)
- Azure Service Bus, Event Hub
- Azure Functions, Azure Data Factory
- Azure Monitor, Application Insights

## 🧪 Sample API

```http
GET /api/credit/{userId}
Authorization: Bearer <token>
