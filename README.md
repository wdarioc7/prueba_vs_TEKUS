# prueba_vs_TEKUS
Prueba TEKUS
Problema
La empresa TEKUS S.A.S. requiere un aplicativo web (.NET Asp.net) que permita
administrar (crear, editar y listar) los servicios ofrecidos por sus clientes. Cada
cliente deberá relacionar los servicios ofrecidos y a su vez, cada servicio
deberá relacionar uno o varios países dónde es ofrecido (por ejemplo, El
cliente “Importaciones Tekus S.A.” ofrece los servicios “Descarga espacial de
contenidos” y “Desaparición forzada de bytes”, y el servicio “Descarga
espacial de contenidos” es ofrecido en Colombia, Perú y México por el cliente
“Importaciones Tekus S.A.”)
- El cliente deberá tener los campos ID, NIT, Nombre y correo electrónico
- El servicio deberá tener los campos ID, Nombre y valor por hora (en $USD).
- El campo ID en ambas entidades debe ser un valor autogenerado y único.
El aplicativo web deberá soportar 2 tipos de almacenamiento:
a. Base de datos: Se deberá crear una base de datos en SQL Express 2012 (o
superior) en dónde se almacenarán estos campos.
b. Almacenamiento en memoria (Memory Storage). Esto permitirá trabajar la
aplicación sin la necesidad de una base de datos.
Se deberá proveer un botón en la UI del aplicativo que permita seleccionar el
tipo de almacenamiento en tiempo real. Esto permitirá cambiar en cualquier
momento el tipo de almacenamiento a utilizar.
Adicionalmente se solicita crear una funcionalidad para la limpieza
(restauración) del almacenamiento seleccionado. Esta funcionalidad deberá
eliminar todos los registros creados y reiniciar los campos auto numéricos
creados. Se sugiere agregar un botón a la vista inicial.
Se deberá proveer una página de resumen que permita visualizar la siguiente
información:
1. Cantidad de clientes ingresados
2. Cantidad de servicios ofrecidos en general
3. Cantidad de servicios ofrecidos por país
Requerimientos generales:
1. Las vistas deberán ser proporcionadas por MVC + Razor
2. Todos los servicios deberán ser expuestos como RESTful, por lo que deberá
implementar algún tipo de tecnología en el lado del cliente para facilitar la
manipulación de los formularios (React, Vue, Angular, knockout, jQuery, etc)
3. Toda lista deberá tener funcionalidades de paginación, ordenamiento y
búsqueda.
4. Agregue una característica que permita realizar las consultas al servidor por
Caché (agrega un componente en la UI para habilitar/deshabilitar esta
característica)
5. Agregue todas las validaciones que considere necesarias (tanto en frontend
como en backend) para garantizar el correcto almacenamiento de los datos.
6. Documente las funcionalidades que considere más importantes
Entregables
1. Se deberá entregar un esquema de la Base de datos relacionando las
entidades mencionadas (una foto o un diagrama)
2. Se deberá publicar el proyecto completo en un repositorio GIT de su
preferencia (Proyecto ejecutable en Visual Studio 2015 o superior). Recuerde
enviar el link del repositorio al contacto al iniciar la prueba para facilitar la
revisión de los avances.
3. Se deberá proveer un script de generación de la DB en el mismo repositorio
del punto anterior, así como un script de datos iniciales (al menos 10 por cada
tabla).
4. Enviar un correo a Jaime.marin@tekus.co notificando la finalización de la
prueba y cualquier consideración adicional que sea necesaria para facilitar
la revisión.
