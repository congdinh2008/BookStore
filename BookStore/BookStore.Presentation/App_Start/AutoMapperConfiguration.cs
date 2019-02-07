using AutoMapper;

namespace BookStore.Presentation
{
    public static class AutoMapperConfiguration
    {
        public static void Config()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile(new EntityModelMapper());
            });
        }
    }
}