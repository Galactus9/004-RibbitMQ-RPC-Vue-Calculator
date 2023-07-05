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

## How to get access to RabitMQ

###Option 2: Downloading and installing RabbitMQ

-Visit the RabbitMQ website: Go to the RabbitMQ website (https://www.rabbitmq.com/) and navigate to the Downloads page.

-Select your operating system: Choose the appropriate version of RabbitMQ for your operating system and download the installer.

-Run the installer: Once the installer is downloaded, run it and follow the installation instructions provided by the RabbitMQ installer.

-Start RabbitMQ: After the installation is complete, RabbitMQ should be running automatically. You can verify this by checking if the RabbitMQ service is running in the background or accessing the RabbitMQ management interface using a web browser.

-Access RabbitMQ: By default, RabbitMQ's management interface can be accessed at http://localhost:15672/. You can use this interface to manage and configure RabbitMQ.

-That's it! You now have a Docker image of RabbitMQ or have downloaded and installed RabbitMQ on your machine. You can proceed with the next steps of your project, such as configuring and using RabbitMQ for your RPC Calculator applicatio
