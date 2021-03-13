-- Can you find the qualifying position of a driver who has been disqualified from a particular race? (Canadian Grand Prix, 2007)
select driver.forename, driver.surname, q.number, q.position, q.q1, q.q2, q.q3
from qualifying q
join results res
on q.raceId = res.raceId
join races r
on res.raceId = r.raceId
join drivers driver
on q.driverId = driver.driverId
where r.name = 'Canadian Grand Prix' and year(r.date) = 2007 and res.statusId = 2;