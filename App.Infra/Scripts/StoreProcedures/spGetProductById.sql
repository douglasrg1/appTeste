create or replace function spGetProductById(int)
returns setof Public."Product" as
$$
begin
    return query select * from Public."Product"
    where Public."Product"."Id" = $1;
end;
$$
language 'plpgsql'