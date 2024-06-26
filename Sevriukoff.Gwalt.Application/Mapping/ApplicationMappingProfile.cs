﻿using AutoMapper;
using Sevriukoff.Gwalt.Application.Interfaces;
using Sevriukoff.Gwalt.Application.Models;
using Sevriukoff.Gwalt.Infrastructure.Entities;

namespace Sevriukoff.Gwalt.Application.Mapping;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        #region Mappings Model <=> Entity
        
        CreateMap<User, UserModel>();
            
        CreateMap<Like, LikeModel>()
                .ForMember(dest => dest.Likeable, opt => 
                    opt.MapFrom<ILikeable>
                    (
                        (likeEntity, likeModel, likeable, context) =>
                        {
                            if (likeEntity.TrackId.HasValue)
                            {
                                return context.Mapper.Map<TrackModel>(likeEntity.Track);
                            }
                            
                            if (likeEntity.AlbumId.HasValue)
                            {
                                return context.Mapper.Map<AlbumModel>(likeEntity.Album);
                            }
                            
                            return null;
                        }
                    )
                );
            
        CreateMap<Album, AlbumModel>()
            .ForMember(dest => dest.CoverUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ReverseMap();

        CreateMap<Track, TrackModel>()
            .ForMember(dest => dest.LikesCount, opt => opt.MapFrom(src => src.TotalLikes != null ? src.TotalLikes.Count : 0))
            .ForMember(dest => dest.Album, opt => opt.MapFrom(src => src.Album != null ? src.Album : new Album { Id = src.AlbumId }));

        CreateMap<TrackModel, Track>()
            .ForMember(dest => dest.AlbumId, opt => opt.MapFrom(src => src.Album.Id))
            .ForMember(dest => dest.Album, opt => opt.Ignore());
            
        CreateMap<Genre, GenreModel>()
            .ReverseMap();
        
        #endregion
    }
}