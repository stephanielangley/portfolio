<script setup lang="ts">
import { ref } from 'vue'
import axios from 'axios'
import { ENDPOINTS } from '../utils/common'

type beach = { date: string, temperatureC: string, temperatureF: string, summary: string }

const beaches = ref<beach[]>([])
axios.get(ENDPOINTS.Beaches).then(({ data }) => {
  beaches.value = data;
});

</script>

<template>
  <table class="table is-hoverable table is-striped">

    <thead>
      <tr>
        <th>Date</th>
        <th>Temperature C</th>
        <th>Temperature F</th>
        <th>Summary</th>
      </tr>
    </thead>
    <tbody>
      <template v-for="(row, i) in beaches" v-bind:key="i">
        <tr>
          <td>{{ row.date }}</td>
          <td>{{ row.temperatureC }}</td>
          <td>{{ row.temperatureF }}</td>
          <td>{{ row.summary }}</td>
        </tr>
      </template>
    </tbody>
  </table>
</template>