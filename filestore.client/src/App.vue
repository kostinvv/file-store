<script setup>
  import { useAuthStore } from "@/stores/auth.js";

  import TheHeader from "@/components/TheHeader.vue";
  
  const authStore = useAuthStore();
  
  const checkUser = () => {
    const userInfo = JSON.parse(localStorage.getItem('userInfo'));
    
    if (userInfo) {
      authStore.userInfo.accessToken = userInfo.token;
      authStore.userInfo.username = userInfo.username;
    }
  }
  
  checkUser();
</script>

<template>
  <div class="flex flex-col h-screen">
    <div class="container m-auto mt-14">
      <the-header/>
      <!-- content -->
      <main class="mt-20">
        <router-view/>
      </main>
    </div>
    <!-- sticky footer -->
    <footer class="p-8">
      <b>Github: </b>
      <a class="hover:text-blue-700"
         href="https://github.com/kostinvv/file-store">file-store</a>
    </footer>
  </div>
</template>