-- How to see driver standings of a driver who showed the their best results 4 seasons in a row? (Bahrain, Spanish, Monacco, Turkish Grand Prix, 2009) 
select driver.forename, driver.surname, ds.points, ds.position, ds.wins
from drivers driver 
join driver_standings ds 
on driver.driverId = ds.driverId
join results res
on driver.driverId = res.driverId
where res.raceId in (4, 5, 6, 7) and res.position = 1 and ds.position = 1
order by ds.points desc
limit 4;