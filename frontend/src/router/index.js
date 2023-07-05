import { createRouter, createWebHistory } from 'vue-router'



const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path:'/',
      name:'HoumeView',
      component: () => import('../views/Home.vue')
    },
    {
      path:'/Calculator',
      name:'Calculator',
      component: () => import('../views/Calculator.vue')
    },
  ]
})

export default router
