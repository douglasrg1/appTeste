create type customer_user as (id integer,Name text,Document character(11),Email character varying,UserName character varying,Password character varying,Active boolean);
CREATE OR REPLACE FUNCTION spGetCustomerById(integer)
RETURNS SETOF customer_user AS
 $$
BEGIN
	RETURN QUERY SELECT "Customer"."Id", concat("Customer"."FirstName",' ',"Customer"."LastName") as Name,"Customer"."Document","Customer"."Email","User"."UserName","User"."Password","User"."Active"
	FROM Public."Customer"
	inner join Public."User"
	on Public."Customer"."Id" = public."User"."Customer"
	where Public."Customer"."Id" = $1;
END;
$$
 LANGUAGE 'plpgsql'