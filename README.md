# RPC Calculator

RPC Calculator is a project that demonstrates the usage of RabbitMQ RPC approach to build a calculator application. It consists of a C# client-server architecture and a Vue.js frontend for displaying the calculator interface. The project also utilizes a Cosmos DB emulator to store the process loggings.

## Features

- Perform mathematical calculations using the RPC approach
- Client-server communication using RabbitMQ
- Interactive calculator interface built with Vue.js
- Logging of process details using the Cosmos DB emulator

## Prerequisites

Before running the project, ensure you have the following prerequisites set up:

- RabbitMQ: Install and configure RabbitMQ to facilitate the client-server communication.
- Vue.js: Install the Vue.js framework to run the frontend application.
- Cosmos DB Emulator: Set up and configure the Cosmos DB emulator for storing the process loggings.

## Getting Started

Follow the steps below to get the project up and running on your local machine:

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/your-repository.git


2. Set up the RPC-Server:

- Open the RPC-Server solution in Visual Studio.
- Build the solution to restore dependencies.
- Run the RPC-Server project to start the server.

  
3. Set up the RPC-Client:

- Open the RPC-Client solution in Visual Studio.
- Build the solution to restore dependencies.
- Run the RPC-Client project to start the client.

- 
4. Set up the frontend:

- Navigate to the frontend directory.

- Install dependencies by running:
   ```bash
   npm install
- Start the frontend application:
   ```bash
   npm run dev
   
5. Access the application:

Open your web browser and visit http://localhost:5173/ to access the calculator interface.
