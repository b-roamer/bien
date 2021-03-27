<template>
  <div class="px-8 lg:px-64 pt-16 pb-32">
    <p class="text-5xl font-bold">Circuits</p>
    <hr />

    <div class="grid grid-cols-3 gap-4 mt-4">
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
            placeholder="Name of the circuit"
          >
            <template #icon>
              <i class="bx bx-search"></i>
            </template>
          </vs-input>
        </div>
        <!--  -->
        <div class="mb-8">
          <p>Country</p>
          <vs-select
            filter
            color="#e10600"
            placeholder="Country of the circuit"
            v-model="pagination.Country"
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
              <vs-th> Location </vs-th>
              <vs-th> Country </vs-th>
            </vs-tr>
          </template>
          <template #tbody>
            <vs-tr :key="i" v-for="(tr, i) in items">
              <vs-td>
                {{ tr.name }}
              </vs-td>
              <vs-td>
                {{ tr.location }}
              </vs-td>
              <vs-td>
                {{ tr.country }}
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
  data() {
    return {
      countries: ['as'],
      pagination: {
        Country: '',
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
        .$get('Circuits/GetCountries')
        .then((res) => (this.countries = res.sort()))
    },
    get() {
      this.$axios
        .$get('Circuits', { params: this.pagination })
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