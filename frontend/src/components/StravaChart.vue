<script setup lang="ts">
import { ref, useTemplateRef, onMounted } from 'vue'
import Chart from 'chart.js/auto'
import axios from 'axios'
import { ENDPOINTS } from '../utils/common'

const props = defineProps(['data'])

const backgroundColor = [
  'rgb(255, 99, 132)',
  'rgb(54, 162, 235)',
  'rgb(255, 205, 86)'
]

console.log(props.data)

const datasets = [{
  label: 'All Time Stats',
  data: [
    props.data.all_run_totals.distance,
    props.data.all_swim_totals.distance,
    props.data.all_ride_totals.distance
  ],
  backgroundColor: backgroundColor,
  hoverOffset: 4,
},
{
  label: 'Year To Date',
  data: [
    props.data.ytd_run_totals.distance,
    props.data.ytd_swim_totals.distance,
    props.data.ytd_ride_totals.distance
  ],
  backgroundColor: backgroundColor,
  hoverOffset: 4,
},
{
  label: 'Last 4 weeks',
  data: [
    props.data.recent_run_totals.distance,
    props.data.recent_swim_totals.distance,
    props.data.recent_ride_totals.distance
  ],
  backgroundColor: backgroundColor,
  hoverOffset: 4,
}]

const chartConfig = {
  type: 'doughnut',
  data: {
    labels: [
      'Run',
      'Swim',
      'Bike'
    ],
    datasets: datasets
  }
};

const chart = useTemplateRef("chart");
onMounted(() => { new Chart(chart.value, chartConfig) })

</script>

<template>
  <canvas ref="chart"></canvas>
</template>