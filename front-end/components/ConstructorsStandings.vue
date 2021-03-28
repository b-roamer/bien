<template>
  <div>
    <p class="text-5xl font-bold">Constructors Standings</p>
    <hr />
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
            placeholder="Name of the constructor"
          >
            <template #icon>
              <i class="bx bx-search"></i>
            </template>
          </vs-input>
        </div>
        <!--  -->
        <div class="mb-4">
          <p>Race</p>
          <vs-input
            class="w-full"
            color="#e10600"
            icon-after
            v-model="pagination.Race"
            placeholder="Name of the race"
          >
            <template #icon>
              <i class="bx bx-search"></i>
            </template>
          </vs-input>
        </div>
        <!--  -->
        <div class="mb-4">
          <p>Year</p>
          <vs-input
            class="w-full"
            color="#e10600"
            icon-after
            v-model="pagination.Year"
            placeholder="Year of the race"
          >
            <template #icon>
              <i class="bx bx-search"></i>
            </template>
          </vs-input>
        </div>
        <!--  -->
        <div class="mb-8">
          <p>Nationality</p>
          <vs-select
            filter
            color="#e10600"
            placeholder="Nationality of the constructor"
            v-model="pagination.Nationality"
            :key="countries[0]"
          >
            <vs-option
              v-for="(country, index) in countries"
              :label="country"
              :value="country"
              :key="index"
            >
              {{ country }}
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
              <vs-th> Nationality </vs-th>
              <vs-th> Race </vs-th>
              <vs-th> Date </vs-th>
              <vs-th> Points </vs-th>
              <vs-th> Position </vs-th>
            </vs-tr>
          </template>
          <template #tbody>
            <vs-tr :key="i" v-for="(tr, i) in items">
              <vs-td>
                {{ tr.name }}
              </vs-td>
              <vs-td>
                {{ tr.nationality }}
              </vs-td>
              <vs-td>
                {{ tr.race }}
              </vs-td>
              <vs-td>
                {{ $moment(tr.date).format('DD MMMM YYYY') }}
              </vs-td>
              <vs-td>
                {{ tr.points }}
              </vs-td>
              <vs-td>
                {{ tr.position }}
              </vs-td>

              <template v-if="tr.url" #expand>
                <vs-button @click="openLink(tr.url)" color="#e10600"
                  >Wikipedia</vs-button
                >
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
  name: 'ConstructorsStandings',
  data() {
    return {
      countries: ['as'],
      pagination: {
        Nationality: '',
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
    getCountries() {
      this.$axios
        .$get('Constructors/GetCountries')
        .then((res) => (this.countries = res.sort()))
    },
    get() {
      this.$axios
        .$get('Constructors/GetStandings', { params: this.pagination })
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
    this.getCountries()
    this.get()
  },
}
</script>

<style>
</style>