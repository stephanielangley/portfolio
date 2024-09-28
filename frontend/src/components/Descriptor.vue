<script setup lang="ts">
defineProps<{
  msg: string
}>()
</script>

<template>
  <p class="is-size-1">{{ msg }}</p>
  <p class="is-size-4">
    This site uses
    <a href="https://vitejs.dev/" target="_blank" rel="noopener">Vite</a> +
    <a href="https://vuejs.org/" target="_blank" rel="noopener">Vue 3</a> +
    <a href="https://bulma.io/" target="_blank" rel="noopener">Bulma</a> +
    <a href="https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/" target="_blank" rel="noopener">C#</a>
  </p>
  <p>
    Heres a lonnnnnnnnnnnnnnnnnnnnnnnnnnggggggggggggggggggggggggggggg description about me!
  </p>
</template>
