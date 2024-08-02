<template>
  <v-card class="card">
    <div class="image-wrapper">
      <v-img class="image" :src="image" height="250px" contain></v-img>
    </div>
    <v-card-title class="title">{{ name }}</v-card-title>
    <v-card-text class="description">{{ description }}</v-card-text>
    <v-card-actions class="custom-card-actions">
      <v-btn depressed small class="pa-2">
        <router-link :to="movieDetail">
          Explore
          <v-icon>mdi-arrow-right</v-icon></router-link
        >
      </v-btn>
      <div>
        <router-link :to="editForm"
          ><v-icon class="m-1">mdi-square-edit-outline</v-icon></router-link
        >
        <router-link :to="confirmation"
          ><v-icon class="m-1" color="red">mdi-delete</v-icon></router-link
        >
      </div>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  props: ["id", "image", "description", "name"],
  computed: {
    movieDetail() {
      return this.$route.path + "/" + this.id;
    },
    editForm() {
      return this.$route.path + "/" + this.id + "/edit";
    },
    confirmation() {
      return this.$route.path + "/" + this.id + "/delete";
    },
  },
};
</script>

<style scoped>
.v-application a {
  color: #000000;
}
a {
  text-decoration: none;
}
.image-wrapper {
  padding-top: 20px;
}
.image {
}
.card {
  border: 1px solid #e0e0e0;
  background-color: #e9e5e5;
}
.card:hover {
  background-color: #cfcbcb;
}
.title {
  padding: 20px 21px 0px 20px;
  color: #000000;
}
.description {
  color: #666666;
  font-size: 17px;
  padding: 16px 20px 20px;
  text-align: left;
  display: -webkit-box;
  -webkit-line-clamp: 3;
  -webkit-box-orient: vertical;
  overflow: hidden;
  text-overflow: ellipsis;
  max-height: 5.7em; /* Approx. 3 lines */
  line-height: 1.5em; /* Adjust based on your font-size */
}
.custom-card-actions {
  padding: 18px 20px 20px;
  display: flex;
  justify-content: space-between;
  align-items: center;
}
</style>


