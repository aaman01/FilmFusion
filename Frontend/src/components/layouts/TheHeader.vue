<template>
  <header>
    <nav>
      <h1>
        <router-link to="/">Film Fusion</router-link>
      </h1>
      <ul>
        <li>
          <router-link to="/movies"><h3>Movies</h3></router-link>
        </li>
      </ul>
    </nav>
  </header>
</template>

<script>
export default {};
</script>

<style scoped>
header {
  width: 100%;
  height: 6rem;
  background-color: #333333;
  display: flex;
  justify-content: center;
  align-items: center;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); /* Added shadow */
}

header nav {
  width: 94%;
  margin: auto;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

header ul {
  list-style: none;
  margin: 0;
  padding: 0;
  display: flex;
  justify-content: center;
  align-items: center;
}

header a {
  text-decoration: none;
  color: #d4d3d4;
  display: inline-block;
  padding: 0.75rem 1.5rem;
  border: 1px solid transparent;
  transition: border 0.3s, background-color 0.3s; /* Smooth transition */
}

ul a:hover {
  border: 1px solid #626060;
  background-color: rgba(
    255,
    255,
    255,
    0.1
  ); /* Subtle background change on hover */
}

h1 {
  margin: 0;
  font-size: 1.75rem; /* Adjusted font size */
}

h1 a {
  color: #ffffff;
  margin: 0;
}

li {
  color: #cccccc;
  margin: 0 0.5rem;
}

a:active,
a.router-link-active {
  border: 1px solid #ffffff;
}

h1 a:hover,
h1 a:active,
h1 a.router-link-active {
  border-color: transparent;
}
</style>
