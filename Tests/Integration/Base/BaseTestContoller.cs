namespace IDezApi.Tests.Integration.Base
{
    public interface BaseTestController
    {
        Task ShouldReturnSuccess();

        Task ShouldReturnBadRequestWhenValidationFails();

        Task ShouldReturnUnprocessableEntityWhenBusinessRuleViolation();

    }
}
