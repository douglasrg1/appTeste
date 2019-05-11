create or replace function spUpdateOrder(int,int,date,character varying,int,decimal,decimal)
returns void as
$$
begin
    update Public."Order"
    set "Customer" = $2, "CreateDate" = $3, "Number" = $4, "Status" = $5, "Deliveryfee" = $6, "Discount" = $7
    where Public."Order"."Id" = $1;
end;
$$
language 'plpgsql'