Para poder crear nuestro primer microservicio, deberemos percatarnos de que tenemos instalado .NET, para ello existen comandos para verificarlo. Para generar nuestro primer microservicio, utilizaremos el
siguiente comando (Para este proyecto, utilice Visual Studio Code, con control de comandos para todos los paquetes que deberemos instalar):
      dotnet new webapi -n MicroservicioTest
Despues deberemos entrar a la carpeta del proyecto que recien se acaba de generar:
      cd MicroservicioTest
Ahora antes de empezar a programar, deberemos instalar 4 paquetes exclusivos del Framework ASP .NET Core, los cuales son los siguietnes y que son el la version 9:
      dotnet add package Microsoft.EntityFrameworkCore.Design -v 9.0.0
      dotnet add package Microsoft.EntityFrameworkCore.Tools -v 9.0.0
      dotnet add package Microsoft.EntityFrameworkCore.SqlServer -v 9.0.0
      dotnet add package Microsoft.EntityFrameworkCore -v 9.0.0
Posteriormente a que se terminen de instalar los 4 nugets, verificaremos que esten instalados correctamente y en la version de .NET 9 con el siguiente comando:
      dotnet list package
Perfecto, con eso ya podemos empezar a programar, primero empezaremos creando 2 carpetas (3 porque a veces no se crea la carpeta de Controllers) la cuales son:
1.- Data
2.- Models
