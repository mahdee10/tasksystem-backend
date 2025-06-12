# 🔧 Task Manager Backend — ASP.NET Core API

This is the backend of the Task Manager system, built with ASP.NET Core. It provides secure and scalable REST APIs for task/event management, user authentication, and global event subscriptions with email notifications.

🌐 API Base URL: *Not hosted yet*

## 🚀 Features

- 🔐 Secure authentication using JWT
- 📝 CRUD APIs for tasks and events
- 📬 Email notification system for subscribed users
- 👥 User registration and login endpoints
- 🧾 Role-based authorization 
- 📦 Cleanly structured controller and service layers

## 🧠 How It Works

The backend exposes a REST API that supports CRUD operations for tasks and events. Authenticated users can interact with their data and subscribe to global events, which triggers email alerts via a background service or SMTP integration.

## 🛠️ Tech Stack

- Language: C#
- Framework: ASP.NET Core Web API
- Authentication: JWT Bearer Tokens
- Database: Entity Framework Core + MySql (moved postgres for hosting reasons)
- Mailing: SMTP / MailKit

## 📦 Installation

To run the backend locally:

```bash
git clone https://github.com/your-username/task-manager-backend
cd task-manager-backend
dotnet restore
dotnet build
dotnet run
