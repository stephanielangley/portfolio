<script setup lang="ts">
import StravaChart from '../components/StravaChart.vue'
import ResolutionIndicator from '../components/ResolutionIndicator.vue'
import ProfileDescriptor from '../components/ProfileDescriptor.vue'
import DevTechnologies from '../components/DevTechnologies.vue'
import NavigationBar from '../components/NavigationBar.vue'
import { ENDPOINTS, TECHNOLOGIES } from '../utils/common'
import { ref } from 'vue'
import axios from 'axios'

const strava = ref([])
axios.get(ENDPOINTS.Strava).then(({ data }) => {
  strava.value = data;
  console.log(strava.value)
});

</script>

<template>
  <div className="container my-large px-medium">
    <div class="is-flex is-flex-direction-column is-align-items-center content">

      <NavigationBar />
      <ProfileDescriptor
        msg="This site showcases a fullstack setup using the below technologies; alongside 3rd party api's accessed with oauth 2." />
      <DevTechnologies :technologies="TECHNOLOGIES" />
      <StravaChart v-if="strava?.length !== 0" :data="strava" />
      <ResolutionIndicator />
    </div>
  </div>

</template>

<style>
.profile-picture {
  max-width: 255px;
  max-height: 255px;
}
</style>