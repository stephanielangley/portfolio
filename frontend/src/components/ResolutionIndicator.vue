<script setup lang="ts">
import { useTemplateRef, onMounted } from 'vue'
import Chart from 'chart.js/auto'
import SurfForm from './SurfForm.vue'




const data = {
  labels: ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"],
  datasets: [{
    label: 'Dataset 1',
    data: [{ x: "2022-1-8", y: 950 },
    { x: "2022-1-9", y: 1100 },
    { x: "2022-1-10", y: 990 },
    { x: "2022-1-12", y: 1250 },
    { x: "2022-1-13", y: 1050 }]
  }]
}

const chartConfig = {
  type: 'scatter',
  data,
  options: {
    responsive: true,
    scales: {
      x: {
        type: 'time',
        time: {
          parser: 'YYYY-M-D',
          unit: 'day',
          displayFormats: {
            day: 'D MMM YYYY'
          },
          tooltipFormat: 'D MMM YYYY'
        }
      }
    }
  }
}

const chart = useTemplateRef("chart");
onMounted(() => { new Chart(chart.value, chartConfig) })

</script>

<template>
  <div class="row">
    <h2>Resolution Indicator</h2>
    <p>My 2024 new years goal is to surf 52 times in a year. This means I need to surf once per week. To track this I
      have my indicator below where I can add new surfs and visualise over time the best swell periods and track
      whether I am "on target" for my goal.</p>
    <SurfForm />
    <canvas class="chart" ref="chart"></canvas>
  </div>

</template>


<style>
.chart {
  width: 800px;
  max-height: 800px
}
</style>