UPDATE       insurance
SET                name = @name, [off] = @off
WHERE        (id = @org_id)