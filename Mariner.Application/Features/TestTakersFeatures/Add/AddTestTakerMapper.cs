using AutoMapper;
using Mariner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariner.Application.Features.TestTakersFeatures
{
    public sealed class AddTestTakerMapper : Profile
    {
        public AddTestTakerMapper()
        {
            CreateMap<AddTestTakerRequest, TestTakers>();
            CreateMap<TestTakers, AddTestTakerResponse>();
        }
    }
}