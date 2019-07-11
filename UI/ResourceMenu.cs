using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Survivaria.Players;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace Survivaria.UI
{
    internal class ResourceMenu : UIState
    {
        public UIPanel backPanel;
        Vector2 _drawPosition;
        public static bool visible = false;

        public const int
            PaddingX = -6,
            PaddingY = PaddingX;

        public override void OnInitialize()
        {
            backPanel = new UIPanel();
            backPanel.Width.Set(182, 0f);
            backPanel.Height.Set(84, 0f);
            backPanel.Left.Set(Main.screenWidth / 2f - backPanel.Width.Pixels / 2f, 0f);
            backPanel.Top.Set(Main.screenHeight / 2f - backPanel.Height.Pixels / 2f, 0f);
            backPanel.BackgroundColor = new Color(0, 0, 0, 0);
            backPanel.OnMouseDown += new MouseEvent(DragStart);
            backPanel.OnMouseUp += new MouseEvent(DragEnd);
            Append(backPanel);
        }

        Vector2 _offset;
        public bool dragging = false;
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
            SurvivariaPlayer player = Main.LocalPlayer.GetModPlayer<SurvivariaPlayer>();
            Vector2 mousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (backPanel.ContainsPoint(mousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                backPanel.Left.Set(mousePosition.X - _offset.X, 0f);
                backPanel.Top.Set(mousePosition.Y - _offset.Y, 0f);
                Recalculate();
            }
            DrawHungerIndicator(spriteBatch, player);
            DrawThirstIndicator(spriteBatch, player);
        }

        public void DrawHungerIndicator(SpriteBatch spriteBatch, SurvivariaPlayer player)
        {
            Texture2D texture = GFX.hungerIndicatorTexture;
            int frameHeight = texture.Height / 8;
			int frame = (int)(player.CurrentHunger / player.HungerMaximum * 100 / 13 * 1.04 - 0.01);
            _drawPosition = new Vector2(backPanel.Left.Pixels - PaddingX, backPanel.Top.Pixels - PaddingY);

			Rectangle sourceRectangle = new Rectangle(0, frameHeight * frame, texture.Width, frameHeight);
            spriteBatch.Draw(texture, _drawPosition, sourceRectangle, Color.White);
        }

        public void DrawThirstIndicator(SpriteBatch spriteBatch, SurvivariaPlayer player)
        {
            Texture2D texture = GFX.thirstIndicatorTexture;
            int frameHeight = texture.Height / 5;
            int frame = (int)(player.CurrentThirst / player.MaximumThirst * 100 / 21);
            _drawPosition = new Vector2(backPanel.Left.Pixels - PaddingX * 8, backPanel.Top.Pixels - PaddingY);

            Rectangle sourceRectangle = new Rectangle(0, frameHeight * frame, texture.Width, frameHeight);
            spriteBatch.Draw(texture, _drawPosition, sourceRectangle, Color.White);
        }
    }
}