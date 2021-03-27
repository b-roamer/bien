<template>
  <div class="">
    <vs-navbar
      text-white
      color="#e10600"
      class="sticky"
      center-collapsed
      v-model="active"
    >
      <template #left>
        <img src="/logo.png" alt="" width="20%" />
      </template>
      <template #right>
        <vs-navbar-item to="/" :active="active == 'home'" id="home">
          <i class="bx bxs-home mr-1"></i>Home
        </vs-navbar-item>
        <vs-navbar-item
          to="/circuits"
          :active="active == 'circuits'"
          id="circuits"
        >
          <i class="bx bxs-map-alt mr-1"></i>Circuits
        </vs-navbar-item>
        <vs-navbar-item
          to="/constructors"
          :active="active == 'constructors'"
          id="constructors"
        >
          <i class="bx bxs-car mr-1"></i>Constructors
        </vs-navbar-item>
        <vs-navbar-item to="/races" :active="active == 'races'" id="races">
          <i class="bx bxs-flag-checkered mr-1"></i>Races
        </vs-navbar-item>
      </template>
    </vs-navbar>
    <Nuxt class="-mt-8 min-h-screen" />
    <div
      class="w-full bg-gray-900 h-64 text-white flex justify-center items-center text-center"
    >
      <div>
        <img class="mx-auto mb-4" src="f1-logo-red.png" alt="" width="50%" />
        <p class="text-3xl font-bold">Bien</p>
        <p class="text-xl">
          The Ultimate Archive of<br />
          <span class="font-bold red-under">Formula-1 Races</span>
        </p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      active:
        this.$route.path === '/' ? 'home' : this.$route.path.replace('/', ''),
    }
  },
}
</script>


<style>
button:focus {
  outline: 0;
}
.vs-input {
  width: 100%;
}
hr {
  border-top-width: 4px;
  border-top-color: #e10600;
}
.text-red {
  color: #e10600;
}
.red-under {
  text-decoration: underline;
  text-decoration-color: #e10600;
  text-underline-offset: 8px;
}
.shadow {
  box-shadow: 0px 4px 15px 0px rgba(225, 6, 0, 0.12);
}
</style>
