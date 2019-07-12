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
			DrawBar(spriteBatch, player, GFX.hungerIndicatorTexture, 8, (int)(player.CurrentHunger / player.HungerMaximum * 100 / 13 * 1.04 - 0.01));
			DrawBar(spriteBatch, player, GFX.thirstIndicatorTexture, 5, (int)(player.CurrentThirst / player.MaximumThirst * 100 / 21), 8);
			DrawBar(spriteBatch, player, GFX.sanityIndicatorTexture, 5, (int)(player.CurrentSanity / player.MaximumSanity * 100 / 21), 1, 8);
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
		public void DrawBar(SpriteBatch spriteBatch, SurvivariaPlayer player, Texture2D _texture, int divideBy, int frameFormula, int drawPosX = 1, int drawPosY = 1)
		{
			Texture2D texture = _texture;
			int frameHeight = texture.Height / divideBy;
			int frame = frameFormula;
			_drawPosition = new Vector2(backPanel.Left.Pixels - PaddingX * drawPosX, backPanel.Top.Pixels - PaddingY * drawPosY);

			Rectangle sourceRectangle = new Rectangle(0, frameHeight * frame, texture.Width, frameHeight);
			spriteBatch.Draw(texture, _drawPosition, sourceRectangle, Color.White);
		}
    }
}