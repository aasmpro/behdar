UPDATE       [user]
SET                username = @username, fname = @fname, lname = @lname, ncode = @ncode, type = @type, status = @status
WHERE        (username = @org_username)