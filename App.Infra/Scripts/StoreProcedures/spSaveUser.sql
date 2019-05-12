create or replace function spSaveUser(character varying,character varying,boolean,int)
returns void as
$$
begin
    insert into Public."User"("UserName","Password","Active","Customer")
    values($1,$2,$3,$4);
end;
$$
language 'plpgsql'