export const errorMessages = {
    email: {
        required: 'Field is required',
        emailFormat: 'Invalid email format',
    },
    name: {
        required: 'Field is required',
        min: 'Name must be at least 6 characters',
        max: 'Name must be at most 50 characters',
    },
    password: {
        required: 'Field is required',
        min: 'Password must be at least 8 characters',
    },
    passwordConfirm: {
        required: 'Field is required',
        oneOf: 'Passwords do not match',
    },
}