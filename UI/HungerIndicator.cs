using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Survivaria.Players;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace Survivaria.UI
{
    internal class HungerIndicator : ResourceMenu
    {
        public UIImage hungerIndicator;
        public Texture2D texture;
        Vector2 _drawPosition;

        public override void OnInitialize()
        {
            hungerIndicator = new UIImage(null);
            hungerIndicator.Width.Set(GFX.hungerIndicatorTexture.Width, 0f);
            hungerIndicator.Height.Set(GFX.hungerIndicatorTexture.Height, 0f);
            hungerIndicator.Left.Set(PaddingX, 0f);
            hungerIndicator.Top.Set(PaddingY, 0f);
            backPanel.Append(hungerIndicator);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            SurvivariaPlayer player = Main.LocalPlayer.GetModPlayer<SurvivariaPlayer>();

            int frameHeight = texture.Height / 8;
            int frame = (int)(player.CurrentHunger / player.HungerMaximum * 100 / 12);
            texture = GFX.hungerIndicatorTexture;
            _drawPosition = new Vector2(PaddingX, PaddingY);

            Rectangle sourceRectangle = new Rectangle(0, frameHeight * frame, texture.Width, frameHeight);
            spriteBatch.Draw(texture, _drawPosition, sourceRectangle, Color.White);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime); // don't remove.

            // Checking ContainsPoint and then setting mouseInterface to true is very common. This causes clicks on this UIElement to not cause the player to use current items. 
            if (ContainsPoint(Main.MouseScreen))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
        }
    }
}