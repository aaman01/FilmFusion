<template>
  <div class="form-container">
    <h1 class="pb-5">Enter Movie Details</h1>
    <v-form @submit.prevent="submitData" ref="form" v-model="valid">
      <v-text-field
        label="Movie Name"
        :rules="movieNameRules"
        v-model="movieName"
        placeholder="Enter Movie Name"
        required
      >
      </v-text-field>
      <v-text-field
        label="Year Of Release"
        :rules="yearOfReleaseRules"
        :max="maxDate"
        type="number"
        v-model="yearOfRelease"
        required
      >
      </v-text-field>
      <v-row class="actor-field">
        <v-col cols="10">
          <v-select
            class="pr-2"
            label="Actors"
            multiple
            :items="allActorList"
            required
            :rules="actorRules"
            placeholder="Select actors from the list"
            v-model="selectedActors"
          ></v-select>
        </v-col>
        <v-col cols="2" class="pl-0">
          <v-btn depressed width="100%" @click="openModal('ADD ACTOR')">
            ADD ACTOR
          </v-btn>
        </v-col>
      </v-row>

      <v-row class="producer-field">
        <v-col cols="10" class="pt-0">
          <v-select
            class="pr-2"
            label="Producers"
            :items="allProducerList"
            :rules="producerRules"
            required
            placeholder="Select producer from the list"
            v-model="selectedProducer"
          ></v-select>
        </v-col>
        <v-col cols="2" class="pl-0">
          <v-btn depressed width="100%" @click="openModal('ADD PRODUCER')">
            ADD PRODUCER
          </v-btn>
        </v-col>
      </v-row>

      <v-select
        label="Genres"
        multiple
        :rules="genreRules"
        :items="allGenreList"
        required
        placeholder="Select genres from the list"
        v-model="selectedGenres"
      ></v-select>
      <v-textarea
        class="pt-0 pb-2"
        label="Plot"
        rows="3"
        required
        v-model="plotValue"
        placeholder="Describe the story"
        :rules="plotRules"
      ></v-textarea>
      <v-file-input
        label="Poster"
        required
        :rules="posterRules"
        accept="image/*"
        placeholder="Upload the movie poster"
        v-model="posterValue"
      ></v-file-input>
      <v-btn type="submit">ADD</v-btn>
    </v-form>
    <entity-creation
      :title="modalTitle"
      :isOpen="modalOpen"
      @close-model="closeModal"
      @update-actor="updateActor"
    ></entity-creation>
  </div>
</template>

<script>
import EntityCreation from "./EntityCreation.vue";
import { mapGetters } from "vuex";
export default {
  components: { EntityCreation },
  props: ["id", "movieInfo"],
  data() {
    return {
      valid: false,
      movieName: "",
      yearOfRelease: "",
      selectedActors: [],
      selectedProducer: "",
      selectedGenres: [],
      plotValue: "",
      posterValue: "",
      modalOpen: false,
      modalTitle: "",
      defaultPosterValue: new File(["image content"], "image.jpg", {
        type: "image/png",
      }),
      maxDate: new Date().toISOString().split("T")[0],
      movieNameRules: [
        (value) => {
          if (value) return true;
          return "You must enter movie name.";
        },
      ],
      yearOfReleaseRules: [
        (v) => !!v || "You must enter the year of release.",
        (v) => /^\d{4}$/.test(v) || "Enter a valid 4-digit year.",
        (v) =>
          (v > 1800 && v <= new Date().getFullYear() + 1) ||
          "Enter a valid year.",
      ],
      actorRules: [
        (v) => (v && v.length > 0) || "You must select at least one actor.",
      ],
      producerRules: [(v) => !!v || "You must select a producer."],
      genreRules: [
        (v) => (v && v.length > 0) || "You must select at least one genre.",
      ],
      plotRules: [
        (v) => !!v || "You must enter the plot.",
        (v) =>
          (v && v.length >= 10) || "Plot must be at least 10 characters long.",
      ],
      posterRules: [(v) => !!v || "Poster is required"],
    };
  },
  computed: {
    ...mapGetters(["actors", "producers", "genres"]),

    allActorList() {
      return this.actors.map((actor) => actor.name);
    },
    allProducerList() {
      return this.producers.map((producer) => producer.name);
    },
    allGenreList() {
      return this.genres.map((genre) => genre.name);
    },
  },

  created() {
    if (typeof this.id !== "undefined") {
      this.insertData();
    }
  },

  methods: {
    async submitData() {
      if (!this.$refs.form.validate()) {
        return;
      }
      var imageUrl = "";
      if (this.posterValue.size > 15) {
        imageUrl = await this.getImageUrl();
      } else {
        imageUrl = this.movieInfo.image;
      }

      const movieDetail = {
        id: this.id,
        name: this.movieName,
        yearOfRelease: this.yearOfRelease,
        plot: this.plotValue,
        actor: this.getIdByNames(this.actors, this.selectedActors),
        producerId: this.producers.find(
          (producer) => producer.name === this.selectedProducer
        ).id,
        genre: this.getIdByNames(this.genres, this.selectedGenres),
        image: imageUrl,
      };

      console.log(movieDetail);
      if (typeof this.id !== "undefined") {
        await this.$store.dispatch("updateMovie", movieDetail);
      } else {
        await this.$store.dispatch("addMovie", movieDetail);
      }

      this.$router.push("/movies");
    },
    async getImageUrl() {
      const formData = new FormData();
      formData.append("file", this.posterValue);
      try {
        const response = await fetch(
          "http://localhost:24134/api/movies/upload",
          {
            method: "POST",
            body: formData,
          }
        );

        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        const responseData = await response.text();
        console.log(responseData);
        return responseData;
      } catch (error) {
        console.log(error.message);
      }
    },
    getIdByNames(list, selectedValues) {
      const nameToIdMap = list.reduce((map, actor) => {
        map[actor.name] = actor.id;
        return map;
      }, {});

      const selectedValuesIds = selectedValues.map((name) => nameToIdMap[name]);
      return selectedValuesIds;
    },
    insertData() {
      this.movieName = this.movieInfo.name;
      this.yearOfRelease = this.movieInfo.yearOfRelease;
      this.selectedActors = this.Updatefield(this.movieInfo.actor);
      this.selectedProducer = this.movieInfo.producer.name;
      this.selectedGenres = this.Updatefield(this.movieInfo.genre);
      this.plotValue = this.movieInfo.plot;
      if (this.movieInfo.image) {
        this.posterValue = this.defaultPosterValue;
      }
    },
    Updatefield(dataArrays) {
      const names = [];
      for (const data of dataArrays) {
        names.push(data.name);
      }
      return names;
    },
    openModal(modalType) {
      this.modalTitle = modalType;
      this.modalOpen = true;
    },
    closeModal() {
      this.modalOpen = false;
    },
    async updateActor(entityInfo, type) {
      if (type === 1) {
        await this.$store.dispatch("addActor", entityInfo);
        this.selectedActors.push(entityInfo.name);
      } else {
        await this.$store.dispatch("addProducer", entityInfo);
        this.selectedProducer = entityInfo.name;
      }
    },
  },
};
</script>

<style scoped>
.form-container {
  padding: 15px;
}
.actor-field {
  display: flex;
  align-items: center;
  justify-content: space-between;
}
.producer-field {
  display: flex;
  align-items: center;
  justify-content: space-between;
}
</style>
