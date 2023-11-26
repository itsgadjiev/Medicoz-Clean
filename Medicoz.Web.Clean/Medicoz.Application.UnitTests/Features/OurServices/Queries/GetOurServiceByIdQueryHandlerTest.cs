using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Features.OurServices.Commands.UpdateOurService;
using Medicoz.Application.Features.OurServices.Queries.GetOurServices;
using Medicoz.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.UnitTests.Features.OurServices.Queries;

public class GetOurServiceByIdQueryHandlerTest
{
    private readonly Mock<IOurServicesRepository> _mockRepository;

    public GetOurServiceByIdQueryHandlerTest()
    {
        _mockRepository = MockOurServicesRepository.GetOurServicesRepository();
    }

    [Fact]
    public async Task GetOurServicesByIdTest()
    {
        var handler = new GetOurServiceByIdQueryHandler(_mockRepository.Object);
        var result = await handler.Handle(new GetOurServiceByIdQuery { Id = 2 }, CancellationToken.None);

        result.ShouldBeOfType<UpdateOurServiceCommand>();

    }
}
