create or replace function spUpdateProduct(int,character varying,decimal,decimal,character varying)
returns void as
$$
begin
    update Public."Product"
    set "Title" = $2, "Price" = $3, "QuantityOnHand" = $4,"Image" = $5
    where "Product"."Id" = $1;
end;
$$
language 'plpgsql'