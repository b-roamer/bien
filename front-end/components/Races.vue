<template>
  <div>
    <p class="text-5xl font-bold">Races</p>
    <hr />
    <p>Click on a race to see the results</p>
    <div class="grid grid-cols-3 gap-4 mt-8">
      <div class="rounded-lg border p-4">
        <p class="text-xl font-bold mb-4">Filter</p>
        <!--  -->
        <div class="mb-4">
          <p>Search</p>
          <vs-input
            class="w-full"
            color="#e10600"
            icon-after
            v-model="pagination.Search"
            placeholder="Name of the race"
          >
            <template #icon>
              <i class="bx bx-search"></i>
            </template>
          </vs-input>
        </div>
        <!--  -->
        <div class="mb-4">
          <p>Circuit</p>
          <vs-input
            class="w-full"
            color="#e10600"
            icon-after
            v-model="pagination.Circuit"
            placeholder="Name of the circuit"
          >
            <template #icon>
              <i class="bx bx-search"></i>
            </template>
          </vs-input>
        </div>
        <!--  -->
        <div class="mb-8">
          <p>Year</p>
          <vs-select
            filter
            color="#e10600"
            placeholder="Year of the race"
            v-model="pagination.Year"
            :key="years[0]"
          >
            <vs-option
              v-for="(year, index) in years"
              :label="year"
              :value="year"
              :key="index"
            >
              {{ year }}
            </vs-option>
          </vs-select>
        </div>

        <vs-button @click="filter()" class="w-full" color="#e10600">
          Find
        </vs-button>
      </div>
      <div class="col-span-2 rounded-lg border p-4">
        <vs-table v-if="items.length > 0">
          <template #thead>
            <vs-tr>
              <vs-th> Name </vs-th>
              <vs-th> Circuit </vs-th>
              <vs-th> Date </vs-th>
            </vs-tr>
          </template>
          <template #tbody>
            <vs-tr :key="i" v-for="(tr, i) in items">
              <vs-td>
                {{ tr.name }}
              </vs-td>
              <vs-td>
                {{ tr.circuit }}
              </vs-td>
              <vs-td>
                {{ $moment(tr.date).format('DD MMMM YYYY') }}
              </vs-td>
              <template v-if="tr.url" #expand>
                <vs-button @click="openLink(tr.url)" color="#e10600"
                  >Wikipedia</vs-button
                >
                <vs-table striped :key="tr.raceId">
                  <template #thead>
                    <vs-tr>
                      <vs-th> Position </vs-th>
                      <vs-th> Name </vs-th>
                      <vs-th> Constructor </vs-th>
                      <vs-th> Time </vs-th>
                      <vs-th> Status </vs-th>
                      <vs-th> </vs-th>
                    </vs-tr>
                  </template>
                  <template #tbody>
                    <vs-tr :key="i" v-for="(tr, i) in tr.results" :data="tr">
                      <vs-td>
                        {{ tr.position || '-' }}
                      </vs-td>
                      <vs-td>
                        <a
                          class="text-red no-underline hover:underline"
                          :href="tr.url"
                          target="_blank"
                          rel="noopener noreferrer"
                          >{{ tr.driver }}</a
                        >
                      </vs-td>
                      <vs-td>
                        {{ tr.constructor }}
                      </vs-td>
                      <vs-td>
                        {{ tr.time || '-' }}
                      </vs-td>
                      <vs-td>
                        {{ tr.status }}
                      </vs-td>
                      <vs-td>
                        <vs-button  color="#e10600"
                          >Details</vs-button
                        >
                      </vs-td>
                    </vs-tr>
                  </template>
                </vs-table>
              </template>
            </vs-tr>
          </template>
        </vs-table>

        <div class="flex justify-between">
          <vs-button
            @click="pagination.Page -= 1"
            :disabled="pagination.Page === 1"
            icon
            circle
            color="#e10600"
            ><i class="bx bxs-left-arrow"></i
          ></vs-button>
          <vs-button
            @click="pagination.Page += 1"
            :disabled="items.length < pagination.PageSize"
            icon
            circle
            color="#e10600"
            ><i class="bx bxs-right-arrow"></i
          ></vs-button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Races',
  data() {
    return {
      years: ['as'],
      pagination: {
        Year: '',
        Search: '',
        Page: 1,
        PageSize: 10,
      },
      items: [],
    }
  },
  watch: {
    'pagination.Page'() {
      this.get()
    },
  },
  methods: {
    getYears() {
      this.$axios
        .$get('Races/getYears')
        .then((res) => (this.years = res.sort().reverse()))
    },
    get() {
      this.$axios
        .$get('Races', { params: this.pagination })
        .then((res) => (this.items = res))
    },
    openLink(link) {
      window.open(link, '_blank')
    },
    filter() {
      this.pagination.Page = 1
      this.get()
    },
  },
  mounted() {
    this.getYears()
    this.get()
  },
}
</script>

<style>
</style>