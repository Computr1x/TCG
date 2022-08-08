﻿using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using TCG.Base.Interfaces;
using TCG.Base.Parameters;

namespace TCG.Effects;

/// <summary>
/// Defines effect that allow the multiplication of alpha component of the <see cref="IDrawable"/>
/// </summary>
public class Opacity : IEffect
{
    /// <summary>
    /// The proportion of the conversion. Must be between 0 and 1.
    /// </summary>
    public FloatParameter Amount { get; set; } = new(0, 1, 0.5f) { Min = 0, Max = 1 };

    public Opacity() { }

    public Opacity(float amount)
    {
        Amount.Value = amount;
    }

    public Opacity WithAmount(float value)
    {
        Amount.Value = value;
        return this;
    }

    public Opacity WithRandomizedAmount(float min, float max)
    {
        Amount.Min = min;
        Amount.Max = max;
        return this;
    }

    public void Render(Image image, GraphicsOptions graphicsOptions) =>
        image.Mutate(x => x.Opacity(Amount));
}
