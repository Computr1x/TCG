﻿using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using ExNihilo.Base.Interfaces;
using ExNihilo.Base.Parameters;

namespace ExNihilo.Effects;

/// <summary>
/// Defines effect that alter contrast component of the <see cref="IDrawable"/>
/// </summary>
public class Contrast : IEffect
{
    /// <summary>
    /// The proportion of the conversion. Must be greater than or equal to 0.
    /// </summary>
    public FloatParameter Amount { get; set; } = new FloatParameter(0, float.MaxValue, 3) { Min = 0, Max = 3};

    /// <summary>
    /// <inheritdoc cref="Contrast"/>
    /// </summary>
    public Contrast() { }

    /// <summary>
    /// <inheritdoc cref="Contrast"/>
    /// </summary>
    /// <param name="amount"><inheritdoc cref="Amount" path="/summary"/></param>
    public Contrast(float amount)
    {
        Amount.Value = amount;
    }

    /// <summary>
    /// Set Amount value
    /// </summary>
    /// <param name="value"><inheritdoc cref="Amount" path="/summary"/></param>
    public Contrast WithAmount(float value)
    {
        Amount.Value = value;
        return this;
    }
    /// <summary>
    /// Set Amount value randomization parameters.
    /// </summary>
    /// <param name="min">Minimal randomization value. <inheritdoc cref="Amount" path="/summary"/></param>
    /// <param name="max">Maximal randomization value. <inheritdoc cref="Amount" path="/summary"/></param>
    public Contrast WithRandomizedAmount(float min, float max)
    {
        Amount.Min = min;
        Amount.Max = max;
        return this;
    }

    public void Render(Image image, GraphicsOptions graphicsOptions) =>
        image.Mutate(x => x.Contrast(Amount));
}