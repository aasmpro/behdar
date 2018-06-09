SELECT        fname, lname, ncode, password, status, type, username
FROM            [user]
WHERE        (username = @org_username)