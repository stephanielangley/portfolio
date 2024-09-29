<script setup lang="ts">
import StravaChart from '../components/StravaChart.vue'
import Descriptor from '../components/Descriptor.vue'
import { ENDPOINTS } from '../utils/common'
import { ref, useTemplateRef } from 'vue'
import Chart from 'chart.js/auto'
import axios from 'axios'

const strava = ref([])
axios.get(ENDPOINTS.Strava).then(({ data }) => {
  strava.value = data;
  console.log(strava.value)
});
</script>

<template>
  <div class="is-flex is-flex-direction-column is-align-items-center">

    <figure class="mb-5 image profile-picture">
      <img class="is-rounded" src="@/assets/steph.svg" />
    </figure>
    <div>
      <nav class="navbar mb-4">
        <RouterLink class="navbar-item" to="/">Home</RouterLink>
        <RouterLink class="navbar-item" to="/about">Beaches</RouterLink>
      </nav>
    </div>
    <Descriptor msg="Stephanie Langley" />
    <StravaChart v-if="strava?.length !== 0" :data="strava" />
  </div>

</template>
