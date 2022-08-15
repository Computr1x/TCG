﻿using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using ExNihilo.Base.Interfaces;

namespace ExNihilo.Effects;

/// <summary>
/// Defines extension that allow the adjustment of the contrast of an image via its histogram.
/// </summary>
public class HistogramEqualization : IEffect
{
    public void Render(Image image, GraphicsOptions graphicsOptions) =>
        image.Mutate(x => x.HistogramEqualization());
}