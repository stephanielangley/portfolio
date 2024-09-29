<script setup lang="ts">
defineProps<{
    logo: string;
}>()
</script>

<template>
    <img class="logo" :src="logo" />
</template>

<style>
.logo {
    width: 50px
}
</style>