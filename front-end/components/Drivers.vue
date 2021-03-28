<template>
  <div>
    <p class="text-5xl font-bold">Drivers</p>
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
            placeholder="Name of the driver"
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
              <vs-th> Reference </vs-th>
              <vs-th> Number </vs-th>
              <vs-th> Code </vs-th>
              <vs-th> Birthday </vs-th>
              <vs-th> Nationality </vs-th>
            </vs-tr>
          </template>
          <template #tbody>
            <vs-tr :key="i" v-for="(tr, i) in items">
              <vs-td>
                {{ tr.forename + ' ' + tr.surname }}
              </vs-td>
              <vs-td>
                {{ tr.driverRef }}
              </vs-td>
              <vs-td>
                {{ tr.number || '-' }}
              </vs-td>
              <vs-td>
                {{ tr.code || '-' }}
              </vs-td>
              <vs-td>
                {{ $moment(tr.dob).format('DD MMMM YYYY') }}
              </vs-td>
              <vs-td>
                {{ tr.nationality }}
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
  name: 'Races',
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
        .$get('Drivers/GetCountries')
        .then((res) => (this.countries = res.sort()))
    },
    get() {
      this.$axios
        .$get('Drivers', { params: this.pagination })
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