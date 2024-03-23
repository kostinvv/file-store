import axios from "axios";
import router from "@/router/index.js";

import { useAuthStore } from "@/stores/auth.js";

const axiosApiInstance = axios.create({
    baseURL: 'http://localhost:5098/api/v1/',
});

axiosApiInstance.interceptors.request.use((config) => {
    const authStore = useAuthStore();
    const token = authStore.userInfo.accessToken;

    config.headers.Authorization =  token ? `Bearer ${token}` : '';
    
    return config;
});

axiosApiInstance.interceptors.response.use((response) => {
   return response; 
}, async function (error) {
    const authStore = useAuthStore();
    if (error.response.status === 401) {
        localStorage.removeItem('userInfo');
        await router.push('/sign-in');
        authStore.userInfo.accessToken = '';
        authStore.userInfo.username = '';
    }
    return Promise.reject(error);
});

export default axiosApiInstance;
