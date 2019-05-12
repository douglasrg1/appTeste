create or replace function spSaveUser(character varying,character varying)
returns void as
$$
begin
    insert into Public."User"("UserName","Password")
    values($1,$2);
end;
$$
language 'plpgsql'