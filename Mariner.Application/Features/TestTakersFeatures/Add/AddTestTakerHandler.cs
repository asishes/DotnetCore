using AutoMapper;
using Mariner.Application.Repository;
using Mariner.Application.Repository.TestTakersRepository;
using Mariner.Domain.Entities;
using MediatR;

namespace Mariner.Application.Features.TestTakersFeatures
{
    public sealed class AddTestTakerHandler : IRequestHandler<AddTestTakerRequest, AddTestTakerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITestTakerRepository _testTakerRepository;
        private readonly IMapper _mapper;

        public AddTestTakerHandler(IUnitOfWork unitOfWork, 
            ITestTakerRepository testTakerRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _testTakerRepository = testTakerRepository;
            _mapper = mapper;
        }

        public async Task<AddTestTakerResponse> Handle(AddTestTakerRequest request,
            CancellationToken cancellationToken)
        {
            var user = _mapper.Map<TestTakers>(request);
            _testTakerRepository.Create(user);
            await _unitOfWork.Save(cancellationToken);

            return _mapper.Map<AddTestTakerResponse>(user);
        }


    }
}
