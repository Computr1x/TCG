﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCG.Base.Interfaces;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;

namespace TCG.Base.Abstract;

public abstract class BaseDrawable : IDrawable
{
    public IBrush Brush  { get; set; } = Brushes.Solid(Color.Black);
    public IPen Pen { get; set; } = Pens.Solid(Color.White, 1);

    public DrawableType Type { get; set; } = DrawableType.Filled;

    public IList<IEffect> Effects { get; }

    protected BaseDrawable()
    {
        Effects = new List<IEffect>();
    }

    public abstract void Render(Image image, GraphicsOptions graphicsOptions);

}

[Flags]
public enum DrawableType : byte { Filled = 1 << 0, Outlined = 1 << 1, FillWithOutline = Filled | Outlined}
