Guía de Creación del Microservicio

Esta guía detalla los pasos seguidos para generar, configurar y dockerizar el primer microservicio del proyecto utilizando Visual Studio Code.

1. Generación del Proyecto

Para poder crear nuestro primer microservicio, deberemos percatarnos de que tenemos instalado .NET; existen comandos para verificarlo. Para generar nuestro primer microservicio, utilizaremos el siguiente comando (Para este proyecto, utilice Visual Studio Code, con control de comandos para todos los paquetes que deberemos instalar):

dotnet new webapi -n MicroservicioTest


Después, deberemos entrar a la carpeta del proyecto que recién se acaba de generar:

cd MicroservicioTest


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

🐳 Dockerfile

🐳 docker-compose.yml
