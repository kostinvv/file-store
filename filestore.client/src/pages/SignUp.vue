<script setup>
import { useAuthStore } from "@/stores/auth.js";
import { useForm } from 'vee-validate';
import { errorMessages } from "@/utils/errorMessages.js";

import * as yup from 'yup';
import InputText from "@/components/InputText.vue";

const authStore = useAuthStore();

const { handleSubmit } = useForm({
  validationSchema: yup.object({
    name: yup
        .string()
        .min(6, errorMessages.name.min)
        .max(50, errorMessages.name.max)
        .required(errorMessages.name.required),
    email: yup
        .string()
        .email(errorMessages.email.emailFormat)
        .required(errorMessages.email.required),
    password: yup
        .string()
        .required(errorMessages.password.required)
        .min(8, errorMessages.password.min),
    passwordConfirm: yup
        .string()
        .required(errorMessages.passwordConfirm.required)
        .oneOf([yup.ref('password')], errorMessages.passwordConfirm.oneOf),
  }),
});

const onSubmit = handleSubmit.withControlled(async values => {
  await authStore.signup({
    name: values.name,
    email: values.email,
    password: values.password,
    passwordConfirm: values.passwordConfirm
  });
});
</script>

<template>
  <section class="flex flex-col w-4/4 m-auto">
    <h2 class="text-4xl text-center pb-10">Sign up</h2>
    <div class="bg-white w-2/5 max-md:w-4/5 m-auto rounded-xl p-8 shadow-md shadow-gray-200/60">
      <form @submit="onSubmit">
        <ul v-if="authStore.errors.length > 0">
          <li v-for="error in authStore.errors" :key="error">{{ error }}</li>
        </ul>
        <input-text name="name" type="text" placeholder="Ivan" label="Username"/>
        <input-text name="email" type="email" placeholder="user@mail.ru" label="E-mail"/>
        <input-text name="password" type="password" placeholder="*********" label="Password"/>
        <input-text name="passwordConfirm" type="password" placeholder="*********" label="Password confirm"/>
        <button class="px-8 py-2 rounded-xl bg-blue-500 text-white font-bold">Sign up</button>
      </form>
    </div>
  </section>
</template>