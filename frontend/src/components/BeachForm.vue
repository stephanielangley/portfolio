<script setup lang="ts">
import { useQueryClient } from '@tanstack/vue-query';
import axios, { AxiosError } from 'axios';
import { ref } from 'vue'
import ErrorMessage from './ErrorMessage.vue';

const name = ref('');
const description = ref('');
const latitude = ref('');
const longitude = ref('');
const isLoading = ref(false);
const error = ref<AxiosError | null>(null);

const queryClient = useQueryClient()

// the regular expression pattern matching for validation
// eslint-disable-next-line no-useless-escape
const regexLatLongPattern = "^[-+]?([1-8]?\d(\.\d+)?|90(\.0+)?),\s*[-+]?(180(\.0+)?|((1[0-7]\d)|([1-9]?\d))(\.\d+)?)$";

const submit = () => {
  isLoading.value = true;

  const data = {
    "name": name.value,
    "description": description.value,
    "latitude": latitude.value,
    "longitude": longitude.value
  }

  axios.post('/api/beaches', data).then(() => {
    queryClient.invalidateQueries({ queryKey: ["beaches"] });
    name.value = '';
    description.value = '';
    latitude.value = '';
    longitude.value = '';
    isLoading.value = false;
  }).catch((err) => { isLoading.value = false; error.value = err })

}
</script>

<template>
  <div class="row">
    <h1>Beaches</h1>
    <form @submit.prevent="submit">

      <div class="field is-flex is-flex-direction-row is-align-items-flex-end">
        <div class="control mr-5"><label class="label">Name</label>
          <input class="input" type="text" placeholder="Beach Name" v-model="name" />
        </div>
        <div class="control mr-5"><label class="label">Description</label>
          <textarea class="input" type="textarea" placeholder="Beach Description" v-model="description"></textarea>
        </div>
        <div class="control mr-5"> <label class="label">Latitude</label>
          <input class="input" :pattern="regexLatLongPattern" placeholder="Beach Latitude" v-model="latitude" />
        </div>
        <div class="control mr-5"> <label class="label">Longitude</label>
          <input class="input" :attern="regexLatLongPattern" placeholder="Beach Longitude" v-model="longitude" />
        </div>
        <div class="control mr-5 ">
          <button class="button is-link" :class="{ 'is-loading': isLoading }" type="submit">Submit</button>
        </div>
      </div>
      <ErrorMessage v-if="error" :error="error" />

    </form>
  </div>
</template>