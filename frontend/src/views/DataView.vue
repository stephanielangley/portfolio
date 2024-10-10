<script setup lang="ts">
import CommonTable from '../components/CommonTable.vue'
import BeachForm from '../components/BeachForm.vue'
import NavigationBar from '../components/NavigationBar.vue'
import { ENDPOINTS } from '@/utils/common';
import SurfForm from '@/components/SurfForm.vue';

</script>

<template>
  <div className="container my-large px-medium">
    <div class="is-flex is-flex-direction-column is-align-items-center content">

      <NavigationBar />

      <BeachForm />
      <CommonTable :columnHeadings="['ID', 'Name', 'Description', 'Latitude', 'Longitude']"
        :endpoint="ENDPOINTS.Beaches" queryReference="beaches" />
      <SurfForm />
      <CommonTable :columnHeadings="['Surf ID', 'Beach ID', 'Name', 'Description', 'Latitude', 'Longitude', 'Date']"
        :endpoint="ENDPOINTS.Surfs" queryReference="surfs" />
    </div>
  </div>
</template>
