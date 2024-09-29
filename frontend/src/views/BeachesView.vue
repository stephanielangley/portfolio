<script setup lang="ts">
import BeachesTable from '../components/BeachesTable.vue'
import BeachForm from '../components/BeachForm.vue'
import NavigationBar from '../components/NavigationBar.vue'
</script>

<template>
  <div className="container my-large px-medium">
    <div class="is-flex is-flex-direction-column is-align-items-center content">

      <NavigationBar />

      <BeachForm />
      <BeachesTable />
    </div>
  </div>
</template>
