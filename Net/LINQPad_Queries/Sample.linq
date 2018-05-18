<Query Kind="Expression" />

from x in Enumerable.Range(1,10)
where (x % 2) == 0
select new { index = x}