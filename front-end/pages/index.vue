<template>
  <div @page-change="test($event)">
    <div class="relative">
      <video id="vid" autoplay muted loop width="100%">
        <source src="/video.mp4" type="video/mp4" />
      </video>
      <div
        class="absolute bg-black bg-opacity-70 top-0 text-center w-full h-full text-white text-9xl"
      >
        <div class="flex justify-center items-center h-full">
          <div>
            <p class="mb-8 font-bold">Bien</p>
            <p class="text-6xl">
              The Ultimate Archive of<br />
              <span class="font-bold red-under">Formula-1 Races</span>
            </p>
          </div>
        </div>
      </div>
    </div>
    <div class="px-8 lg:px-64 pt-32 pb-32">
      <LandingSection image>
        <template #q>What is Bien?</template>
        <template #a>
          <span class="font-bold text-red">Bien</span> is the online archive of
          all <span class="font-bold text-red">Formula-1</span> races gathered
          in one place. Since the
          <span class="font-bold text-red"> history of Formula-1</span> dates
          back to times way before web applications were even heard of, it is
          essential to digitilize the existing data in order to keep track of
          the history and help people learn about this
          <span class="font-bold text-red">beautiful</span> and
          <span class="font-bold text-red">legendary</span>
          sport.
        </template>
      </LandingSection>
      <LandingSection>
        <template #q>Features</template>
        <template #a>
          <span class="font-bold text-red">Bien</span> can be thought of as a
          digitilized library, an archive of the legendary Formula-1 races. From
          searching throughout the history of
          <span class="font-bold text-red">all the races</span> and getting
          detailed information about the
          <span class="font-bold text-red">drivers</span>, to seeing each
          <span class="font-bold text-red">individual pitstop duration</span>
          of any race and the
          <span class="font-bold text-red">laptimes</span> of anyone, Bien is
          the ultimate helper in diving deep into the world of Formula-1.
          <br />
          <br />
          You can look through the
          <span class="font-bold text-red">drivers' qualifications</span>, their
          standings in each race, status in the races they participated and
          their technical information such as their
          <span class="font-bold text-red">code names</span> and wikipedia
          pages.
          <br />
          <br />
          Bien also allows you to search through the
          <span class="font-bold text-red">circuits</span> where the races were
          held and visit their wikipedia pages, get a detailed information about
          any race and their <span class="font-bold text-red">results</span>.
        </template>
      </LandingSection>
      <LandingSection>
        <template #q> Technologies used in the project </template>
        <template #a>
          <span class="font-bold text-red">Bien</span> is a web application
          built using the following stack:
        </template>
      </LandingSection>
      <div
        class="flex lg:justify-between lg:flex-row flex-col justify-center mb-28"
      >
        <vs-card class="mx-auto lg:mx-0 mb-4">
          <template #title>
            <h3>NuxtJS</h3>
          </template>
          <template #img>
            <img src="/nuxt-icon.png" alt="" />
          </template>
          <template #text>
            <p>
              NuxtJS is a framework for VueJS, a component based JavaScript
              framework, that allows server-side rendering.
            </p>
          </template>
          <template #interactions>
            <vs-button color="#e10600" icon>
              <a href="https://nuxtjs.org/" target="_blank">
                <i class="bx bx-home"></i
              ></a>
            </vs-button>
          </template>
        </vs-card>
        <vs-card class="mx-auto lg:mx-0 mb-4">
          <template #title>
            <h3>ASP.NET 5</h3>
          </template>
          <template #img>
            <img src="/dotnet.png" alt="" />
          </template>
          <template #text>
            <p>
              ASP.NET 5 is a C# framework for building extremely fast and secure
              web applications.
            </p>
          </template>
          <template #interactions>
            <vs-button color="#e10600" icon>
              <a
                href="https://dotnet.microsoft.com/apps/aspnet"
                target="_blank"
              >
                <i class="bx bx-home"></i
              ></a>
            </vs-button>
          </template>
        </vs-card>
        <vs-card class="mx-auto lg:mx-0 mb-4">
          <template #title>
            <h3>MySQL</h3>
          </template>
          <template #img>
            <img src="/mysql.png" alt="" />
          </template>
          <template #text>
            <p>
              MySQL is a simple SQL database that is perfectly compatible with
              C#.
            </p>
          </template>
          <template #interactions>
            <vs-button color="#e10600" icon>
              <a href="https://www.mysql.com/" target="_blank">
                <i class="bx bx-home"></i
              ></a>
            </vs-button>
          </template>
        </vs-card>
      </div>
      <LandingSection>
        <template #q>F.A.Q.</template>
        <template #a>
          <vs-alert class="mt-8" color="#e10600" shadow>
            <template #title>
              Q: Can you get a list of all the races and their circuits?
            </template>
            A: Absolutely! Every race has its own circuit which you can get by
            joining the races table with the circuits table by circuit id.
          </vs-alert>
          <vs-alert class="mt-8" color="#e10600" shadow>
            <template #title>
              Q: How can I see the results of the constructors in a particular
              season?
            </template>
            A: Via connecting the races table with the constructor results
            table, and filtering the required season, you can get the desired
            results.
          </vs-alert>
          <vs-alert class="mt-8" color="#e10600" shadow>
            <template #title>
              Q: Can I get the Wikipedia page of a driver who won in a
              particular race?
            </template>
            A: By joining the races table with the driver standings table, you
            can easily find out the winners Wikipedia URL if it is present in
            the database.
          </vs-alert>
          <vs-alert class="mt-8" color="#e10600" shadow>
            <template #title>
              Q: How to see the drivers that participated in a particular race?
            </template>
            A: Bien allows you to search for any driver in its database who
            participated in any of the Formula-1 Races from 1950 to 2020.
          </vs-alert>
          <vs-alert class="mt-8" color="#e10600" shadow>
            <template #title>
              Q: Can you see the pitstops of the drivers who participated in a
              particular race?
            </template>
            A: By connecting the driver's id with the race id and the pitstops
            table, you can view the pitstop information.
          </vs-alert>
          <vs-alert class="mt-8" color="#e10600" shadow>
            <template #title>
              Q: How to see the circuit and pitstop times of a race won by a
              particular driver?
            </template>
            A: By joining the races table with the results table, and sorting
            them by their positions from the driver standings table, and getting
            the driver information from the drivers table, as well as the
            circuit information from the circuits table and the pitstops data
            from the pitstops table, we can get the full information about the
            circuit and pitstop times of the winner.
          </vs-alert>
          <vs-alert class="mt-8" color="#e10600" shadow>
            <template #title>
              Q: Can you see the driver standings of a driver who was
              disqualified on a particular circuit in a particular year?
            </template>
            A: By connecting the status table with the results table, and
            getting the races in that particular year from the races table, and
            joining the drivers table with the driver standings table and their
            statuses, we can filter the disqualified drivers.
          </vs-alert>
          <vs-alert class="mt-8" color="#e10600" shadow>
            <template #title>
              Q: How to see the total pitstop duration of a driver who has won a
              race in particular year in a particular circuit?
            </template>
            Q: How to see the total pitstop duration of a driver who has won a
            race in particular year in a particular circuit?
          </vs-alert>
          <vs-alert class="mt-8" color="#e10600" shadow>
            <template #title>
              Q: How to see driver standings of a driver who showed the their
              best results 4 seasons in a row?
            </template>
            A: In order to do that, we have to get the results from the results
            table, find all the races that the driver has participated in, and
            find the 4 years of his best results that were in a row, join that
            with the driver standings table, and join the drivers table to get
            the information about the driver.
          </vs-alert>
          <vs-alert class="mt-8" color="#e10600" shadow>
            <template #title>
              Q: Can you get all the laptimes of a particular driver in each
              season they have participated in and in each circuit that they
              have driven in?
            </template>
            A: Yes, by joining the laptimes table with the results table to get
            the seasons, and finding the required driver by connecting it to the
            drivers table, and joining the circuits table to get the circuit
            that the race was held on, we can get all of the laptimes of the
            driver in each season and in each circuit.
          </vs-alert>
          <vs-alert class="mt-8" color="#e10600" shadow>
            <template #title>
              Q: Can you find the qualifying position of a driver who has been
              disqualified from a particular race?
            </template>
            A: By joining the results with the races table to get the needed
            race, and joining it with the drivers table to get the required
            driver, we can connect it to the status table to find the races
            where the driver has been disqualified, and get the qualifying
            position from the qualifying table by connecting it to the race id
            and driver id.
          </vs-alert>
          <vs-alert class="mt-8" color="#e10600" shadow>
            <template #title>
              Q: How to get the laptime of a driver from the longest pitstop to
              the next pitstop in a particular lap in a particular race?
            </template>
            A: To get it, we have to join the race from the races table, and
            find the required driver in that race by connecting the drivers
            table, and get the longest pitstop of the requested lap from the
            pitstops table and find the lap time of the until the pitstop from
            the laptimes table.
          </vs-alert>
          <vs-alert class="mt-8" color="#e10600" shadow>
            <template #title>
              Q: How to get fastest laptimes in races on particular circuit in
              every season?
            </template>
            A: We have to find the races that were held in that circuit from the
            results table, and get the fastest lap time of that race from the
            laptimes table in every season.
          </vs-alert>
          <vs-alert class="mt-8" color="#e10600" shadow>
            <template #title>
              Q: Who is the youngest winner in every season?
            </template>
            A: By connecting the results table with the drivers table and the
            driver standings table, we can group the races by the season and get
            the youngest winners in each season. To get their full info we can
            join it the drivers table.
          </vs-alert>
          <vs-alert class="mt-8" color="#e10600" shadow>
            <template #title>
              Q: Which constructor holds the record for the most wins in a
              season?
            </template>
            A: By joining the races table with the constructor standings table
            and constructors table, we can group the races by the seasons and
            get the constructor with the most number of wins in every season.
          </vs-alert>
        </template>
      </LandingSection>
    </div>
  </div>
</template>

<script>
import LandingSection from '@/components/LandingSection'
export default {
  components: { LandingSection },
  methods: {
    test(id) {
      console.log(id)
    },
  },
}
</script>

<style>
</style>
