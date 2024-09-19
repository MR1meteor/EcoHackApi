﻿SELECT
    be.id          as "Id",
    be.type        as "Type",
    be.name        as "Name",
    be.description as "Description",
    be.reason      as "Reason",
    be.population  as "Population",
    be.family      as "Family",
    be.appearance  as "Appearance",
    be.behavior    as "Behavior",
    be.nutrition   as "Nutrition",
    be.status      as "Status",
    be.image_id    as "ImageUrl"
FROM book_elements be 
WHERE id = @Id