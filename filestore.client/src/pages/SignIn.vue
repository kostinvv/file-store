<script setup>
import { ref } from "vue";
import { useForm } from 'vee-validate';
import {useRouter} from "vue-router";

import { useAuthStore } from "@/stores/auth.js";
import { errorMessages } from "@/utils/errorMessages.js";

import * as yup from 'yup';
import InputText from "@/components/InputText.vue";
import SubmitButton from "@/components/SubmitButton.vue";

const isDisabledBtn = ref(false);

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
  isDisabledBtn.value = true;
  await authStore.signin({
    name: values.name,
    password: values.password,
  });
  isDisabledBtn.value = false;
  await router.push('/storage');
});
</script>

<template>
  <section class="flex flex-col w-4/4">
    <h2 class="text-4xl text-center pb-10">Sign in</h2>
    <div class="bg-white w-2/6 max-md:w-4/5 m-auto rounded-xl p-8 shadow-md shadow-gray-200/60">
      <form @submit="onSubmit">
        <ul class="text-red-500 pb-4" v-if="authStore.errors.length > 0">
          <li v-for="error in authStore.errors" :key="error">- {{ error }}</li>
        </ul>
        <input-text name="name" type="text" placeholder="Ivan" label="Username"/>
        <input-text name="password" type="password" placeholder="*********" label="Password"/>
        <submit-button name="Sign in" :is-disabled="isDisabledBtn"/>
      </form>
    </div>
  </section>
</template>