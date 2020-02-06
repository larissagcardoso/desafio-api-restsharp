SELECT a.id, a.summary, b.description, c.id, c.name, a.category_id, d.name, e.id, e.username, e.realname, e.email,  a.status, a.resolution , a.view_state, a.priority, a.severity, a.reproducibility, 
a.sticky, DATE_FORMAT(FROM_UNIXTIME(a.date_submitted), "%d/%m/%Y %T") AS created_at,  DATE_FORMAT(FROM_UNIXTIME(a.last_updated),  "%d/%m/%Y %T")  AS updated_at , DATE_FORMAT(FROM_UNIXTIME(f.date_modified),  "%d/%m/%Y %T")  AS created_at ,f.user_id, g.username, g.realname, g.email, f.type
FROM mantis_bug_table AS a
INNER JOIN mantis_bug_text_table AS b
ON a.id = b.id
INNER JOIN mantis_project_table AS c
ON a.project_id = c.id
INNER JOIN mantis_category_table AS d
ON a.category_id = d.id
INNER JOIN mantis_user_table AS e
ON a.reporter_id = e.id
INNER JOIN mantis_bug_history_table as F
ON a.id = f.bug_id
INNER JOIN mantis_user_table AS G
ON f.user_id = g.id
ORDER BY a.id DESC
