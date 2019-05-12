create or replace function spGetAllProducts()
returns setof Public."Product" as
$$
begin
    return query select * from Public."Product";

end;
$$
language 'plpgsql'