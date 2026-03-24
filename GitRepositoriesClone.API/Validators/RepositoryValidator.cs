namespace GitRepositoriesClone.API.Validators
{
    public static class RepositoryValidator
    {
        public static void Validate(string name, string? description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Repository name is required.");

            if (name.Length > 100)
                throw new ArgumentException("Repository name must not exceed 100 characters.");

            if (!string.IsNullOrWhiteSpace(description) &&
                description.Length > 500)
                throw new ArgumentException("Description must not exceed 500 characters.");
        }
    }
}
