-- Can you get all the laptimes of a particular driver in each season they have participated in and in each circuit that they have driven in? (Leqis Hamilton)
select race.name, race.date, circuit.name, lt.lap, lt.time, lt.milliseconds
from lap_times lt
join races race 
on lt.raceId = race.raceId
join circuits circuit 
on race.circuitId = circuit.circuitId
where lt.driverId = 1;