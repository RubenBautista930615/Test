/*
Devuelve un listado con el identificador, nombre y los apellidos de todos los clientes que
han realizado algún pedido. El listado debe estar ordenado alfabéticamente y se deben
eliminar los elementos repetidos.
*/


select 
				NoCliente = c.id,
				Nombre = c.nombre,
				Apellidos = ISNULL(c.apellido1,'') + ' ' + ISNULL(c.apellido2,'')
from			cliente c
INNER JOIN		pedido p 
				on p.id_cliente = c.id
group by c.id,c.nombre, c.apellido1,c.apellido2 
order by c.nombre



/*Devuelve un listado que muestre todos los pedidos que ha realizado cada cliente. El
resultado debe mostrar todos los datos de los pedidos y del cliente. El listado debe mostrar
los datos de los clientes ordenados alfabéticamente.*/select 			NoCliente = c.id,			Nombre = c.nombre,			Apellidos = ISNULL(c.apellido1,'') + ' ' + ISNULL(c.apellido2,''),			NoPedido = p.id, 			CantidadPedido = p.cantidad,			FechaPedido = p.fecha,			NoComercial = p.id_comercialfrom		pedido pINNER JOIN  cliente c on c.id = p.id_clienteorder by c.Nombre/*Devuelve un listado que solamente muestre los clientes que no han realizado ningún
pedido.*/select 
				NoCliente = c.id,
				Nombre = c.nombre,
				Apellidos = ISNULL(c.apellido1,'') + ' ' + ISNULL(c.apellido2,'')
from			cliente c
where			c.id not in (select distinct id_cliente from pedido)



/*. Calcula la cantidad total que suman todos los pedidos que aparecen en la tabla pedido.*/

select CantidadTotal = SUM(cantidad) from pedido