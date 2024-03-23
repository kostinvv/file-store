<script setup>
import { ref } from "vue";
import { useForm } from 'vee-validate';
import { useRouter } from "vue-router";

import { useAuthStore } from "@/stores/auth.js";
import { errorMessages } from "@/utils/errorMessages.js";

import * as yup from 'yup';

import InputText from "@/components/InputText.vue";
import SubmitButton from "@/components/SubmitButton.vue";

const isDisabledBtn = ref(false);

const router = useRouter();
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
  isDisabledBtn.value = true;
  await authStore.signup({
    name: values.name,
    email: values.email,
    password: values.password,
    passwordConfirm: values.passwordConfirm
  });
  if (authStore.isSuccess) {
    await router.push('/storage');
  }
  isDisabledBtn.value = false;
});
</script>

<template>
  <section class="flex flex-col w-4/4 m-auto">
    <h2 class="text-4xl text-center pb-10">Sign up</h2>
    <div class="bg-white w-2/6 max-md:w-4/5 m-auto rounded-xl p-8 shadow-md shadow-gray-200/60">
      <form @submit="onSubmit">
        <ul class="text-red-500 pb-4" v-if="authStore.errors.length > 0">
          <li v-for="error in authStore.errors" :key="error">- {{ error }}</li>
        </ul>
        <input-text name="name" type="text" placeholder="Ivan" label="Username"/>
        <input-text name="email" type="email" placeholder="user@mail.ru" label="E-mail"/>
        <input-text name="password" type="password" placeholder="*********" label="Password"/>
        <input-text name="passwordConfirm" type="password" placeholder="*********" label="Password confirm"/>
        <submit-button name="Sign up" :is-disabled="isDisabledBtn"/>
      </form>
    </div>
  </section>
</template>