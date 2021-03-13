-- Can you see the driver standings of a driver who was disqualified on a particular circuit in a particular year (Autodromo Enzo 2 Dino Ferrari, 2005)? 
select driver.forename, driver.surname, ds.points, ds.position, ds.wins 
from driver_standings ds 
join results res 
on ds.raceId = res.raceId
join drivers driver
where res.statusId = 2 and res.raceId = 74;