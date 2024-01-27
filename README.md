# PROYECTO L.A.U.C.H.A

El proyecto de Liquidacion Automatizada y Unificada con Calculos y Herramientas Avanzadas o resumido con su nombre en clave
L.A.U.C.H.A , se trata de una pieza de software cuyo objetivo es poder realizar el computo de sueldos de su organizacion.
Para hacerlo laucha debe ser conciente de los contratos de trabajo de cada empleado , sus asistencias , bonos extra , etc. 
De manera tal que el proceso de liquidacion de sueldos se pueda realizar de la forma mas automatizada posible y minimizar los
errores humanos.

![presentacion_laucha](/Docs/laucha_presentation.png)

## SOBRE ESTA DOCUMENTACION

El objetivo de la documentacion descrita en este proyecto es ayudar al desarrollador a
familiarizarse con el concepto de arquitectura limpia que se utilizara para el proyecto L.A.U.C.H.A 

Tenga en cuenta que esta documentacion funciona como ejemplo de una implementacion de arquitectura limpia muy concreta, se asume que con
anterioridad ha leido o esta familiarizado con los conceptos de arquitectura limpia.

Puede leer alguno de los siguientes articulos:

[ENTENDIENDO LA ARQUITECTURA LIMPIA](https://nescalro.medium.com/entendiendo-a-la-arquitectura-limpia-7877ad3a0a47)

[PATRON DE PUERTOS Y ADAPTADORES](https://medium.com/@edusalguero/arquitectura-hexagonal-59834bb44b7f)

[ARQUITECTURA DE APLICACIONES WEB COMUNES](https://learn.microsoft.com/es-es/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture)


## ENTENDIENDO LAS CAPAS

La arquitectura limpia se basa en contruir software a partir de 3 capas , sin embargo este proyecto expondra un web API que
debera ser usada por el resto de desarrolladores para conectar sus aplicaciones clientes a laucha, por ejemplo un frontend web basado en React JS 
o un sistema de contabilidad. Para lograr este objetivo se agrega una capa mas y es por ello que decimos que laucha se contruye usando 3 + 1 capas.

En la implementacion las capas de implementan como proyectos de .net 6.0 usando varios templates del framework. Las primeras 3 capas se implementan 
como "bibliotecas de clases" y las ultima capa,es decir, la web API se manifiesta como un proyecto "ASP .NET core Web API".

El resultado final son las siguientes capas:

- [DOMAIN ( nucleo de la aplicacion)](/Docs/domain.md)
- [APPLICATION (define los casos de uso)](/Docs/application.md)
- INFRAESTRUCTURA (define los adaptadores de la aplicacion al exterior)
- API (define la web api que utiliza el software para conectarlo con otros sistemas)

## INICIO RAPIDO

Si usted es un desarrolador del proyecto L.A.U.C.H.A que previamente fue agregado como contruibuidor al repositorio y debe empezar a desarrollar y agregar funcionalidades al proyecto siga las siguientes intrucciones:

1. Clone el repositorio de manera local:

    ```
    git clone https://github.com/Tecna-Machines/LAUCHA.git
    cd LAUCHA 
    ```
   Si esta utilizando ssh , clone el repositorio de la siguiente manera:
    ```
    git@github.com:Tecna-Machines/LAUCHA.git
    cd LAUCHA
    ```

2. Muevase a la rama de Develop (no trabaje NUNCA sobre la rama main):

    ````
    git checkout -b Develop origin/Develop
    ````

3. Cree un rama en la cual realizara sus cambios y muevase a ella:

    ``````
    git branch <NOMBRE_RAMA>
    git checkout <NOMBRE_RAMA>
    ``````
4. Configure su app

Las configuraciones basicas del proyecto (como la conexion a base de datos) se configuran utilizando un archivo JSON ,si en su repositorio no existe el archivo appsettings.Development.json siga los siguientes pasos:

Cree un archivo llamado appsettings.Development.json en la ruta que se muestra a continuacion:
``````
LAUCHA/LAUCHA.api/appsettings.Development.json
``````

Si esta utilizando Visual Studio puede posicionar el cursor sobre el proyecto LAUCHA.api , haga click derecho y seleccione **AGREGAR > Nuevo elemento** a continuacion seleccione la plantilla de archivo JSON y cree el archivo con el nombre "appsettings.Development.json"

![json_appsettings](/Docs/appsettingsJSON.png)

Una vez que cree el archivo copie y pegue la plantilla que se muestra a continuacion , reemplaze el string se conexion por el que corresponda a su entorno de pruebas, si usted
aun no posee un base de datos para pruebas lee el apartado [como crear mi base de datos]().
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
  "ConnectionStrings": {
    "Test": "<MI_CONEXION>",
  }
}

```