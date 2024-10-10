<script setup lang="ts">
import axios from 'axios'
import { useQuery } from '@tanstack/vue-query';
import ErrorMessage from './ErrorMessage.vue';
import LoadingIcon from './LoadingIcon.vue';

const props = defineProps<{
  columnHeadings: string[],
  endpoint: string,
  queryReference: string,
}>();

const { isFetching, isError, data, error } = useQuery<{}[]>({
  queryKey: [props.queryReference],
  queryFn: () => axios.get(props.endpoint).then(({ data }) =>
    data).catch((error) => error),
})

</script>

<template>
  <table class="table is-hoverable is-striped is-fullwidth">
    <thead>
      <tr>
        <template v-for="(heading, index) in props.columnHeadings" :key="index">
          <td>{{ heading }}</td>
        </template>
      </tr>
    </thead>
    <tbody>
      <tr v-if="isFetching">
        <td colspan="4">
          <LoadingIcon />
        </td>
      </tr>
      <tr v-if="!data?.length && !isFetching"> No beach data available</tr>
      <tr v-if="isError">
        <ErrorMessage :error="error" />
      </tr>
      <template v-for="(row, index) in data" v-bind:key="index">
        <tr>
          <template v-for="(value, key) in row" :key="key">
            <td>{{ value }}</td>
          </template>
        </tr>
      </template>
    </tbody>
  </table>
</template>