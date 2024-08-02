import Vue from "vue";
import Router from "vue-router";
import MovieList from "./views/MovieList.vue";
import MovieCreation from "./views/MovieCreation.vue";
import ExploreModal from "./components/ui/ExploreModal.vue";
import ConfirmationDialogue from "./components/ui/ConfirmationDialogue.vue";

Vue.use(Router);

export default new Router({
  mode: "history", // Use 'history' mode for pretty URLs
  routes: [
    {
      path: "/",
      redirect: "/movies",
    },
    {
      path: "/movies",
      component: MovieList,
      children: [
        {
          path: ":id",
          props: true,
          component: ExploreModal,
        },
        {
          path: ":id/delete",
          props: true,
          component: ConfirmationDialogue,
        },
      ],
    },
    {
      path: "/add-movies",
      component: MovieCreation,
    },
    {
      path: "/movies/:id/edit",
      props: true,
      component: MovieCreation,
    },
  ],
});
