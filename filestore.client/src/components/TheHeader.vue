<script setup>
</script>

<template>
  <header>
    <div class="flex justify-between pb-6">
      <div class="flex items-center">
        <router-link to="/">
          <h2 class="text-3xl uppercase">FileStore <span class="animate-pulse">/</span></h2>
        </router-link>
      </div>
      <div>
        <ul class="flex items-center gap-4">
          <li class="flex items-center gap-2">
            <router-link to="/sign-in" class="rounded-xl px-3 py-2 cursor-pointer border transition-all border-transparent hover:border-gray-500">
              <span class="text-2xl">Sign In</span>
            </router-link>
          </li>
          <li class="flex items-center gap-2">
            <router-link to="/sign-up" class="rounded-xl px-3 py-2 cursor-pointer border border-gray-200 transition-all border-transparent hover:border-gray-500">
              <span class="text-2xl">Sign Up</span>
            </router-link>
          </li>
        </ul>
      </div>
    </div>
    <hr>
  </header>
</template>