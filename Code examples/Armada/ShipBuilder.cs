namespace Core
{
    namespace BattleShip
    {
        namespace Builder
        {
            public abstract class ShipBuilder
            {
                protected ShipSettingsModel settings = null;
                public ShipBuilder(ShipSettingsModel settings)
                {
                    this.settings = settings;
                }

                public CoreShip Ship { get; protected set; }

                public void Create()
                {
                    Ship = new CoreShip();
                }

                public abstract void SetDecks();
                public abstract void SetMask();
                public abstract void SetName();
                public abstract void SetType();
            }
        }
    }
}