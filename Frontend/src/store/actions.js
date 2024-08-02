import axios from "../axios";
export default {
  async loadMovies(context) {
    try {
      const response = await axios.get("/movies");
      context.commit("setMovies", response.data);
    } catch (error) {
      console.error("Error loading movies:", error);
    }
  },
  async updateMovie(_, payload) {
    const { id, ...movieDetails } = payload;
    try {
      const response = await axios.put(`/movies/${id}`, movieDetails);
      console.log(response.data);
    } catch (error) {
      console.error("Error updating movie:", error);
      return error;
    }
  },
  async addMovie(_, payload) {
    delete payload.id;
    console.log(payload);
    try {
      const response = await axios.post("/movies", payload);
      console.log(response.data);
    } catch (error) {
      console.error("Error adding movie:", error);
      return error;
    }
  },
  async deleteMovie(context, payload) {
    try {
      const response = await axios.delete(`/movies/${payload}`);
      console.log(response.data);
      await context.dispatch("loadMovies");
    } catch (error) {
      console.error("Error deleting movie:", error);
      return error;
    }
  },

  //--actors
  async loadActors(context) {
    try {
      const response = await axios.get("/actors");
      context.commit("setActors", response.data);
    } catch (error) {
      console.error("Error loading actors:", error);
    }
  },
  async addActor(context, payload) {
    try {
      const response = await axios.post("/actors", payload);
      console.log(response.data);
      await context.dispatch("loadActors");
    } catch (error) {
      console.error("Error adding actor:", error);
      return error;
    }
  },

  //--producers
  async loadProducers(context) {
    try {
      const response = await axios.get("/producers");
      context.commit("setProducers", response.data);
    } catch (error) {
      console.error("Error loading producers:", error);
    }
  },
  async addProducer(context, payload) {
    try {
      const response = await axios.post("/producers", payload);
      console.log(response.data);
      await context.dispatch("loadProducers");
    } catch (error) {
      console.error("Error adding producer:", error);
      return error;
    }
  },

  async loadGenres(context) {
    try {
      const response = await axios.get("/genres");
      context.commit("setGenres", response.data);
    } catch (error) {
      console.error("Error loading genres:", error);
    }
  },
};
