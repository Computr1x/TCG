﻿using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using TCG.Processors;
using static TCG.Processors.PolarCoordinatesProcessor;

namespace TCG.Extensions.Processors;

public static class PolarCoordinatesProcessorExtension
{
    /// <summary>
    /// Transform image coordinates from cartesian to polar.
    /// </summary>
    public static IImageProcessingContext PolarCoordinates(this IImageProcessingContext sourse)
    {
        return sourse.ApplyProcessor(new PolarCoordinatesProcessor());
    }

    /// <summary>
    /// Transform image coordinates from cartesian to polar and vice versa.
    /// </summary>
    public static IImageProcessingContext PolarCoordinates(this IImageProcessingContext sourse, PolarConversionType conversionType)
    {
        return sourse.ApplyProcessor(new PolarCoordinatesProcessor() {  PolarType = conversionType});
    }

    /// <summary>
    /// Transform area coordinates from cartesian to polar and vice versa.
    /// </summary>
    public static IImageProcessingContext PolarCoordinates(this IImageProcessingContext sourse, Rectangle rectangle, PolarConversionType conversionType)
    {
        return sourse.ApplyProcessor(new PolarCoordinatesProcessor() { Area = rectangle, PolarType = conversionType });
    }
}
