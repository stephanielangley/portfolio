<script setup lang="ts">
import IconLogo from './IconLogo.vue'
defineProps<{
  technologies: {
    link: string,
    name: string,
    description: string
    icon: string,
  }[]
}>()
</script>

<template>
  <div class="row">
    <div class="pl-5 tech-table ">
      <h2>Technologies Used</h2>
      <div v-for="tech in technologies" class="is-flex is-align-items-center my-large" :key="tech.name">
        <div class="logo">
          <IconLogo :logo="tech.icon" />
        </div>

        <div class="content ml-5">
          <a :href="tech.link" target="_blank" rel="noopener">{{ tech.name }}</a>

          <p>{{ tech.description }}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<style>
.tech-table {
  border-left: 1px #ccc dashed
}

.logo {
  width: 32px
}
</style>