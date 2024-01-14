## APPLICATION (aplicacion)

La capa de aplicacion es la capa que envuelve al nucleo y probablemente se trate de la capa en donde se encuentra la mayor parte del codigo. Es en esta capa en la que se implementan los casos de uso del sistema. Aqui los desarrolladores deben implementar las features definidas con anterioridad.

En LAUCHA esta capa se implementa como un proyecto utilizando el template de biblioteca de clases de .NET 6,debido a que este proyecto debe envolver al proyecto de dominio, el proyecto de application posee una referencia de proyecto a domain.

![proyecto_aplicacion](./aplicacion.png)
###### captura del proyecto de aplicacion