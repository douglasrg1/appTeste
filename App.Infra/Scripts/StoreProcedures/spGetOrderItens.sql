create type Order_Itens as (Title character varying, Quantity decimal, Price money);

create or replace function spGetOrderItens(integer)
returns setof Order_Itens as
$$
begin
  RETURN QUERY SELECT "Product"."Title","OrderItem"."Quantity","OrderItem"."Price"
  from Public."OrderItem"
  inner join Public."Product" on Public."OrderItem"."Product" = Public."Product"."Id"
  where Public."OrderItem"."Order" = $1;
end;
$$
language 'plpgsql'