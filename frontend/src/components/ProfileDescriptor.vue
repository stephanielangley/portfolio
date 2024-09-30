<script setup lang="ts">
defineProps<{
  msg: string
  title?: string
}>()
</script>

<template>
  <div class="row">
    <p v-if="title" class="is-size-1">{{ title }}</p>
    <p>
      {{ msg }}
    </p>
  </div>
</template>
