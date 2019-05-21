CREATE OR REPLACE FUNCTION spGetCustomerByUserName(character varying)
RETURNS SETOF customer_user AS
 $$
BEGIN
	RETURN QUERY SELECT "Customer"."Id",concat("Customer"."FirstName",' ',"Customer"."LastName") as Name,"Customer"."Document","Customer"."Email","User"."UserName","User"."Password","User"."Active"
	FROM Public."Customer"
	inner join Public."User"
	on Public."Customer"."Id" = public."User"."Customer"
	where Public."User"."UserName" = $1;
END;
$$
 LANGUAGE 'plpgsql'