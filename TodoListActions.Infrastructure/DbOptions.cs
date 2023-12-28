using Microsoft.Extensions.Options;

namespace TodoListActions.Infrastructure
{
    public class DbOptions : IValidateOptions<DbOptions>
    {
        public const string Db = nameof(Db);
        public string ConnectionString { get; init; } = string.Empty;

        public ValidateOptionsResult Validate(string? name, DbOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.ConnectionString))
            {
                return ValidateOptionsResult.Fail($"Env variable {Db}__{nameof(options.ConnectionString)} is not defined");
            }

            return ValidateOptionsResult.Success;
        }
    }
}
