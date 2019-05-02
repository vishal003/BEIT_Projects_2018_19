# Title: An Integrated Platform for Knowlwdge Sharing

This is a web platform for students of a common university to collaborate on study material, where students can upload their own study material and also study from the study material uploaded by other users.
This website follows university syllabus allowing students with access to study material categorized into branch, semester, subjects, modules and topics.
By using this, students need not go to search for study material at various sources, as during exam time it may consume much of their time. 
It is built using MERN Stack:
1) MongoDB: Document oriented, High performance, High availability — Replication, High scalability – Sharding
2) ExpressJS: Express.js is a Node.js framework. It's the most popular framework as of now (the most starred on NPM). It takes you 5-10x less time and lines of code.
3) NodeJS: It runs Javascript, so you can use the same language on server and client, and even share some code between them (e.g. for form validation, or to render views at either end.)
4) ReactJS: ReactJS basically is an open-source JavaScript library which is used for building user interfaces specifically for single page applications. It’s used for handling view layer for web and mobile apps. React also allows us to create reusable UI components. React allows developers to create large web applications which can change data, without reloading the page. The main purpose of React is to be fast, scalable, and simple. It works only on user interfaces in application. This corresponds to view in the MVC template.

# Group Members
1) Shankarlal Sharma
2) Gaurav Babar
3) Dharmraj Yadav
4) Satyajeet Yadav

# Install dependencies for server

npm install

# Install dependencies for client

npm run client-install

# Run the client & server with concurrently

npm run dev

# Run the Express server only

npm run server

# Run the React client only

npm run client

# Server runs on http://localhost:5000 and client on http://localhost:3000

````

```bash
# Mongo DB setup

Step 1: Enter Mongo shell -

Type 'mongo' in terminal (Avoid Quotes)

Step 2: Create and use the database for your project -

Type 'use databaseName' in mongo shell (Avoid Quotes, replace databaseName with the database you want to use)

The "use" command is used to create a database in MongoDB. If the database does not exist a new one will be created. Until any data is added the database will be invisible.

Step 3: Create a user with access to the database
Type the following in Mongo Shell -
db.createUser(
  {
    user:"root",
    pwd:"mongo123456",
    roles:[
      {
        role:"userAdmin",
        db:"admin"
      }
    ]
  }
)

Output should look like -

Successfully added user: {
	"user" : "root",
	"roles" : [
		{
			"role" : "userAdmin",
			"db" : "admin"
		}
	]
}


You will need to create a default.json file in the server config folder with
{
  "mongoURI": "mongodb://username:userpassword@127.0.0.1:27017/databaseName",
  "jwtSecret": "writeSomesecretkey"
}
````

## App Info

### Author

Shankarlal Sharma
Gaurav Babar
Dharmraj Yadav
Satyajeet Yadav


### Version

1.0.0
