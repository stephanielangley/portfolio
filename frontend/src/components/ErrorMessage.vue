<script setup lang="ts">
import type { AxiosError } from 'axios';
import { computed } from 'vue';


const props = defineProps<{
    error: Error | AxiosError | null,
}>();

// Captures variations of the error message returned from the backend strongly typed
const errorComputed = computed(() => {
    if (props.error) {
        if ("response" in props.error && props.error.response) {
            if ("data" in props.error.response && props.error.response.data) {
                if (typeof props.error.response.data == "object") {
                    if ("title" in props.error.response.data && props.error.response.data.title) {
                        return props.error.response.data.title
                    }
                }
            }
        }
    }
    return props.error?.message || null
})

</script>

<template>
    <p class="help is-danger">
        {{ errorComputed }}
    </p>
</template>