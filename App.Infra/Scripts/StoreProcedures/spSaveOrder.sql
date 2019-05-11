create or replace function spSaveOrder(integer,date,character varying,int,decimal,decimal)
returns integer as
$$
declare
    res integer;
begin
    insert into Public."Order" ("Customer","CreateDate","Number","Status","Deliveryfee","Discount")
    values ($1,$2,$3,$4,$5,$6) returning Public."Order"."Id" into res;
    return res;
end;
$$
language 'plpgsql'