﻿using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using TCG.Base.Interfaces;

namespace TCG.Effects
{
    public class Glow : IEffect
    {
        public float Radius { get; set; } = 15f;

        public void Render(Image image, GraphicsOptions graphicsOptions) =>
            image.Mutate(x => x.Glow(Radius));
    }
}
