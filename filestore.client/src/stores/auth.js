import { ref } from "vue";
import { defineStore } from 'pinia';

import axiosApiInstance from "@/api.js";

export const useAuthStore = defineStore('auth', () => {
    const userInfo = ref({
        accessToken: '',
        username: '',
    })
    const errors = ref([]);
    const isSuccess = ref(false);

    const auth = async (url, payload) => {
        try {
            let response = await axiosApiInstance.post(url, {
                ...payload
            });
            
            userInfo.value = {
                accessToken: response.data.accessToken,
                username: response.data.username,
            };

            localStorage.setItem('userInfo', JSON.stringify({
                token: userInfo.value.accessToken,
                username: userInfo.value.username,
            }));

            isSuccess.value = true;
        } catch (err) {
            errors.value = getErrorMessages(err);
        }
    }
    
    const signup = async (payload) => {
        const url = 'user';
        
        await auth(url, payload);
    }
    const signin = async (payload) => {
        const url = 'user/sign-in';

        await auth(url, payload);
    }
    
    const logout = () => {
        userInfo.value = {
            accessToken: '',
            username: '',
        }
    }
    
    const clearErrors = () => {
        isSuccess.value = false;
        errors.value = [];
    }

    return { 
        signup, 
        signin,
        logout,
        clearErrors,
        isSuccess,
        userInfo,
        errors,
    }
})

const getErrorMessages = (err) => {
    const errorData = err.response.data.errors;
    const errorMessages = [];
    
    for(const key in errorData) {
        errorData[key].forEach(error => {
            errorMessages.push(error);
        })
    }
    
    return [...new Set(errorMessages)];
}