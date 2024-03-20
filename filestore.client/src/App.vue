<script setup>
  import TheHeader from "@/components/TheHeader.vue";
</script>

<template>
  <div class="w-3/5 m-auto mt-14">
    <the-header/>
    <div class="mt-10">
      <router-view/>
    </div>
  </div>
</template>