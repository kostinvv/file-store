<script setup>
import { useAuthStore } from "@/stores/auth.js";
import { useForm } from 'vee-validate';
import { errorMessages } from "@/utils/errorMessages.js";

import * as yup from 'yup';
import InputText from "@/components/InputText.vue";
import {useRouter} from "vue-router";
import {onMounted} from "vue";

const router = useRouter()
const authStore = useAuthStore();

const { handleSubmit } = useForm({
  validationSchema: yup.object({
    name: yup
        .string()
        .required(errorMessages.name.required),
    password: yup
        .string()
        .required(errorMessages.password.required)
  }),
});

const onSubmit = handleSubmit.withControlled(async values => {
  await authStore.signin({
    name: values.name,
    password: values.password,
  });
  await router.push('/home');
});
</script>

<template>
  <section class="flex flex-col w-4/4 m-auto">
    <h2 class="text-4xl text-center pb-10">Sign In</h2>
    <div class="bg-white w-2/5 max-md:w-4/5 m-auto rounded-xl p-8 shadow-md shadow-gray-200/60">
      <form @submit="onSubmit">
        <ul v-if="authStore.errors.length > 0">
          <li v-for="error in authStore.errors" :key="error">{{ error }}</li>
        </ul>
        <input-text name="name" type="text" placeholder="Ivan" label="Username"/>
        <input-text name="password" type="password" placeholder="*********" label="Password"/>
        <button class="px-8 py-2 rounded-xl bg-blue-500 text-white font-bold">Sign In</button>
      </form>
    </div>
  </section>
</template>