using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Blogs.Commands
{
    public class AddBlogCommand :IRequest<Unit>
    {
        public string TitleAZ { get; set; }
        public string TitleEN { get; set; }
        public string DetailAZ { get; set; }
        public string DetailEN { get; set; }
        public IFormFile Image { get; set; }
        public string WebRootPath { get; set; }
        public string CreatorName { get; set; }
        public string CreatorSurname { get; set; }
        public string CreatorRole { get; set; }
    }
}
