UPDATE       prescription
SET                flname = @flname, ncode = @ncode, creator = @creator, insurance = @insurance, date = @date
WHERE        (id = @org_id)