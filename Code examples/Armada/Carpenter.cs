namespace Core
{
    namespace BattleShip
    {
        namespace Builder
        {
            public class Carpenter
            {
                public CoreShip Build(ShipBuilder shipBuilder)
                {
                    shipBuilder.Create();
                    shipBuilder.SetName();
                    shipBuilder.SetType();
                    shipBuilder.SetDecks();
                    shipBuilder.SetMask();

                    return shipBuilder.Ship;
                }
            }
        }
    }
}