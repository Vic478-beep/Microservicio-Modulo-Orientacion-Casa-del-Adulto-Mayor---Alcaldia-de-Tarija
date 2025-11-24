Guía de Creación del Microservicio

Esta guía detalla los pasos seguidos para generar, configurar y dockerizar el primer microservicio del proyecto utilizando Visual Studio Code.

1. Generación del Proyecto

Para poder crear nuestro primer microservicio, deberemos percatarnos de que tenemos instalado .NET; existen comandos para verificarlo. Para generar nuestro primer microservicio, utilizaremos el siguiente comando (Para este proyecto, utilice Visual Studio Code, con control de comandos para todos los paquetes que deberemos instalar):

dotnet new webapi -n MicroservicioTest


Después, deberemos entrar a la carpeta del proyecto que recién se acaba de generar:

cd MicroservicioTest

Y asi es como esta estructurado el proyecto:

MicroservicioModOrientacion/
├── Controllers/       # Controladores de la API (Endpoints)
│   ├── AdultoApiController.cs
│   └── FichaOriApiController.cs
├── Data/              # Contexto de base de datos
│   └── ModOrientacionDbContext.cs
├── Models/            # Entidades del dominio
│   ├── Adulto.cs
│   └── FichaOri.cs
├── Program.cs         # Configuración y Pipeline
├── Dockerfile         # Configuración de imagen Docker
└── docker-compose.yml # Orquestación de servicios

2. Instalación de Paquetes NuGet

Ahora, antes de empezar a programar, deberemos instalar 4 paquetes exclusivos del Framework ASP.NET Core en su versión 9. Ejecuta los siguientes comandos:

dotnet add package Microsoft.EntityFrameworkCore.Design -v 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools -v 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer -v 9.0.0
dotnet add package Microsoft.EntityFrameworkCore -v 9.0.0


Posteriormente a que se terminen de instalar los 4 nugets, verificaremos que estén instalados correctamente y en la versión de .NET 9 con el siguiente comando:

dotnet list package


3. Estructura de Carpetas

Perfecto, con eso ya podemos empezar a programar. Primero empezaremos creando 3 carpetas (ya que a veces no se crea la carpeta de Controllers automáticamente):

Data

Models

Controllers

Archivos Implementados

📂 Carpeta Data

Dentro de nuestra nueva carpeta de Data, crearemos el archivo DbContext, que contendrá las instancias para conectar con la base de datos SQL Server (ModOrientacionDB). Así se llamará:

📄 TestDbContext.cs

📂 Carpeta Models

En la carpeta Models crearemos las clases que contendrá el microservicio. En mi caso, yo creé 2:

📄 FichaOri.cs

📄 Adulto.cs

📂 Carpeta Controllers

En la carpeta Controllers crearemos los 2 Web API Controllers completamente funcionales:

📄 AdultoApiController.cs

📄 FichaOriApiController.cs

4. Configuración (Program.cs)

Después modificaremos el archivo Program.cs para realizar la configuración del comportamiento que deberá realizar el Framework.

Interfaz: Scalar (configurado en Program.cs).

Base de Datos: Para verificar que el microservicio está funcionando correctamente, yo por mi cuenta en Program.cs añadí la siguiente línea:

context.Database.EnsureCreated();


Nota: Esta línea permite que el proyecto utilice Scalar para realizar las pruebas del microservicio localmente en lugar de Swagger. Postman lo utilicé para hacer la prueba con el contenedor de Docker funcionando.

5. Dockerización

Ahora, para empezar a Dockerizar, crearemos 2 archivos en la raíz del proyecto, se llamarán:

🐳 Dockerfile: Este archivo es la "receta" para crear la imagen de la aplicación. Utilizamos una estrategia llamada Multi-Stage Build (Construcción en múltiples etapas) para hacer la imagen final más ligera y segura.
🐳 docker-compose.yml: Este archivo define cómo se relacionan los servicios (La API y la Base de Datos) para funcionar juntos como un sistema.
Una vez terminados de modificar los archivos de docker, lo que hice fui abrir primero mi Docker Desktop para empezar a crear la imagen
6. Ejecución y Pruebas

Finalmente, estos son los comandos utilizados para levantar el entorno completo (Base de Datos + Microservicio) utilizando Docker.

Iniciar el proyecto

Para construir la imagen y levantar los contenedores:

docker compose up --build


Verificar estado

Para confirmar que los contenedores están corriendo:

docker compose ps


Probar el Microservicio

Una vez iniciado, accedemos a la interfaz de pruebas en el navegador:
👉 http://localhost:5150/scalar/v1
O utilizando POSTMAN: 
Para listar todos los adultos mayores: 
http://localhost:5150/api/AdultoApi/ListarAdultos
Para crear un nuevo adulto mayor:
http://localhost:5150/api/AdultoApi/RegistrarNuevoAdulto
Para listar todas las fichas de orientacion de adultos mayores:
http://localhost:5150/api/FichaOriApi/ListarFichas
Para crear una nueva ficha de orientacion para adulto:
http://localhost:5150/api/FichaOriApi/RegistrarNuevaFicha

Detener el proyecto

Para detener y eliminar los contenedores correctamente:

docker compose down
