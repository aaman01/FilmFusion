export default {
  movies(state) {
    return state.movies;
  },
  hasMovies(state) {
    return state.movies && state.movies.length > 0;
  },
  actors(state) {
    return state.actors;
  },
  producers(state) {
    return state.producers;
  },
  genres(state) {
    return state.genres;
  },
};
