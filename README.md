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