create or replace function spGetProductByTitle(character varying)
returns setof Public."Product" as
$$
begin
    return query select * from Public."Product"
    where Public."Product"."Title" = $1; 
end;
$$
language 'plpgsql'