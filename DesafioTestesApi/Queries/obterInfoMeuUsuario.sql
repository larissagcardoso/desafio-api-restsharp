SELECT id, username, realname, email, access_level
FROM mantis_user_mantis
WHERE access_level = 90
AND enabled = 1