﻿using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using TCG.Base.Interfaces;
using TCG.Base.Parameters;
using TCG.Base.Utils;

namespace TCG.Base.Abstract;

public abstract class BaseDrawableWithBrushAndPen : BaseDrawable
{
    /// <summary>
    /// Represents the pen with which to stroke an object.
    /// </summary>
    public BrushParameter Brush { get; } = new() {  DefaultValue = Brushes.Solid(Color.Black) };
    /// <summary>
    /// Represents the pen with which to outlined an object.
    /// </summary>
    public PenParameter Pen { get; } = new(Pens.Solid(Color.White, 1));
    /// <summary>
    /// Specifies the rendering type of an object
    /// </summary>
    public EnumParameter<DrawableType> Type { get;  } = new(DrawableType.Filled);
}

