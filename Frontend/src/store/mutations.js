export default {
  setMovies(state, payload) {
    state.movies = payload;
  },
  setActors(state, payload) {
    state.actors = payload;
  },
  setProducers(state, payload) {
    state.producers = payload;
  },
  setGenres(state, payload) {
    state.genres = payload;
  },
};
