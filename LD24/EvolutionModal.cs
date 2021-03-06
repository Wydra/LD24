﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD24
{
    class EvolutionModal : Sprite
    {
        public static int SelectedIndex = 0;
        private SpriteFont Font;

        private static Evolution[] MenuItems;

        public static void SetMenuItems(Evolution[] items)
        {
            MenuItems = items;
            SelectedIndex = 0;
        }

        public static EvolutionModal Build()
        {
            return new EvolutionModal(GameAssets.Backdrop, new Rectangle(0, 0, 512, 256), GameAssets.FontArial);
        }

        public EvolutionModal(Texture2D texture, Rectangle drawBounds, SpriteFont font)
            : base (texture, drawBounds)
        {
            this.Font = font;
        }

        public override void Update(SceneGraph graph)
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Rectangle map, Camera camera)
        {
            int xOffset = (camera.screen.Width - this.DrawBounds.Width) / 2;
            int yOffset = (camera.screen.Height - this.DrawBounds.Height) / 2;
            this.Position = new Vector2(xOffset, yOffset);

            spriteBatch.Draw(
                    Texture,
                    Position,
                    DrawBounds,
                    Tint,
                    Rotation,
                    Vector2.Zero,
                    1.0f,
                    SpriteEffects.None,
                    0f);

            Vector2 textOffset = new Vector2(32, 32);
            string text = GetMenu();
            spriteBatch.DrawString(Font, text, Position + textOffset, Color.White);
        }

        public void MoveCaratUp()
        {
            SelectedIndex++;
            ClampMenu();
        }

        public void MoveCaratDown()
        {
            SelectedIndex--;
            ClampMenu();
        }

        public void Select()
        {
            GameStats.SelectEvolution(MenuItems[SelectedIndex].ID);
        }

        private void ClampMenu()
        {
            if (SelectedIndex < 0)
            {
                SelectedIndex = 0;
            }
            else if (SelectedIndex > MenuItems.Length - 1)
            {
                SelectedIndex = MenuItems.Length - 1;
            }
        }

        private string GetMenu()
        {
            string text = "Evolution Unlocked!" + Environment.NewLine + "(Up/Down to select; Enter to choose)" + Environment.NewLine + Environment.NewLine;

            for (int x = 0; x < MenuItems.Length; x++)
            {
                if (x == SelectedIndex)
                {
                    text += "->";
                }
                else
                {
                    text += "  ";
                }
                text += MenuItems[x].Description + Environment.NewLine;
            }

            return text;
        }
    }
}