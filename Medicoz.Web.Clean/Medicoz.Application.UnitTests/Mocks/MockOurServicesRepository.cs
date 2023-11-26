using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Moq;

namespace Medicoz.Application.UnitTests.Mocks
{
    public class MockOurServicesRepository
    {
        public static Mock<IOurServicesRepository> GetOurServicesRepository()
        {
            var ourServices = new List<OurService>
            {
                new OurService
                {
                    Id =1,
                    Description=new Dictionary<string, string>{ { "En", "Hello dec" },{"Az","Salam dec" } },
                    Title=new Dictionary<string, string>{ { "En", "Hello title" },{"Az","Salam title" } },
                    Icon="Some icon link1"
                },
                new OurService
                {
                    Id =2,
                    Description=new Dictionary<string, string>{ { "En", "Hello dec2" },{"Az","Salam dec2" } },
                    Title=new Dictionary<string, string>{ { "En", "Hello title2" },{"Az","Salam title2" } },
                    Icon="Some icon link2"
                },
                new OurService
                {
                    Id =3,
                    Description=new Dictionary<string, string>{ { "En", "Hello dec3" },{"Az","Salam dec3" } },
                    Title=new Dictionary<string, string>{ { "En", "Hello title3" },{"Az","Salam title3" } },
                    Icon="Some icon link3"
                }
            };

            var ourServicesRepositoryMock = new Mock<IOurServicesRepository>();

            ourServicesRepositoryMock.Setup(r => r.AddAsync(It.IsAny<OurService>()))
                .Returns((OurService ourservice) =>
                {
                    ourServices.Add(ourservice);
                    return Task.CompletedTask;
                });

            ourServicesRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) =>
                {
                    return ourServices.FirstOrDefault(service => service.Id == id);
                });

            return ourServicesRepositoryMock;
        }
    }
}
