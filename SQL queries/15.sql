-- Which constructor holds the record for the most wins in a season? (British Grand Prix, 2004) 
select c.name 
from constructors c 
join constructor_standings cs
on c.constructorId = cs.constructorId
join races race
on cs.raceId = race.raceId
where race.raceId = 100
order by cs.wins desc
limit 1;