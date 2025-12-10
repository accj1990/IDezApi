namespace IDezApi.Tests.Unit.Base
{
    public interface BaseTestUseCase
    {
        Task ShouldWhenSuccess();
        Task ShouldHandleExceptionWhenExceptionThrown();
    }
}
