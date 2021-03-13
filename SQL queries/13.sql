-- Who is the youngest winner in every season? 
select driver.forename, driver.surname, driver.dob
from drivers driver
join results res
on driver.driverId = res.driverId
where driver.driverId in (select ress.driverId 
from results ress
join drivers d
on ress.driverId = d.driverId
where ress.raceId = res.raceId
order by d.dob desc);