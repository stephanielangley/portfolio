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
  //AXIOS Call with API Post TO Do
}
</script>

<template>
  <div class="row">
    <h1>Beach Form</h1>
    <form @submit.prevent="submit">

      <div class="field is-flex is-flex-direction-row is-align-items-flex-end">
        <div class="control mr-5"><label class="label">Name</label>
          <input class="input" type="text" placeholder="Beach Name" v-model="name" />
        </div>
        <div class="control mr-5"><label class="label">Description</label>
          <input class="input" type="text" placeholder="Beach Description" v-model="description" />
        </div>
        <div class="control mr-5"> <label class="label">Lattitude</label>
          <input class="input" type="text" placeholder="Beach Lattitude" v-model="latitude" />
        </div>
        <div class="control mr-5"> <label class="label">Longitude</label>
          <input class="input" type="text" placeholder="Beach Longitude" v-model="longitude" />
        </div>
        <div class="control mr-5 ">
          <button class="button is-link">Submit</button>
        </div>
      </div>

    </form>
  </div>
</template>