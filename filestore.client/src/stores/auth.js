import { ref } from "vue";
import { defineStore } from 'pinia';
import axios from 'axios';

export const useAuthStore = defineStore('auth', () => {
    const createUserResponse = ref({
        accessToken: '',
        username: '',
    })
    const errors = ref([]);
    
    const signup = async (payload) => {
        try {
            let response = await axios.post(`http://localhost:5098/api/v1/user/`, {
                ...payload
            });
            createUserResponse.value = {
                accessToken: response.data.accessToken,
                username: response.data.username,
            }
            
            console.log(response.data)
        } catch (err) {
            const errorData = err.response.data.errors;
            const errorMessages = [];
            
            for (const key in errorData) {
                errorData[key].forEach(error => {
                    errorMessages.push(error);
                })
            }
            errors.value = [...new Set(errorMessages)];
        }
    }
    
    return { 
        signup, 
        createUserResponse,
        errors,
    }
})