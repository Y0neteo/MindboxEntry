
;WITH ProductsInfo AS 
(
	SELECT  
		p.Name AS Product, 
		c.Name AS Category
	FROM 
		Products p
	LEFT JOIN 
		ProductsCategories pc ON pc.ProductId = p.Id
	LEFT JOIN 
		Categories c ON c.Id = pc.CategoryId
)
	SELECT
		Product,
		STRING_AGG(Category, ', ') AS Categories
	FROM ProductsInfo
	GROUP BY Product