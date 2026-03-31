#Proyecto DOMINIO
#Descripción: 
#	Este proyecto contiene las 'entidades' y los puertos secundarios (Interfaces) de salida

#Proyecto APLICACION
#Descripcion:
#	Este proyecto contiene los 
#		'casos de uso' y los puertos primarios (Interfaces)
#		Una referencia al Puerto de salida (repositorio)
#	Ubicamos los pp aqui porque deben ser accesibles desde la capa de INFRAESTRUCTURA
#	Se pueden llamar 'casos de uso' o 'servicios'. 
#	Representan un Orquestador del flujo. No es la implementacion.
#	Puerto de Entrada (Primario): IService

#Proyecto REPOSITORY
#Descripcion:
#	Este proyecto contiene las implementaciones concretas de los puertos secundarios (Repositorios)
#	En nuestro caso usa el ORM EF Core, pero podría ser cualquier otra tecnología de acceso a datos.
#	'ItemRepository' es la implementacion concreta del puerto de salida 'IRepository' del proyecto DOMINIO
#	Tambien tenemos la implementacion del Adaptador Primario
#	Adaptador Primario: ItemService (Implementa el puerto de entrada 'IService' del proyecto APLICACION)
