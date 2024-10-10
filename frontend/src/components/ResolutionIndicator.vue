<script setup lang="ts">
import type { beach, surf } from '@/utils/types';
import { useQuery } from '@tanstack/vue-query';
import axios from 'axios';
import { ENDPOINTS } from '@/utils/common';
import { computed } from 'vue';
import dayjs from 'dayjs';

const { isFetching, isError, data, error } = useQuery<{ [date: string]: surf[] }>({
  queryKey: ['surfs'],
  queryFn: () => axios.get<surf[]>(ENDPOINTS.Surfs).then(({ data }) => {

    const dictionary: { [date: string]: surf[] } = {};

    data.forEach(surf => {
      if (!dictionary[surf.date]) {
        dictionary[surf.date] = [];
      }
      dictionary[surf.date].push(surf);
    });

    return dictionary;
  }).catch((error) => error),
})



const surfs = computed(() => {
  return Array.from({ length: 365 }).map((_, index) => {
    const date = dayjs(new Date(2024, 0, index)).format("YYYY-MM-DD");

    const result = data.value?.[date] ? data.value?.[date] : []

    return result;
  }
  )
})

</script>

<template>
  <div class="row">
    <h2>Resolution Indicator</h2>
    <p>My 2024 new years goal is to surf 52 times in a year. This means I need to surf once per week. To track this I
      have my indicator below where I can add new surfs and visualise over time the best swell periods and track
      whether I am "on target" for my goal.</p>
  </div>

  <div class="grid-container">
    <template v-for="(surf, index) in surfs" :key="index">
      <div class="day tooltip"
        :class="{ 'null': !surf.length, 'oneSurf': surf.length == 1, 'manySurfs': surf.length > 1, }">
        <span class="tooltiptext">
          <div> Day: <span class="has-text-weight-semibold">{{ index }} </span></div>
          <div v-if="(surf.length)"> Date: <span class="has-text-weight-semibold">{{ surf[0].date }}</span> </div>
          <div> Surf Count: <span class="has-text-weight-semibold">{{ surf.length }}</span> </div>
          <div v-if="(surf.length)"> Beach: <span class="has-text-weight-semibold">{{ surf[0].name }}</span> </div>
        </span>
      </div>
    </template>
  </div>


</template>


<style>
.grid-container {
  display: grid;
  grid-template-rows: repeat(7, auto);
  grid-auto-flow: column;
  gap: 5px;
}

.day {
  width: 20px;
  height: 20px;
}

.null {
  background-color: rgb(33, 39, 40)
}

.oneSurf {
  background-color: rgb(33, 110, 57)
}

.manySurfs {
  background-color: rgb(57, 211, 83)
}

.tooltip {
  position: relative;
  display: inline-block;
  border-bottom: 1px dotted black;
}

.tooltip .tooltiptext {
  visibility: hidden;
  width: 120px;
  background-color: #555;
  color: #fff;
  text-align: center;
  border-radius: 6px;
  padding: 5px 0;
  position: absolute;
  z-index: 1;
  bottom: 125%;
  left: 50%;
  margin-left: -60px;
  opacity: 0;
  transition: opacity 0.3s;
}

.tooltip .tooltiptext::after {
  content: "";
  position: absolute;
  top: 100%;
  left: 50%;
  margin-left: -5px;
  border-width: 5px;
  border-style: solid;
  border-color: #555 transparent transparent transparent;
}

.tooltip:hover .tooltiptext {
  visibility: visible;
  opacity: 1;
}
</style>