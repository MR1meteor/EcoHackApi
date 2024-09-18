UPDATE book_elements be
SET
    type        = @Type,
    name        = @Name,
    description = @Description,
    reason      = @Reason,
    population  = @Population,
    family      = @Family,
    appearance  = @Appearance,
    behavior    = @Behavior,
    nutrition   = @Nutrition
WHERE id = @Id
RETURNING
    be.id          as "Id",
    be.type        as "Type",
    be.name        as "Name",
    be.description as "Description",
    be.reason      as "Reason",
    be.population  as "Population",
    be.family      as "Family",
    be.appearance  as "Appearance",
    be.behavior    as "Behavior",
    be.nutrition   as "Nutrition"