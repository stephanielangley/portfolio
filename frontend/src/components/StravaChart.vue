<script setup lang="ts">
import { useTemplateRef, onMounted } from 'vue'
import Chart, { type ChartConfiguration } from 'chart.js/auto'

const props = defineProps(['data'])

const backgroundColor = [
  'hsl(171, 100%, 41%)',
  'hsl(217, 71%, 53%)',
  'hsl(204, 86%, 53%)	'
]

const datasets = [{
  label: 'All Time Stats',
  data: [
    props.data.all_run_totals.count,
    props.data.all_swim_totals.count,
    props.data.all_ride_totals.count
  ],
  backgroundColor: backgroundColor,
  hoverOffset: 4,
},
{
  label: 'Year To Date',
  data: [
    props.data.ytd_run_totals.count,
    props.data.ytd_swim_totals.count,
    props.data.ytd_ride_totals.count
  ],
  backgroundColor: backgroundColor,
  hoverOffset: 4,
},
{
  label: 'Last 4 weeks',
  data: [
    props.data.recent_run_totals.count,
    props.data.recent_swim_totals.count,
    props.data.recent_ride_totals.count
  ],
  backgroundColor: backgroundColor,
  hoverOffset: 4,
}]

const chartConfig: ChartConfiguration = {
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
onMounted(() => { if (chart.value) new Chart(chart.value, chartConfig) })

</script>

<template>
  <div class="row">
    <h2>Strava Stats</h2>
    <canvas class="chart" ref="chart"></canvas>
  </div>
</template>
