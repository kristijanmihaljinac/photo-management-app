using Common.Mediator.Core;
using Microsoft.AspNetCore.Mvc;
using PhotoManagementApp.Application.Package.GetAllPackages;
using Swashbuckle.AspNetCore.Annotations;

namespace PhotoManagementApp.API.Endpoints.Package.GetAll
{
    public class GetAllPackagesEndPoint : Ardalis.ApiEndpoints.EndpointBaseAsync
        .WithoutRequest
        .WithResult<IEnumerable<GetAllPackagesResultDto>>
    {
        private readonly IMediator _mediator;
        public GetAllPackagesEndPoint(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/packages")]
        [SwaggerOperation(
            Summary = "Get all Packages",
            Description = "Get all Packages",
            OperationId = "Package.GetAll",
            Tags = new[] { "GetAllPackagesEndPoint" })
        ]
        public override async Task<IEnumerable<GetAllPackagesResultDto>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var packagesResult = await _mediator.HandleAsync(new GetAllPackagesUseCase());

            return packagesResult.Select(x => new GetAllPackagesResultDto
            {
                Code = x.Code,
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
