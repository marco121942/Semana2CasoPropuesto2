# Semana2CasoPropuesto2
create procedure usp_listar_pedidos
as
select IdPedido,IdCliente,FechaEntrega,FechaEnvio,Destinatario from  pedidos 

create procedure usp_Detalle_pedido
@idPedido int
as
begin 
Select detallesdepedidos.idproducto,nombreProducto,detallesdepedidos.preciounidad,cantidad,detallesdepedidos.preciounidad*cantidad as Monto
from detallesdepedidos
inner join productos on detallesdepedidos.idproducto = productos.idproducto
where idpedido = @idPedido;
end;
