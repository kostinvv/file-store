import { createRouter, createWebHistory } from "vue-router";
import { useAuthStore } from "@/stores/auth.js";

import HomeView from "@/pages/HomeView.vue";
import SignIn from "@/pages/SignIn.vue";
import SignUp from "@/pages/SignUp.vue";
import StorageView from "@/pages/StorageView.vue";

const routes = [
    { 
        path: '/', 
        name: 'Home', 
        component: HomeView,
        meta: {
            auth: false
        }
    },
    { 
        path: '/sign-in', 
        name: 'Sign In', 
        component: SignIn,
        meta: {
            auth: false
        }
    },
    { 
        path: '/sign-up', 
        name: 'Sign Up', 
        component: SignUp,
        meta: {
            auth: false
        }
    },
    {
        path: '/storage',
        name: 'Storage',
        component: StorageView,
        meta: {
            auth: true
        }
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes,
});

router.beforeEach((to, from, next) => {
    const authStore = useAuthStore();
    
    if (to.meta.auth && !authStore.userInfo.accessToken) {
        next('/sign-in');
    } else if (!to.meta.auth && authStore.userInfo.accessToken) {
        next('/storage');
    } else {
        authStore.clearErrors();
        next();
    }
})

export default router;