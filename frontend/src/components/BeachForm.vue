<script setup lang="ts">
import { ref } from 'vue'

const name = ref('');
const description = ref('');
const latitude = ref('');
const longitude = ref('');

const submit = () => {

  const data = {
    "name": name.value,
    "description": description.value,
    "latitude": latitude.value,
    "longitude": longitude.value
  }

  console.log(data)
}
</script>

<template>
  <div class="row">
    <h1>Beach Form</h1>
    <form @submit.prevent="submit">

      <div class="field">
        <label class="label">Name</label>
        <div class="control">
          <input class="input" type="text" placeholder="Beach Name" v-model="name" />
        </div>
        <label class="label">Description</label>
        <div class="control">
          <input class="input" type="text" placeholder="Beach Description" v-model="description" />
        </div>
        <label class="label">Lattitude</label>
        <div class="control">
          <input class="input" type="text" placeholder="Beach Lattitude" v-model="latitude" />
        </div>
        <label class="label">Longitude</label>
        <div class="control">
          <input class="input" type="text" placeholder="Beach Longitude" v-model="longitude" />
        </div>
      </div>
      <div class="field is-grouped">
        <div class="control">
          <button class="button is-link">Submit</button>
        </div>
        <div class="control">
          <button class="button is-link is-light">Cancel</button>
        </div>
      </div>
    </form>
  </div>
</template>