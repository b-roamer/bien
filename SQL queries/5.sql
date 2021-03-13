-- Can you see the pitstops of the drivers (Canadian Grand Prix 2011)? 
select driver.forename, driver.surname, ps.stop, ps.lap, ps.time, ps.duration, ps.milliseconds
from drivers driver
join pit_stops ps
on driver.driverId = ps.driverId
where ps.raceId = 847;