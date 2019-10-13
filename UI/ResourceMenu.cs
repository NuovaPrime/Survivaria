using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Design;
using Survivaria.Players;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using ReLogic.Graphics;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Survivaria.UI
{
    internal class ResourceMenu : UIState
    {
        public override void OnInitialize()
        {
            backPanel = new UIPanel();
            backPanel.Width.Set(40, 0f);
            backPanel.Height.Set(124, 0f);
            backPanel.Left.Set(Main.screenWidth / 1.1f, 0f); //Main.screenWidth / 1.154f
            backPanel.Top.Set(Main.screenHeight / 12f, 0f);
            backPanel.BackgroundColor = new Color(0, 0, 0, 0);
            backPanel.BorderColor = new Color(0, 0, 0, 0);
            backPanel.OnMouseDown += new MouseEvent(DragStart);
            backPanel.OnMouseUp += new MouseEvent(DragEnd);
            Append(backPanel);
        }

        Vector2 _offset;
        public bool dragging = false;
        private int displayRCol;
        private int displayGCol;
        private int displayBCol;

        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            _offset = new Vector2(evt.MousePosition.X - backPanel.Left.Pixels, evt.MousePosition.Y - backPanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            backPanel.Left.Set(end.X - _offset.X, 0f);
            backPanel.Top.Set(end.Y - _offset.Y, 0f);

            Recalculate();
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Mod mod = SurvivariaMod.Instance;
            SurvivariaPlayer player = Main.LocalPlayer.GetModPlayer<SurvivariaPlayer>();
            Vector2 mousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (!locationInitialized)
            {
                if (player.MenuOffset == Vector2.Zero)
                {
                    backPanel.Left.Set(Main.screenWidth / 1.1f, 0f); //Main.screenWidth / 1.154f
                    backPanel.Top.Set(Main.screenHeight / 12f, 0f);
                }
                else
                {
                    backPanel.Left.Set(player.MenuOffset.X, 0f);
                    backPanel.Top.Set(player.MenuOffset.Y, 0f);
                } 
                Recalculate();
                locationInitialized = true;
            }
            if (backPanel.ContainsPoint(mousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                backPanel.Left.Set(mousePosition.X - _offset.X, 0f);
                backPanel.Top.Set(mousePosition.Y - _offset.Y, 0f);
                player.MenuOffset = new Vector2(backPanel.Left.Pixels, backPanel.Top.Pixels);
                Recalculate();
            }
            //if (mod.GetConfig<SurvivariaConfigServer>().SanityEnabled)
            //DrawBar(spriteBatch, player, GFX.sanityIndicatorTexture, 5, (int)(player.CurrentSanity / player.MaximumSanity * 100 / 21), 1, 10);
            if (mod.GetConfig<SurvivariaConfigServer>().HungerEnabled)
                DrawBar(spriteBatch, player, GFX.hungerIndicatorTexture, 8, (int)(player.CurrentHunger / player.HungerMaximum * 100 / 13 * 1.04 - 0.01));
            if (mod.GetConfig<SurvivariaConfigServer>().ThirstEnabled)
                DrawBar(spriteBatch, player, GFX.thirstIndicatorTexture, 5, (int)(player.CurrentThirst / player.MaximumThirst * 100 / 21), 1.6f, 5);
            //if (mod.GetConfig<SurvivariaConfigServer>().TemperatureEnabled)
            //DrawTemperatureFill(spriteBatch, player, -0.4f, 14.5f);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteBatch">Spritebatch.</param>
        /// <param name="player">Inst. player.</param>
        /// <param name="_texture">Bar texture.</param>
        /// <param name="divideBy">Divide by the amount of frames required to find the height of each frame.</param>
        /// <param name="frameFormula">The formula for frame display.</param>
        /// <param name="drawPosX">Modify the PosX draw. Do always divisible by 8. *8, *16, *24</param>
        /// <param name="drawPosY">Modify the PosY draw. Do always divisible by 8. *8, *16, *24</param>
        public void DrawBar(SpriteBatch spriteBatch, SurvivariaPlayer player, Texture2D _texture, int divideBy, int frameFormula, float drawPosX = 1, float drawPosY = 1)
        {
            Texture2D texture = _texture;
            int frameHeight = texture.Height / divideBy;
            int frame = frameFormula;
            _drawPosition = new Vector2(backPanel.Left.Pixels - PaddingX * drawPosX, backPanel.Top.Pixels - PaddingY * drawPosY);

            Rectangle sourceRectangle = new Rectangle(0, frameHeight * frame, texture.Width, frameHeight);
            spriteBatch.Draw(texture, _drawPosition, sourceRectangle, Color.White);
        }
        public void DrawTemperatureIndicator(SpriteBatch spriteBatch, SurvivariaPlayer player, float drawPosX = 1f, float drawPosY = 1f)
        {
            _drawPosition = new Vector2(backPanel.Left.Pixels - PaddingX * drawPosX, backPanel.Top.Pixels - PaddingY * drawPosY);
            spriteBatch.Draw(GFX.temperatureBorderTexture, _drawPosition, Color.White);
            DrawTemperatureText(spriteBatch, player, drawPosX * -1.4f, drawPosY * 1.15f);

        }
        public void DrawTemperatureFill(SpriteBatch spriteBatch, SurvivariaPlayer player, float drawPosX = 1f, float drawPosY = 1f)
        {
            _drawPosition = new Vector2(backPanel.Left.Pixels - PaddingX * drawPosX, backPanel.Top.Pixels - PaddingY * drawPosY);
            spriteBatch.Draw(GFX.temperatureFillTexture, _drawPosition, insideColor);
            DrawTemperatureIndicator(spriteBatch, player, drawPosX, drawPosY);
        }
        public void DrawTemperatureText(SpriteBatch spriteBatch, SurvivariaPlayer player, float drawPosX = 1f, float drawPosY = 1f)
        {
            _drawPosition = new Vector2(backPanel.Left.Pixels - PaddingX * drawPosX, backPanel.Top.Pixels - PaddingY * drawPosY);
            spriteBatch.DrawString(Main.fontDeathText, delayedTemperature + "°", _drawPosition, Color.Black, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 1);
        }
        public override void Update(GameTime gameTime)
        {
            Player player = Main.LocalPlayer;
            SurvivariaPlayer modPlayer = player.GetModPlayer<SurvivariaPlayer>();

            changeTimer++;
            changeTimer2++;
            if (delayedTemperature < modPlayer.CurrentTemperature && changeTimer > 8)
            {
                delayedTemperature++;
                changeTimer = 0;
            }
            if (delayedTemperature > modPlayer.CurrentTemperature && changeTimer > 8)
            {
                delayedTemperature--;
                changeTimer = 0;
            }

            int temp24 = (int)modPlayer.CurrentTemperature - 24;
            if (changeTimer2 > 8)
            {
                RCol = ((250 + temp24 * 4 - Math.Abs(temp24) * 4) + RCol * 32) / 33;
                GCol = ((250 - Math.Abs(temp24) * 3) + GCol * 32) / 33;
                BCol = ((250 - temp24 * 4 - Math.Abs(temp24 * 4) + BCol * 32) / 33);
                changeTimer2 = 0;
            }

            displayRCol = (RCol + displayRCol) / 2;
            displayGCol = (GCol + displayGCol) / 2;
            displayBCol = (BCol + displayBCol) / 2;

            /*changeTimer2++;
            if (modPlayer.CurrentTemperature < 24)
            {
                if (changeTimer2 > 6)
                {
                    if (colorDifferenceRed != 0)
                        colorDifferenceRed--;
                    colorDifferenceBlue--;
                    changeTimer2 = 0;
                }
                
            }
            if (modPlayer.CurrentTemperature > 24)
            {
                if (changeTimer2 > 12)
                {
                    if (colorDifferenceBlue != 0)
                        colorDifferenceBlue++;
                    colorDifferenceRed++;
                    changeTimer2 = 0;
                }
            }
            else if (modPlayer.CurrentTemperature == 24)
            {
                colorDifferenceBlue = 0;
                colorDifferenceRed = 0;
            }*/

            //insideColor = new Color(224 + colorDifferenceBlue * 3, 224 + colorDifferenceBlue * 3 - colorDifferenceRed * 3, 224 - colorDifferenceRed * 3);
            insideColor = new Color(displayRCol, displayGCol, displayBCol);

            //Main.NewText("The inside colors are: " + "R: " + insideColor.R + " " + "G: " + insideColor.G + " " + "B: " + insideColor.B);
            //Main.NewText("The blue color difference is: " + colorDifferenceBlue);
            //Main.NewText("The red color difference is: " + colorDifferenceRed);

            base.Update(gameTime);
        }

        internal bool locationInitialized { get; set; } = false;
        public UIPanel backPanel { get; set; }
        internal int delayedTemperature { get; set; } = 24;
        int colorDifferenceBlue { get; set; } = 0;
        int colorDifferenceRed { get; set; } = 0;
        int changeTimer { get; set; } = 0;
        int changeTimer2 { get; set; } = 0;
        Color insideColor { get; set; }
        Vector2 _drawPosition { get; set; }
        public static bool visible { get; set; } = true;
        public int RCol { get; private set; }
        public int GCol { get; private set; }
        public int BCol { get; private set; }

        public const float
            PaddingX = -6,
            PaddingY = PaddingX;
    }
}