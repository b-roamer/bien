-- Can I get the Wikipedia page of a driver who won in a particular race (Monaco Grand Prix 2009)?
select driver.forename, driver.surname, driver.url
from drivers driver 
join driver_standings ds 
on driver.driverId = ds.driverId
join races r 
on ds.raceId = r.raceId
where r.raceId = 6
order by ds.points desc
limit 1;