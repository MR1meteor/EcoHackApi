SELECT
    rt.id           as "Id",
    rt.email        as "Email",
    rt.token        as "Token",
    rt.expiration   as "Expiration"
FROM registration_tokens rt
WHERE token = @Token