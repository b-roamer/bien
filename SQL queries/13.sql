-- How to get fastest laptimes in races on particular circuit in every season? (Bahrain International Circuit)
select race.name, race.date, lt.lap, lt.time, lt.milliseconds
from lap_times lt 
join races race
on lt.raceId = race.raceId
where race.circuitId = (select circuitId from circuits where name = 'Bahrain International Circuit')
order by lt.time
limit 100;