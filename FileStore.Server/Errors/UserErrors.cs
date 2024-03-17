namespace FileStore.Server.Errors
{
    public static class UserErrors
    {
        public static readonly Error UserAlreadyExists = new Error(
            "User.Name", "User already exists");

        public static readonly Error UserNotFound = new Error(
            "User.Name", "User not found");
        
        public static readonly Error WrongPassword = new Error(
            "User.Password", "Wrong password");
    }
}
