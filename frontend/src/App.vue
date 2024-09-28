<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import Descriptor from './components/Descriptor.vue'
</script>

<template>
  <div class="is-flex is-flex-direction-column is-align-items-center">

    <figure class="mb-5 image profile-picture">
      <img class="is-rounded" src="@/assets/steph.svg" />
    </figure>
    <div>
      <nav class="navbar mb-4">
        <RouterLink class="navbar-item" to="/">Home</RouterLink>
        <RouterLink class="navbar-item" to="/about">About</RouterLink>
      </nav>
    </div>
    <Descriptor msg="Stephanie Langley" />
  </div>



  <RouterView />
</template>

<style>
.profile-picture {
  max-width: 255px;
  max-height: 255px;
}
</style>