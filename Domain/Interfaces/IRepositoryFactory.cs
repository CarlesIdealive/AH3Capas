namespace DomainComponent.Interfaces
{
    public interface IRepositoryFactory<TRepository, TExtraData>
    {
        public TRepository CreateRepository(TExtraData extraData);


    }
}
