<template>
  <div class="movie-wrapper">
    <router-link :to="movieAddPageLink" class="add-movie-btn"
      ><v-btn outlined>Add Movies</v-btn></router-link
    >
    <div class="add-movie-btn" v-if="isLoading">
      <p><b>Loading....</b></p>
    </div>
    <v-row class="movie-list-row" v-else-if=" hasMovieList">
      <v-col
        class="movie-list-col"
        v-for="movie in movies"
        :key="movie.id"
        sm="3"
        cols="12"
      >
        <movie-card
          :id="movie.id"
          :image="movie.image"
          :name="movie.name"
          :description="movie.plot"
        ></movie-card>
      </v-col>
    </v-row>
    <h3 class="add-movie-btn" v-else>No Movies Found</h3>
    <router-view></router-view>
  </div>
</template>

<script>
import MovieCard from "@/components/ui/MovieCard.vue";
import { mapGetters } from "vuex";
export default {
  components: {
    MovieCard,
  },

  data() {
    return {
      isLoading: false,
      error: "",
    };
  },
  computed: {
    ...mapGetters(["hasMovies", "movies"]),
    hasMovieList() {
      return !this.isLoading && this.hasMovies;
    },

    movieAddPageLink() {
      return "/add-movies";
    },
  },
  methods: {
    async loadMovies() {
      this.isLoading = true;
      try {
        await this.$store.dispatch("loadMovies");
      } catch (error) {
        this.error = error.message;
      }
      this.isLoading = false;
    },
  },
  created() {
    this.loadMovies();
    
  },
};
</script>

<style scoped>
.movie-wrapper {
  margin: 10px;
  padding: 10px;
}
.movie-list-row {
  padding: 25px 40px 40px 40px;
}
.movie-list-col {
  padding: 25px;
}
.add-movie-btn {
  margin: 10px;

  padding-left: 40px;
}
</style>


