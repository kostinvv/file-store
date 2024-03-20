<script setup>
import { useField } from 'vee-validate'

const props = defineProps({
  name: String,
  placeholder: String,
  label: String,
  type: String,
})

const { value, errorMessage } = useField(() => props.name)
</script>

<template>
  <div class="mb-4">
    <label class="font-bold block">{{ label }}</label>
    <input 
        class="shadow appearance-none border rounded-md w-full py-2 px-3" 
        v-model="value" 
        :type="type" 
        :placeholder="placeholder" 
    />
    <div class="text-red-500">{{ errorMessage }}</div>
  </div>
</template>