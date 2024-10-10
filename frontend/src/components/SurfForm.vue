<script setup lang="ts">
import { ENDPOINTS } from '@/utils/common';
import axios from 'axios';
import { ref } from 'vue'
import type { beach } from '../utils/types'
import ErrorMessage from './ErrorMessage.vue';
import { useQuery, useQueryClient } from '@tanstack/vue-query';

const SelectedBeach = ref("");
const date = ref("");
const isLoading = ref(false);

const queryClient = useQueryClient()

const { isFetching, isError, data, error } = useQuery<beach[]>({
  queryKey: ['beaches'],
  queryFn: () => axios.get(ENDPOINTS.Beaches).then(({ data }) =>
    data).catch((error) => error),
})

const submit = () => {
  isLoading.value = true;

  const data = {
    "surf_beach_id": SelectedBeach.value,
    "date": date.value,
  }

  axios.post('/api/surfs', data).then(() => {
    queryClient.invalidateQueries({ queryKey: ["surfs"] });
    SelectedBeach.value = '';
    date.value = '';
    isLoading.value = false;
  }).catch((err) => { isLoading.value = false; error.value = err })

}

</script>

<template>
  <div class="row">
    <h1>Surfs</h1>
    <form @submit.prevent="submit">
      <div class="field is-flex is-flex-direction-row is-align-items-flex-end">
        <div class="control mr-5"><label class="label">Beach</label>
          <div class="select" :class="{ 'is-loading': isFetching }">
            <select required v-model="SelectedBeach">
              <option value="" disabled>Select Beach...</option>
              <option v-for="option in data" :value="option.beach_id" v-bind:key="option.beach_id">
                {{ option.name }}
              </option>
            </select>
          </div>
          <P v-if="isError">
            <ErrorMessage :error="error" />
          </P>
        </div>
        <div class="control mr-5"><label class="label">Date</label>
          <input class="input" type="date" v-model="date" />
        </div>
        <div class="control">
          <button class="button is-link" :class="{ 'is-loading': isLoading }" type="submit">Submit</button>
        </div>
      </div>
    </form>
  </div>
</template>