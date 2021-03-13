-- How can I see the results of the constructors in a particular season (Monaco Grand Prix 2009)? 
select c.name, cr.points, r.year
from constructors c 
join constructor_results cr 
on c.constructorId = cr.constructorId
join races r 
on r.raceId = cr.raceId
where r.raceId = 6;