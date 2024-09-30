<script setup lang="ts">
import { RouterLink } from 'vue-router'
</script>

<template>
    <div class="is-flex is-flex-direction-column is-align-items-center content mb-1">

        <figure class="mb-5 image profile-picture">
            <img class="is-rounded" src="/img/steph-portfolio.jpg" />
        </figure>
        <div>
            <p class="is-size-1 mb-1">Stephanie Langley</p>
            <nav class="navbar  is-justify-content-center">
                <RouterLink class="navbar-item" to="/">Home</RouterLink>
                <RouterLink class="navbar-item" to="/beaches">Beaches</RouterLink>
            </nav>
        </div>
    </div>
</template>