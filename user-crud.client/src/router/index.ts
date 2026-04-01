import { createRouter, createWebHistory } from 'vue-router'
import UsersList from '../components/UsersList.vue'
import UserCreate from '../components/UserCreate.vue'
import UserEdit from '../components/UserEdit.vue'

const routes = [
  { path: '/', component: UsersList },
  { path: '/create', component: UserCreate },
  { path: '/edit/:id', component: UserEdit, props: true }
]

const router = createRouter({ history: createWebHistory(), routes })
export default router
