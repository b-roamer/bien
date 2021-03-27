<template>
  <div class="mb-32 lg:flex w-full">
    <div class="w-full">
      <p class="font-bold text-4xl red-under mb-4">
        <span class="text-red">#</span> <slot name="q"></slot>
      </p>
      <p class="text-xl">
        <slot name="a"></slot>
      </p>
    </div>
    <div v-if="image" class="flex ml-8 justify-center items-center">
      <img src="/f1-logo-red.png" alt="" />
    </div>
  </div>
</template>

<script>
export default {
  props: {
    image: {
      type: Boolean,
      default: false,
    },
  },
  name: 'LandingSection',
}
</script>

<style>
</style>