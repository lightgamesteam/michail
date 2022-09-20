using Core.Cells;

namespace Core
{
    namespace BattleShip
    {
        namespace Builder
        {
            public class DoubleDeckShipBuilder : ShipBuilder
            {
                public DoubleDeckShipBuilder(ShipSettingsModel settings) : base(settings)
                {
                }

                public override void SetDecks()
                {
                    Ship.Decks = new CoreBattleShipDeck[] { new CoreBattleShipDeck(1, Ship), new CoreBattleShipDeck(2, Ship) };
                }

                public override void SetMask()
                {
                    var horizontalBaseMask = new[,]
                   {
                        { new ShipMatrix(-1, -1),  new ShipMatrix(0, -1),       new ShipMatrix(1, -1),       new ShipMatrix(2, -1) },
                        { new ShipMatrix(-1, 0),   new ShipMatrix(0, 0, true),  new ShipMatrix(1, 0, true),  new ShipMatrix(2, 0)  },
                        { new ShipMatrix(-1, 1),   new ShipMatrix(0, 1),        new ShipMatrix(1, 1),        new ShipMatrix(2, 1)  },
                    };

                    var offsetStartPointForBaseMask = new[] { new MatrixPoint(-1, 0) };


                    Ship.Mask = new ShipMask();
                    Ship.Mask.Horizontal = new ShipMaskOrientation(horizontalBaseMask, offsetStartPointForBaseMask);
                    var maskCreator = new ShipMaskOrientationCreator(Ship.Mask.Horizontal);
                    Ship.Mask.Vertical = maskCreator.Rotate90();
                }

                public override void SetName()
                {
                    Ship.Name = settings.Name;
                }

                public override void SetType()
                {
                    Ship.Type = ShipType.DoubleDeck;
                }
            }
        }
    }
}