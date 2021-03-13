-- How to see the circuit and pitstop times of a race won by a particular driver (Lewis Hamilton)? 
select r.name as 'Race Name', c.name as 'Circuit', ps.duration, ps.milliseconds, ps.stop, ps.lap, ps.time
from results res
join races r 
on res.raceId = r.raceId 
join circuits c
on r.circuitId = c.circuitId
join pit_stops ps 
on r.raceId = ps.raceId
where res.driverId = 1 and res.position = 1;