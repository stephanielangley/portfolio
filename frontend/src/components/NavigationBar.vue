<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>

<template>
    <div class="is-flex is-flex-direction-column is-align-items-center content">

        <figure class="mb-5 image profile-picture">
            <img class="is-rounded" src="/img/steph.svg" />
        </figure>
        <div>
            <nav class="navbar mb-4">
                <RouterLink class="navbar-item" to="/">Home</RouterLink>
                <RouterLink class="navbar-item" to="/beaches">Beaches</RouterLink>
            </nav>
        </div>
    </div>
</template>