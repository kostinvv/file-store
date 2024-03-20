<script setup>
import { ref } from 'vue'

const email = ref()
const name = ref()
const password = ref()
const passwordConfirm = ref()

const signup = async () => {
  
}
</script>

<template>
  <section class="flex flex-col w-4/4 m-auto">
    <h2 class="text-4xl text-center pb-10">Sign up</h2>
    <div class="bg-white w-2/5 max-md:w-4/5 m-auto rounded-xl p-8 shadow-md shadow-gray-200/60">
      <form>
        <div class="mb-4">
          <div>
            <label class="font-bold block">E-mail</label>
            <input 
                v-model="email" 
                class="shadow appearance-none border rounded-md w-full py-2 px-3" 
                type="email" 
                name="email" 
                placeholder="user@mail.ru"
            >
          </div>
        </div>
        <div class="mb-4">
          <div>
            <label class="font-bold  block">Name</label>
            <input 
                v-model="name" 
                class="shadow appearance-none border rounded-md w-full py-2 px-3" 
                type="text" 
                name="username" 
                placeholder="User"
            >
          </div>
        </div>
        <div class="mb-4">
          <div>
            <label class="font-bold block">Password</label>
            <input 
                v-model="password" 
                class="shadow appearance-none border rounded-md w-full py-2 px-3" 
                type="password" 
                name="password" 
                placeholder="***********">
          </div>
        </div>
        <div class="mb-4">
          <div>
            <label class="font-bold block">Password confirm</label>
            <input 
                v-model="passwordConfirm" 
                class="shadow appearance-none border rounded-md w-full py-2 px-3" 
                type="password" 
                name="passwordConfirm" 
                placeholder="***********"
            >
          </div>
        </div>
      </form>
      <div>
        <button 
            class="px-8 py-2 rounded-xl bg-blue-500 text-white font-bold" 
            type="submit"
        >Sign up</button>
      </div>
    </div>
  </section>
</template>