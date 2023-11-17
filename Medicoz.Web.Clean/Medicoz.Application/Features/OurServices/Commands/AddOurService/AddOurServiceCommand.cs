using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.OurServices.Commands.AddOurService
{
    public class AddOurServiceCommand : IRequest<Unit>
    {
        public string Icon { get; set; }
        public string TitleAz { get; set; }
        public string TitleEn { get; set; }
        public string DescriptionAz { get; set; }
        public string DescriptionEn { get; set; }
    }
}
