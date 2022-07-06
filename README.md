# Project deployment #

## SSMS needs to be installed for the project
## For the correct operation of the project, you must perform the following steps:

#### 1.Run cmd and type: 
*	dotnet tool install --global dotnet-ef --version 3.1.26

#### 2.Go to the API derictory, run cmd and enter:
*	dotnet ef database update
*	dotnet run
do not disable cmd.

#### 3.Run the sql script in the project folder. When the connection window appears, copy the server name
Click connect, then run the script
(If the script fails to run, then please fill in the Genres table yourself)

#### 4.Open the appsettings.json file in the API directory. In the DefaultConnection field, paste the copied value before "Database="

#### 5.Open the movies directory, run cmd and enter:
*	npm install
*	npm start
#### do not disable cmd.
