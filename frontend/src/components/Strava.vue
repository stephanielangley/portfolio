<script setup lang="ts">
import { ref } from 'vue'
import axios from 'axios'
import { ENDPOINTS } from '../utils/common'

const strava = ref([])
axios.get(ENDPOINTS.Strava).then(({ data }) => {
  strava.value = data;
  console.log(data)
});

</script>

<template>
  {{ strava }}
  strava
</template>