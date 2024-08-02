<template>
  <v-app class="px-3">
    <the-header></the-header>
    <router-view></router-view>
  </v-app>
</template>

<script>
import TheHeader from "./components/layouts/TheHeader.vue";
export default {
  components: { TheHeader },
};
</script>

