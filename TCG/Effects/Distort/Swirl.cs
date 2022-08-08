﻿using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using TCG.Base.Interfaces;
using TCG.Extensions.Processors;
using TCG.Base.Parameters;

namespace TCG.Effects;

/// <summary>
/// Defines effect that allow the application of swirl effect on an <see cref="IDrawable"/>
/// </summary>
public class Swirl : IEffect
{
    /// <summary>
    /// Coordinates of effect center.
    /// </summary>
    public PointParameter Point { get; set; } = new();
    /// <summary>
    /// Radius of effect. Must be greater or equal to 0.
    /// </summary>
    public FloatParameter Radius { get; set; } = new(0, float.MaxValue, 100f) { Min = 1f, Max = 150f };
    /// <summary>
    /// Swirl angle in degrees. Must be greater or equal to 0.
    /// </summary>
    public FloatParameter Degree { get; set; } = new(0, float.MaxValue, 10f) { Min = 0f, Max = 360f };
    /// <summary>
    /// Swirl twists count. Must be greater or equal to 0.
    /// </summary>
    public FloatParameter Twists { get; set; } = new(0, float.MaxValue, 0.5f) { Min = 0f, Max = 3f };

    public Swirl() { }

    public Swirl(float radius, float degree, float twists)
    {
        Radius.Value = radius;
        Degree.Value = degree;
        Twists.Value = twists;
    }

    public Swirl WithPoint(int x, int y)
    {
        Point.Value = new Point(x, y);
        return this;
    }

    public Swirl WithRandomizedPoint(int minX, int maxX, int minY, int maxY)
    {
        Point.X.Min = minX;
        Point.X.Max = maxX;
        Point.Y.Min = minY;
        Point.Y.Max = maxY;
        return this;
    }

    public Swirl WithRadius(float value)
    {
        Radius.Value = value;
        return this;
    }

    public Swirl WithRandomizedRadius(float min, float max)
    {
        Radius.Min = min;
        Radius.Max = max;
        return this;
    }

    public Swirl WithDegree(float value)
    {
        Degree.Value = value;
        return this;
    }

    public Swirl WithRandomizedDegree(float min, float max)
    {
        Degree.Min = min;
        Degree.Max = max;
        return this;
    }

    public Swirl WithTwists(float value)
    {
        Twists.Value = value;
        return this;
    }

    public Swirl WithRandomizedTwists(float min, float max)
    {
        Twists.Min = min;
        Twists.Max = max;
        return this;
    }

    public void Render(Image image, GraphicsOptions graphicsOptions)
    {
        image.Mutate(x => x.Swirl(Point.X, Point.Y, Radius, Degree, Twists));
    }
}
