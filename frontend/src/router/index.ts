import { createRouter, createWebHistory } from 'vue-router'
import ProfileView from '../views/ProfileView.vue'
import BeachesView from '../views/BeachesView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      component: ProfileView
    },
    {
      path: '/beaches',
      component: BeachesView
    }
  ]
})

export default router
