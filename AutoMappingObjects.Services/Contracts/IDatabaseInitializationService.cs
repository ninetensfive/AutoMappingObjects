namespace AutoMappingObjects.Services.Contracts
{
    public interface IDatabaseInitializationService
    {
        void Reset(bool seed);
    }
}
