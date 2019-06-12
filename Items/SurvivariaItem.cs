﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items
{
    public abstract class SurvivariaItem : ModItem
    {
        private readonly string _displayName, _tooltip;
        private readonly int _width, _height;

        protected SurvivariaItem(string displayName, string tooltip, int width, int height, int value = 0, int rarity = ItemRarityID.White)
        {
            _displayName = displayName;
            _tooltip = tooltip;

            Value = value;
            Rarity = rarity;
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault(_displayName);
            Tooltip.SetDefault(_tooltip);
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            item.width = _width;
            item.height = _height;

            item.value = Value;
            item.rare = Rarity;
        }

        public int Value { get; }
        public int Rarity { get; }
    }
}
