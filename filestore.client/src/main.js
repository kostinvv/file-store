import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'
import { createRouter, createWebHistory } from "vue-router";

import App from '@/App.vue'
import Home from "@/pages/HomeView.vue";
import SignIn from "@/pages/SignIn.vue";
import SignUp from "@/pages/SignUp.vue";

const pinia = createPinia()

const app = createApp(App)

const routes = [
    { path: '/', name: 'Home', component: Home },
    { path: '/sign-in', name: 'Sign In', component: SignIn },
    { path: '/sign-up', name: 'Sign Up', component: SignUp },
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

app.use(router)
app.use(pinia)

app.mount('#app')
