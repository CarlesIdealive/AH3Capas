    namespace ApplicationComponent.Mapper
{
    public interface IMapper<TIn, TOut>
    {
        public TOut Map(TIn data);


    }

}
