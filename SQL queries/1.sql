-- Can you get a list of all the races and their circuits? 
select race.name as 'Race Name', circuit.name as 'Circuit', race.year as 'Year'
from races race
join circuits circuit 
on race.circuitId = circuit.circuitId
order by race.year desc;