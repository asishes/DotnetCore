using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mariner.Application.Features.TestTakersFeatures;
using Mariner.Application.Features.TestTakersFeatures.Get;
using Mariner.WebAPI.Controllers.Base;

namespace Mariner.WebAPI.Controllers
{

    public class TestTakerController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TestTakerController> _logger;

        public TestTakerController(IMediator mediator,ILogger<TestTakerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllTestTakersResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllTestTakersRequest(), cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<AddTestTakerResponse>> Create(AddTestTakerRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
