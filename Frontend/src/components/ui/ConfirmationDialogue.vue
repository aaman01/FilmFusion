<template>
  <v-dialog v-model="open" max-width="300px">
    <v-card>
      <v-card-title class="title pa-3">
        <b>Are you sure</b>
      </v-card-title>
      <v-card-text class="text pa-6">
        You want to delete the movie : {{ movieName }}
      </v-card-text>
      <v-card-action class="action">
        <v-btn depressed class="mr-2 green" @click="close"
          ><v-icon>mdi-close</v-icon></v-btn
        >
        <v-btn depressed class="mr-2 red" @click="remove"
          ><v-icon>mdi-check</v-icon></v-btn
        >
      </v-card-action>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  props: ["id"],
  data() {
    return {
      open: true,
    };
  },
  watch: {
    open(newval) {
      if (!newval) {
        this.close();
      }
    },
  },
  computed: {
    movieName() {
      return this.$store.getters["movies"].find(
        (movie) => movie.id == this.id
      ).name;
    },
  },
  methods: {
    close() {
      this.$router.push("/movies");
      this.open = false;
    },
    async remove() {
      await this.$store.dispatch("deleteMovie", this.id);
      this.close();
    },
  },
};
</script>
<style scoped>
.title {
  display: flex;
  justify-content: center;

  background-color: #c9cdd1;
}
.text {
  width: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}
.action {
  display: flex;
  padding: 5px;
  justify-content: center;
}
</style>