using MediatR;
using Medicoz.Application.Constants;
using Medicoz.Application.Contracts.FileService;
using Medicoz.Application.Contracts.Identity;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Exceptions;
using Medicoz.Application.Features.Departments.Commands.AddDepartment;
using Medicoz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Blogs.Commands
{
    public class AddBlogCommandHandler : IRequestHandler<AddBlogCommand, Unit>
    {
        private readonly IFileService _fileService;
        private readonly IUserService _userService;
        private readonly IBlogRepository _blogRepository;

        public AddBlogCommandHandler(IFileService fileService, IUserService userService, IBlogRepository blogRepository)
        {
            _fileService = fileService;
            _userService = userService;
            _blogRepository = blogRepository;
        }
        public async Task<Unit> Handle(AddBlogCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddBlogCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new CustomValidationException(validationResult.Errors);
            }

            var path = Path.Combine(request.WebRootPath, "uploads/images");
            var imgUrl = _fileService.Upload(request.Image, path);

            var creator = await _userService.GetCurrentUserAsync();

            Blog department = new()
            {
                Id = Guid.NewGuid().ToString(),
                Detail = new Dictionary<string, string>
                {
                    { LocalizationLanguages.AZ, request.DetailAZ },
                    { LocalizationLanguages.EN, request.DetailEN }
                },
                Title = new Dictionary<string, string>
                {
                    { LocalizationLanguages.AZ, request.TitleAZ },
                    { LocalizationLanguages.EN, request.TitleEN }
                },
                ImageUrl = imgUrl,
                CreatorName = creator.FirstName,
                ApplicationUserId = creator.Id,
                CreatorSurname = creator.LastName,

            };

            await _blogRepository.AddAsync(department);
            await _blogRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
