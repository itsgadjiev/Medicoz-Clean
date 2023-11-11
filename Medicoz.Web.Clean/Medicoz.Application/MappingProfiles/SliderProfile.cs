using AutoMapper;
using Medicoz.Application.Features.Slider.Commands.CreateSlider;
using Medicoz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Medicoz.Application.MappingProfiles
{
    public class SliderProfile : Profile
    {
        public SliderProfile()
        {
            CreateMap<CreateSliderCommand, Slider>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src =>
                    src.EnglishContent != null ? src.EnglishContent.Title : src.AzerbaijaniContent.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src =>
                    src.EnglishContent != null ? src.EnglishContent.Description : src.AzerbaijaniContent.Description))
                .ForMember(dest => dest.Quote, opt => opt.MapFrom(src =>
                    src.EnglishContent != null ? src.EnglishContent.Quote : src.AzerbaijaniContent.Quote))
                .ForMember(dest => dest.ButtonName, opt => opt.MapFrom(src =>
                    src.EnglishContent != null ? src.EnglishContent.ButtonName1 : src.AzerbaijaniContent.ButtonName1))
                .ForMember(dest => dest.RedirectUrl, opt => opt.MapFrom(src => src.RedirectUrl1))
                .ForMember(dest => dest.ButtonName2, opt => opt.MapFrom(src =>
                    src.EnglishContent != null ? src.EnglishContent.ButtonName2 : src.AzerbaijaniContent.ButtonName2))
                .ForMember(dest => dest.Culture, opt => opt.MapFrom(src =>
                    src.EnglishContent != null ? "en-US" : "az"))
                .ForMember(dest => dest.RedirectUrl2, opt => opt.MapFrom(src => src.RedirectUrl2))
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());

            CreateMap<SliderContent, Slider>();

        }

    }
}
