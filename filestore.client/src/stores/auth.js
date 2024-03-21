import { ref } from "vue";
import { defineStore } from 'pinia';
import axios from 'axios';

export const useAuthStore = defineStore('auth', () => {
    const createUserResponse = ref({
        accessToken: '',
        username: '',
    })
    const loginUserResponse = ref({
        accessToken: '',
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
            errors.value = getErrorMessages(err);
            throw errors.value;
        }
    }
    const signin = async (payload) => {
        try {
            let response = await axios.post(`http://localhost:5098/api/v1/user/sign-in`, {
                ...payload
            });
            loginUserResponse.value = {
                accessToken: response.data.accessToken,
            }
            
            console.log(response.data);
        } catch (err) {
            errors.value = getErrorMessages(err)
            throw errors.value;
        }
    }

    return { 
        signup, 
        signin,
        createUserResponse,
        loginUserResponse,
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