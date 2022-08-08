﻿using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using TCG.Base.Interfaces;
using TCG.Extensions.Processors;
using TCG.Base.Parameters;

namespace TCG.Effects;

/// <summary>
/// Defines effect that allow the application of slices effect on an <see cref="IDrawable"/>
/// </summary>
public class Slices : IEffect
{
    /// <summary>
    /// Seed value
    /// </summary>
    public IntParameter Seed { get; set; } = new(0) { Min = 0, Max = int.MaxValue };
    /// <summary>
    /// Count of slices. Must greater or equal to 1.
    /// </summary>
    public IntParameter Count { get; set; } = new(10) { Min = 1, Max = 10 };
    /// <summary>
    /// Min value of slice shift.
    /// </summary>
    public IntParameter MinOffset { get; set; } = new() { Min = -10, Max = 0 };
    /// <summary>
    /// Max value of slice shift
    /// </summary>
    public IntParameter MaxOffset { get; set; } = new() { Min = 0, Max = 10 };
    /// <summary>
    /// Height of the slice. Must greater or equal to 1.
    /// </summary>
    public IntParameter SliceHeight { get; set; } = new(1, int.MaxValue, 1) { Min = 1, Max = 10 };

    public Slices() { }
    public Slices(int count, int sliceHeight)
    {
        Count.Value = count;
        SliceHeight.Value = sliceHeight;
    }

    public Slices WithCount(int value)
    {
        Count.Value = value;
        return this;
    }

    public Slices WithRandomizedCount(int min, int max)
    {
        Count.Min = min;
        Count.Max = max;
        return this;
    }

    public Slices WithSeed(int value)
    {
        Seed.Value = value;
        return this;
    }

    public Slices WithRandomizedSeed(int min, int max)
    {
        Seed.Min = min;
        Seed.Max = max;
        return this;
    }

    public Slices WithMinOffset(int value)
    {
        MinOffset.Value = value;
        return this;
    }

    public Slices WithRandomizedMinOffset(int min, int max)
    {
        MinOffset.Min = min;
        MinOffset.Max = max;
        return this;
    }

    public Slices WithMaxOffset(int value)
    {
        MaxOffset.Value = value;
        return this;
    }

    public Slices WithRandomizedMaxOffset(int min, int max)
    {
        MaxOffset.Min = min;
        MaxOffset.Max = max;
        return this;
    }

    public Slices WithSliceHeight(int value)
    {
        SliceHeight.Value = value;
        return this;
    }

    public Slices WithRandomizedSliceHeight(int min, int max)
    {
        SliceHeight.Min = min;
        SliceHeight.Max = max;
        return this;
    }

    public void Render(Image image, GraphicsOptions graphicsOptions) =>
        image.Mutate(x => x.Slices(Seed, Count, SliceHeight, MinOffset, MaxOffset));
}