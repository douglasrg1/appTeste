CREATE OR REPLACE FUNCTION spSaveCustomer(character varying, character varying,character varying,character(11))
RETURNS integer AS
 $$
 declare
 res integer;
 
BEGIN
	insert into Public."Customer"("FirstName","LastName","Email","Document")
	values($1,$2,$3,$4) returning "Customer"."Id" into res;
	return res;
END;
$$
 LANGUAGE 'plpgsql'