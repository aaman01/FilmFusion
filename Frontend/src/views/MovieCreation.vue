<template>
  <v-container class="container" fluid>
    <v-row class="">
      <p v-if="loadingUpdate">Loading entity lists.....</p>
      <v-col md="9" cols="12" class="col" v-else>
        <movie-form :id="id" :movieInfo="movieInfo"></movie-form>
      </v-col>
    </v-row>
    <!-- <entity-creation
      :title="modalTitle"
      :isOpen="modalOpen"
      @close-model="closeModal"
    ></entity-creation> -->
  </v-container>
</template>
<script>
import MovieForm from "../components/ui/MovieForm.vue";
export default {
  components: { MovieForm },
  props: ["id"],
  data() {
    return {
      isLoading: false,
      movieInfo: [],
      error: null,
    };
  },
  computed: {
    loadingUpdate() {
      return this.isLoading;
    },
  },
  methods: {
    async loadEntityList() {
      this.isLoading = true;
      try {
        await this.$store.dispatch("loadActors");
        await this.$store.dispatch("loadProducers");
        await this.$store.dispatch("loadGenres");
        this.movieInfo = this.$store.getters["movies"].find(
          (movie) => movie.id == this.id
        );
        console.log(this.movieInfo);
      } catch (error) {
        this.error = error.message;
      }
      this.isLoading = false;
    },
  },
  created() {
    this.loadEntityList();
  },
};
</script>

<style scoped>
.row {
  display: flex;
  justify-content: center;
  align-items: center;
}
.container {
  background-color: #f5f5f5;
  padding-top: 20px;
  min-height: 100vh;
}
.col {
  background-color: white;
  border: 1px solid black;
}
</style>