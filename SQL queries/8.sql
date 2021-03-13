-- How to see the total pitstop duration of a driver who has won a race in particular year in a particular circuit? (Albert Park Grand Prix Circuit, 2011) 
select driver.forename, driver.surname, sum(ps.duration)
from results res 
join drivers driver
on res.driverId = driver.driverId
join pit_stops ps 
on res.raceId = ps.raceId
where res.raceId = (select raceId from races r where r.circuitId = 1 and year(r.date) = 2011) and res.position = 1
group by res.driverId;