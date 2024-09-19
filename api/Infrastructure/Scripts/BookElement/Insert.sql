INSERT INTO book_elements (type, name, description, reason, population, family, appearance, behavior, nutrition, status)
VALUES (@Type, @Name, @Description, @Reason, @Population, @Family, @Appearance, @Behavior, @Nutrition, @Status)
RETURNING id as "Id"