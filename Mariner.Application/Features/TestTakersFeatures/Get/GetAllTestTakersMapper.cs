using AutoMapper;
using Mariner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariner.Application.Features.TestTakersFeatures.Get
{
    public sealed class GetAllTestTakersMapper : Profile
    {
        public GetAllTestTakersMapper()
        {
            CreateMap<TestTakers, GetAllTestTakersResponse>();
        }
    }
}
