Guía de Creación del Microservicio

Esta guía detalla los pasos seguidos para generar, configurar y dockerizar el primer microservicio del proyecto utilizando Visual Studio Code.

1. Generación del Proyecto

Para poder crear nuestro primer microservicio, deberemos percatarnos de que tenemos instalado .NET, para ello existen comandos para verificarlo. Para generar nuestro primer microservicio, utilizaremos el siguiente comando (Para este proyecto, utilice Visual Studio Code, con control de comandos para todos los paquetes que deberemos instalar):

dotnet new webapi -n MicroservicioTest


Después deberemos entrar a la carpeta del proyecto que recién se acaba de generar:

cd MicroservicioTest


2. Instalación de Paquetes NuGet

Ahora antes de empezar a programar, deberemos instalar 4 paquetes exclusivos del Framework ASP .NET Core, los cuales son los siguientes y que son en la versión 9:

dotnet add package Microsoft.EntityFrameworkCore.Design -v 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools -v 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer -v 9.0.0
dotnet add package Microsoft.EntityFrameworkCore -v 9.0.0


Posteriormente a que se terminen de instalar los 4 nugets, verificaremos que estén instalados correctamente y en la versión de .NET 9 con el siguiente comando:

dotnet list package


3. Estructura de Carpetas

Perfecto, con eso ya podemos empezar a programar, primero empezaremos creando 2 carpetas (3 porque a veces no se crea la carpeta de Controllers) las cuales son:

Data

Models

Controllers

Archivos Implementados

Carpeta Data: Dentro de nuestra nueva carpeta de Data, crearemos el archivo DbContext, el archivo que contendrá las instancias para poder conectar con la base de datos SQL Server (ModOrientacionDB). Así se llamará:

TestDbContext.cs

Carpeta Models: En la carpeta Models crearemos las clases que contendrá el microservicio, en mi caso yo creé 2:

FichaOri.cs

Adulto.cs

Carpeta Controllers: En la carpeta Controllers crearemos los 2 web api controllers, Controladores completamente funcionales:

AdultoApiController.cs

FichaOriApiController.cs

4. Configuración (Program.cs)

Después modificaremos el archivo Program.cs para realizar la configuración del comportamiento que deberá realizar el Framework con todo ya definido por ahora.

Interfaz: Scalar (configurado en Program.cs).

Base de Datos: Para verificar que el microservicio está funcionando correctamente, yo por mi cuenta en program.cs añadí una línea la cual es:

context.Database.EnsureCreated();


Nota: La cual permite que el proyecto utilice Scalar para realizar las pruebas del microservicio en lugar de Swagger o Postman. Postman lo utilicé para hacer la prueba con el contenedor de docker funcionando.

5. Dockerización

Ahora para empezar a Dockerizar, crearemos 2 archivos en el proyecto, se llamarán:

Dockerfile

docker-compose.yml
