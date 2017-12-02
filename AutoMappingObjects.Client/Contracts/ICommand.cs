namespace AutoMappingObjects.Client.Contracts
{
    public interface ICommand
    {
        string Execute(params string[] arguments);
    }
}
