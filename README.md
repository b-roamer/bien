# Bien
### The Ultimate Archive of Formula-1 Races 
---


#### Description
*Bien* is the online archive of all Formula-1 races gathered in one place. 
Since the history of Formula-1 dates back to times way before web applications were even heard of, it is essential to digitilize the existing data in order to keep track of the history and help people learn about this beautiful and legendary sport.

---

#### Project Scope
*Bien* can be thought of as a digitilized library, an archive of the legendary Formula-1 races. From searching throughout the history of all the races and getting detailed information about the drivers, to seeing each individual pitstop duration of any race and the laptimes of anyone, *Bien* is the ultimate helper in diving deep into the world of Formula-1.

You can look through the drivers qualifications, their standings in each race, status in the races they participated and their technical information such as their code names and wikipedia pages. 

*Bien* also allows you to search through the circuits where the races were held and visit their wikipedia pages, get a detailed information about any race and their results. 

---

#### Technologies used in the project 
*Bien* is a web application built using the following stack:
* Frontend - NuxtJS (VueJS Framework)
* Backend - ASP.NET 5 (C#)
* Database - MySQL

NuxtJS is a framework for VueJS, a component based JavaScript framework, that allows server-side rendering.

ASP.NET 5 is a C# framework for building extremely fast and secure web applications.

MySQL is a simple SQL database that is perfectly compatible with C#.

---

#### F.A.Q.
**Q**: What is the purpose of *Bien*? <br />
**A**: *Bien* is the ultimate source of historical data of all Formula-1 Races and was made to keep the legacy of it in the medium available for everyone. 

**Q**: Who has the access to *Bien*? <br />
**A**: *Bien* is an open-source, free-to-use web application that does not require any specific access permissions. As long as you have an internet connection, you are more than welcome to use it.

**Q**: Who will use *Bien*? <br />
**A**: Anyone who has at least the slightest interest in the grand history of Formula-1 Races. 

**Q**: How to see the drivers that participated in a particular race? <br />
**A**: *Bien* allows you to search for any driver in its database who participated in any of the Formula-1 Races from 1950 to 2020.

**Q**: Can you see the pitstops of the drivers? <br />
**A**: By connecting the driver's id with the race id, you can view the pitstop information, and then joining the drivers table with races table, you can get further details.

**Q**: How to see the circuit and pitstop times of a race won by a particular driver? <br />
**A**: By joining the races table with the results table, and sorting them by their positions from the positions table, and getting the driver information from the drivers table, as well as the circuit information from the circuits table and the pitstops data from the pitstops table, we can get the full information about the circuit and pitstop times of the winner.

**Q**: Can you see the driver standings of a driver who was disqualified on a particular circuit in a particular year? <br />
**A**: By connecting the status table with the results table, and getting the races in that particular year from the races table, and joining the drivers table with the driver standings table and their statuses, we can filter the disqualified drivers. 

**Q**: How to see the total pitstop duration of a driver who has won a race in particular year in a particular circuit? <br />
**A**: To see that, we need to find the requested race by the year in the races table, and get the driver standings of it from the driver standings table, and join the circuit table with the races table to get the circuit of the race, and then sum up all the pitstop duration times in the pitstop table by the driver who has won that race, and get his information from the drivers table.

**Q**: How to see driver standings of a driver who showed the their best results 4 seasons in a row? <br />
**A**: In order to do that, we have to get the results from the results table, find all the races that the driver has participated in, and find the 4 years of his best results that were in a row, join that with the driver standings table, and join the drivers table to get the information about the driver. 

**Q**: Can you get all the laptimes of a particular driver in each season they have participated in and in each circuit that they have driven in? <br />
**A**: Yes, by joining the laptimes table with the results table to get the seasons, and finding the required driver by connecting it to the drivers table, and joining the circuits table to get the circuit that the race was held on, we can get all of the laptimes of the driver in each season and in each circuit.

**Q**: Can you find the qualifying position of a driver who has been disqualified from a particular race? <br />
**A**: By joining the results with the races table to get the needed race, and joining it with the drivers table to get the required driver, we can connect it to the status table to find the races where the driver has been disqualified, and get the qualifying position from the qualifying table by connecting it to the race id and driver id. 

**Q**: How to get the laptime of a driver from the longest pitstop to the next pitstop in a particular lap in a particular race? <br />
**A**: To get it, we have to join the race from the races table, and find the required driver in that race by connecting the drivers table, and get the longest pitstop of the requested lap from the pitstops table and find the lap time of the until the pitstop from the laptimes table. 

**Q**: How to get fastest laptimes in races on particular circuit in every season? <br />
**A**: We have to find the races that were held in that circuit from the results table, and get the fastest lap time of that race from the laptimes table in every season. 

**Q**: Who is the youngest winner in every season?  <br />
**A**: By connecting the results table with the drivers table and the driver standings table, we can group the races by the season and get the youngest winners in each season. To get their full info we can join it the drivers table.

**Q**: Which constructor holds the record for the most wins in a season? <br />
**A**: By joining the races table with the constructor standings table and constructors table, we can group the races by the seasons and get the constructor with the most number of wins in every season. 

--- 

#### Dataset

[This](https://www.kaggle.com/rohanrao/formula-1-world-championship-1950-2020?select=pit_stops.csv) dataset was used in the project due to the fact that conforms all of the requirements and is quite large (~18 MB).

```
circuits (
	circuitId int PK,
    circuitRef string,
    name string,
    location string,
    country string,
    lat float,
    lng float,
    alt float,
    url string
)

constructor_results (
	id int PK,
    raceId int FK,
    constructorId int FK,
    points int,
    status int FK
)

constructor_standings (
	id int PK,
    raceId int FK,
    constructorId int FK,
    points int,
    position int,
    positionText string,
    wins int
)

constructors (
	id int PK,
    constructorRef string,
    name string,
    nationality string,
    url string
)

driver_standings (
	id int PK,
    raceId int FK,
    driverId int FK,
    points int,
    position int,
    positionText string,
    wins int
)

drivers (
	id int PK,
    driverRef string,
    number int,
    code string,
    forename string,
    surname string,
    dob date,
    nationality string,
    url string
)

lap_times (
	raceId int FK,
    driverId int FK,
    lap int,
    position int, 
    time string,
    milliseconds int
)

pit_stops (
	raceId int FK,
    driverId int FK,
    stop int,
    lap int,
    time string,
    duration float,
    milliseconds int
)

qualifying (
	qualifyId int PK,
    raceId int FK,
    driverId int FK,
    constructorId int FK,
    number int,
    position int,
    q1 string, 
    q2 string,
    q3 string
)

races (
	raceId int PK,
    year int, 
    round int, 
    circuitId int FK,
    name string,
    date date,
    time string,
    url string
)

results (
	resultId int PK,
    raceId int FK,
    driverId int FK,
    constructorId int FK,
    number int,
    grid int,
    position int,
    positionText string,
    positionOrder int,
    points int,
    laps int,
    time string,
    milliseconds int,
    fastestLap int,
    rank int, 
    fastestLapTime string,
    fastestLapSpeed float,
    statusId int FK
)

seasons (
	year int PK,
    url string
)

status (
	statudId int PK,
    status string
)
```
