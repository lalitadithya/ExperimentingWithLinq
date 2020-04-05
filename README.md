# Experimenting With LINQ

In this repository I play around with LINQ to understand expression trees and dynamic query generation. I was able to generating a SQL query for a simple LINQ expression. The query and the output are given below:


## LINQ query
```
var results = new FileSystemContext<FileSystemElement>(@"C:\")
                .Where(x => x.Size == 100 && x.Attributes.Any(x => x.Key == "readonly"))
                .Select(x => x.Path)
                .ToList();
```


## Output
```
SELECT Path
FROM FileSystemElement JOIN FileSystemAttributes Attributes
WHERE Size == 100 AND Attributes.Key == 'readonly'
```


