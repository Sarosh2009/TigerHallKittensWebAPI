using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TigerHallKittensWebAPI.Models.DTO;

namespace TigerHallKittensWebAPI
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Models.TigerSighting, TigerSightingDTO>().ReverseMap();
            });
        }
    }
}