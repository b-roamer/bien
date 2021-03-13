-- How to get the laptime of a driver from the longest pitstop to the next pitstop in a particular lap in a particular race? (Sebastian Vettel, Australian Grand Prix, 2011)
select driver.forename, driver.surname, lt.time, lt.milliseconds
from lap_times lt
join drivers driver 
on lt.driverId = driver.driverId
where lt.driverId = 20 and lt.raceId = 841
and lt.lap = (select lap from pit_stops where driverId = (select driverId from drivers where forename = 'Sebastian' and surname = 'Vettel') and raceId = (select raceId from races where name = 'Australian Grand Prix' and year(date) = 2011) order by  duration desc limit 1);