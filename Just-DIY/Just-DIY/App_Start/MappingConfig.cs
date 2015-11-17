namespace Just_DIY
{
    using AutoMapper;
    using Just_DIY.Models;
    using Just_DIY.Models.Favourites;
    using Just_DIY.Models.Projects;
    using Just_DIY.Models.Votes;

    public static class MappingConfig
    {
        public static void Initialize()
        {
            Mapper.CreateMap<User, SimpleUser>();
            Mapper.CreateMap<Project, ProjectViewModel>();
            Mapper.CreateMap<VoteBindingModel, Vote>();
            Mapper.CreateMap<FavouriteBindingModel, Favourite>();
            Mapper.CreateMap<Project, ProjectsByViewModel>();
        }
    }
}