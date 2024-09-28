<script setup lang="ts">
import { ref } from 'vue'
import axios from 'axios'
import { ENDPOINTS } from '../utils/common'


const beaches = ref([])
const beachesColumns = ref([])
axios.get(ENDPOINTS.Beaches).then(({ data }) => {
  beaches.value = data;
});

</script>

<template>
  {{ count }}
  <table>
    <tbody>
      <tr>
        <th>date</th>
        <th>temperature C</th>
        <th>temperature F</th>
        <th>summary</th>
      </tr>

      <template v-for="(row, i) in beaches">
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