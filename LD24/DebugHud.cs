﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD24
{
    class DebugHud
    {
        public Vector2 Position { get; set; }
        public Vector2 Position2 { get; set; }
        public Color ColorNormal { get; set; }
        public Color ColorSlow { get; set; }
        public Color ColorShadow { get; set; }
        public SpriteFont Font { get; set; }

        private int frameRate = 0;
        private int frameCounter = 0;
        private TimeSpan elapsedTime = TimeSpan.Zero;
        private TimeSpan updateInterval = TimeSpan.FromMilliseconds(100);

        public DebugHud(Vector2 position, SpriteFont font, Color colorNormal, Color colorSlow, Color colorShadow)
        {
            Position = position;
            Position2 = new Vector2(Position.X + 1, Position.Y + 1);
            ColorNormal = colorNormal;
            ColorSlow = colorSlow;
            ColorShadow = colorShadow;
            Font = font;
        }

        public void Draw(GameTime gameTime, SpriteBatch SpriteBatch)
        {
            SetFPS(gameTime.ElapsedGameTime);

            string text = "FPS: " + frameRate;

            SpriteBatch.Begin();

            SpriteBatch.DrawString(Font, text, Position2, ColorShadow);

            if (gameTime.IsRunningSlowly)
            {
                SpriteBatch.DrawString(Font, text, Position, ColorSlow);
            }
            else
            {
                SpriteBatch.DrawString(Font, text, Position, ColorNormal);
            }

            SpriteBatch.End();
        }

        public void SetFPS(TimeSpan elapsedGameTime)
        {
            elapsedTime += elapsedGameTime;

            if (elapsedTime > updateInterval)
            {
                frameRate = frameCounter * (1000 / elapsedTime.Milliseconds);
                elapsedTime = TimeSpan.Zero;
                frameCounter = 0;
            }

            frameCounter++;
        }
    }
}