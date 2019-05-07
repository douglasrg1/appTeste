CREATE OR REPLACE FUNCTION spCheckDocument ( text )
RETURNS boolean AS
$$
BEGIN
        return(SELECT EXISTS(SELECT 1 FROM public."Customer" WHERE "Document" = $1));
END;
$$ LANGUAGE 'plpgsql';