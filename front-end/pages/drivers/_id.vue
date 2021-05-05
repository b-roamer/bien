<template>
  <div class="px-8 lg:px-64 pt-16 pb-32">
    <p class="text-5xl font-bold">
      {{ `${item.driver.forename} ${item.driver.surname}` }}
      <small class="text-xl"
        >{{ item.driver.code }} {{ item.driver.number }}</small
      >
    </p>
    <hr />
    <div class="grid grid-cols-3 gap-4 mt-8">
      <div class="rounded-lg border p-4">
        <p class="text-xl font-bold mb-4">Info</p>
        <!--  -->
        <p>
          Nationality:
          <span style="color: #e10600">{{ item.driver.nationality }}</span>
        </p>
        <p>
          Date of birth:
          <span style="color: #e10600"
            >{{ $moment(item.driver.dob).format('DD MMMM YYYY') }} ({{
              $moment().diff($moment(item.driver.dob), 'years')
            }}
            years old)</span
          >
        </p>
        <p>
          Driver reference:
          <span style="color: #e10600">{{ item.driver.driverRef }}</span>
        </p>
        <p>
          Total number of races:
          <span style="color: #e10600">{{ item.totalRaces }}</span>
        </p>
        <p>
          Total number of points:
          <span style="color: #e10600">{{ item.totalPoints }}</span>
        </p>
        <vs-button
          v-if="item.driver.url"
          @click="openLink(item.driver.url)"
          color="#e10600"
          >Wikipedia</vs-button
        >
        <!--  -->
      </div>
      <div class="col-span-2 rounded-lg border p-4">
        <vs-table v-if="item.results.length > 0">
          <template #thead>
            <vs-tr>
              <vs-th> Race </vs-th>
              <vs-th> Circuit </vs-th>
              <vs-th> Date </vs-th>
              <vs-th> Constructor </vs-th>
              <vs-th> Number </vs-th>
              <vs-th> Grid </vs-th>
              <vs-th> Position </vs-th>
              <vs-th> Points </vs-th>
              <vs-th> Laps </vs-th>
              <vs-th> Time </vs-th>
              <vs-th> Rank </vs-th>
              <vs-th> Status </vs-th>
            </vs-tr>
          </template>
          <template #tbody>
            <vs-tr :key="i" v-for="(tr, i) in item.results">
              <vs-td>
                {{ tr.name }}
              </vs-td>
              <vs-td>
                {{ tr.circuit }}
              </vs-td>
              <vs-td> {{ $moment(tr.date).format('DD MMMM YYYY') }} </vs-td>
              <vs-td>
                {{ tr.constructor }}
              </vs-td>
              <vs-td>
                {{ tr.number }}
              </vs-td>
              <vs-td>
                {{ tr.grid }}
              </vs-td>
              <vs-td>
                {{ tr.position }}
              </vs-td>
              <vs-td>
                {{ tr.points }}
              </vs-td>
              <vs-td>
                {{ tr.laps }}
              </vs-td>
              <vs-td>
                {{ tr.time }}
              </vs-td>
              <vs-td>
                {{ tr.ranks }}
              </vs-td>
              <vs-td>
                {{ tr.status }}
              </vs-td>
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
            :disabled="item.results.length < pagination.PageSize"
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
  async asyncData({ $axios, params }) {
    const item = await $axios
      .get(`Drivers/${params.id}`, { params: { page: 1, pageSize: 5 } })
      .then((res) => res.data)

    return { item }
  },
  data() {
    return {
      pagination: {
        Page: 1,
        PageSize: 5,
      },
      item: {},
    }
  },
  watch: {
    'pagination.Page'() {
      this.get()
    },
  },
  methods: {
    async get() {
      await this.$axios
        .get(`Drivers/${this.$route.params.id}`, { params: this.pagination })
        .then((res) => (this.item = res.data))
    },
    openLink(link) {
      window.open(link, '_blank')
    },
  },
}
</script>

<style>
</style>