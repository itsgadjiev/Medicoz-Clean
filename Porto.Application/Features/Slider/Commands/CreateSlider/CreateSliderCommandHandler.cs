﻿using MediatR;

namespace Medicoz.Application.Features.Slider.Commands.CreateSlider;

public class CreateSliderCommandHandler : IRequestHandler<CreateSliderCommand, Unit>
{
    public CreateSliderCommandHandler()
    {

    }
    public async Task<Unit> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
    {

    }
}
