-- How to see the drivers that participated in a particular race (Spanish Grand Prix 1987)? 
select driver.driverRef, driver.number, driver.code, driver.forename, driver.surname, driver.dob, driver.nationality, driver.url
from drivers driver
where driver.driverId in (select r.driverId from results r where r.raceId = 400);