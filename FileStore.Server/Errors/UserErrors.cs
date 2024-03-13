namespace FileStore.Server.Errors
{
    public static class UserErrors
    {
        public static readonly Error UserAlreadyExists = new Error(
            "User.Name", "User already exists");
    }
}
