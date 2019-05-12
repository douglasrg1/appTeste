create or replace function spSaveProduct(character varying, decimal,decimal,character varying)
returns int as
$$
declare
 ret int;
begin
    insert into Public."Product"("Title","Price","QuantityOnHand","Image")
    values($1,$2,$3,$4) returning "Product"."Id" into ret;
    return ret;
end;
$$
language 'plpgsql'