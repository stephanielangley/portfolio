<script setup lang="ts">
import { ref } from 'vue'

const options = [{ name: "Gwithian", id: 1 }, { name: "Godrevy", id: 2 }]

const beach = ref({});
const date = ref('');

const submit = () => {

  const data = {
    "beach": beach.value,
    "date": date.value,
  }

  console.log(data)
}


</script>

<template>
  <div class="row">
    <h3>Surf</h3>
    <form @submit.prevent="submit">
      <div class="field">
        <label class="label">Beach</label>
        <div class="control">
          <select class="select" v-model="beach">
            <option v-for="option in options" :value="option" v-bind:key="option.id">
              {{ option.name }}
            </option>
          </select>
        </div>
      </div>
      <label class="label">Date</label>
      <div class="control">
        <input class="input" type="date" v-model="date" />
      </div>

      <div class="control">
        <button class="button is-link" type="submit">Submit</button>
      </div>
    </form>
  </div>
</template>