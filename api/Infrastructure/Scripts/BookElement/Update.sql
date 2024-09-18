UPDATE book_elements be
SET
    be.type        = @Type,
    be.name        = @Name,
    be.description = @Description
    be.reason      = @Reason
    be.population  = @Population
    be.family      = @Family
    be.appearance  = @Appearance
    be.behavior    = @Behavior
    be.nutrition   = @Nutrition
WHERE id = @Id
RETURNING
    be.id          as "Id",
    be.type        as "Type",
    be.name        as "Name",
    be.description as "Description"
    be.reason      as "Reason"
    be.population  as "Population"
    be.family      as "Family"
    be.appearance  as "Appearance"
    be.behavior    as "Behavior"
    be.nutrition   as "Nutrition"