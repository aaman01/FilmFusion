<template>
  <v-dialog v-model="open" max-width="550px">
    <v-card>
      <v-card-title class="card-title">
        <div id="title">
          {{ movieInfo.name }}
        </div>
        <v-btn small id="close-btn" @click="close">
          <v-icon> mdi-close </v-icon>
        </v-btn>
      </v-card-title>
      <div class="image">
        <v-img
          :src="movieInfo.image"
          height="350px"
          width="100%"
          aspect-ratio="1/1"
          contain
        ></v-img>
      </div>
      <v-card-text class="description pa-6">
        <div class="align_values">
          <b>Release Year:</b>
          <span class="pl-1">{{ movieInfo.yearOfRelease }}</span>
        </div>
        <hr />
        <div class="align_values">
          <b>Genres:</b>
          <span class="pl-1">{{ genreNames }}</span>
        </div>
        <hr />
        <div class="align_values">
          <b>Producer:</b>
          <span class="pl-1">{{ movieInfo.producer.name }}</span>
        </div>
        <hr />
        <div class="align_values">
          <b>Actors:</b>
          <span class="pl-1"> {{ actorNames }}</span>
        </div>
        <hr />
        <div class="align_values">
          <b>Plot:</b> <span class="pl-1"> {{ movieInfo.plot }}</span>
        </div>
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  props: ["id"],
  data() {
    return {
      open: true,
      movieInfo: null,
    };
  },
  computed: {
    genreNames() {
      return this.movieInfo.genre.map((g) => g.name).join(", ");
    },
    actorNames() {
      return this.movieInfo.actor.map((a) => a.name).join(", ");
    },
  },
  watch: {
    open(newval) {
      if (!newval) {
        this.close();
      }
    },
  },
  methods: {
    close() {
      this.open = false;
      this.$router.push("/movies");
    },
    getMovieById() {
      this.movieInfo = this.$store.getters["movies"].find(
        (movie) => movie.id == this.id
      );
    },
  },
  created() {
    this.getMovieById();
  },
};
</script>
<style scoped>
.card-title {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background: #2c3e50;
}
#title {
  color: #ffffff;
}
#close-btn {
  background: #dc3545;
}
.image {
  padding: 10px;
  background-color: #f5f5f5;
}
.description {
  padding: 10px;
  background-color: #ececec;
  text-align: justify;
}
.align_values {
  font-size: 16px;
  padding: 5px;
  display: flex;
}
</style>
