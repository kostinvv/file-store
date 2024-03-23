import './assets/main.css';

import App from '@/App.vue';

import { createApp } from 'vue';
import { createPinia } from 'pinia';

import router from "@/router/index.js";
import './api.js';

const pinia = createPinia();

const app = createApp(App);

app.use(router);
app.use(pinia);

app.mount('#app');
