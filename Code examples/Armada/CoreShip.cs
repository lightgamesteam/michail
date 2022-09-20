namespace Core
{
    namespace BattleShip
    {
        public class CoreShip 
        {
            public bool IsAlive()
            {
                var destroyCount = 0;
                foreach (var item in Decks)
                {
                    if (item.IsDestroy)
                    {
                        destroyCount++;
                    }
                }
                return destroyCount < Decks.Length;
            }

            public string Name { get; set; }
            public ShipType Type { get; set; }
            public CoreBattleShipDeck[] Decks { get; set; }
            public ShipMask Mask { get; set; }
            public ShipOrientation Orientation { get; set; }
            public ShipMaskOrientation MaskOrientation
            {
                get
                {
                    switch (Orientation)
                    {
                        case ShipOrientation.Horizontal:
                            return Mask.Horizontal;
                        case ShipOrientation.Vertical:
                            return Mask.Vertical;
                        default:
                            return null;
                    }
                }
            }


            public int DecksCount
            {
                get
                {
                    return Decks.Length;
                }
            }

            public CoreBattleShipDeck BaseDeck
            {
                get
                {
                    return Decks[0];
                }
            }
        }
    }
}