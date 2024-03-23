<script setup>
import { useAuthStore } from "@/stores/auth.js";
import { computed } from "vue";
import router from "@/router/index.js";

const authStore = useAuthStore();
const token = computed(() => authStore.userInfo.accessToken);
const username = computed(() => authStore.userInfo.username);

const logout = () => {
  authStore.logout();
  localStorage.removeItem('userInfo');
  router.push('/sign-in');
}
</script>

<template>
  <header>
    <div class="flex justify-between pb-6">
      <div class="flex items-center">
        <router-link to="/">
          <h2 class="text-3xl">file-store <span class="animate-ping">/</span></h2>
        </router-link>
      </div>
      <div>
        <ul class="flex items-center gap-4">
          <li class="flex items-center gap-3">
            <router-link to="/sign-up" v-if="!token" class="flex gap-2 rounded-xl px-3 py-2 cursor-pointer border transition-all border-transparent hover:border-gray-500">
              <span class="text-2xl">register</span>
            </router-link>
            <span v-if="!token" class="text-2xl">or</span>
            <router-link to="/sign-in" v-if="!token" class="flex gap-2 rounded-xl px-3 py-2 cursor-pointer border transition-all border-transparent hover:border-gray-500">
              <span class="text-2xl">sign in</span>
            </router-link>
            <router-link to="/storage" v-if="token">
              <span class="text-2xl">hello, {{ username }}!</span>
            </router-link>
            <a v-if="token" class="flex gap-2 rounded-xl px-3 py-2 cursor-pointer border transition-all border-transparent hover:border-gray-500">
              <span @click.prevent="logout" class="text-2xl">log out</span>
            </a>
          </li>
        </ul>
      </div>
    </div>
    <hr>
  </header>
</template>