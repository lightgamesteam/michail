using Core.BattleShip;
using Core.BattleShip.Builder;

public abstract class ShipSetupDataCommand : BaseCommand
{
    protected ShipSetupModel CreateBaseModel(PlayerModel player, ShipOrientation orientation, ShipSettingsModel shipSettings)
    {
        var result = new ShipSetupModel();
        var carpenter = new Carpenter();
        CoreShip ship = null;


        switch (shipSettings.Type)
        {
            case ShipType.SingleDeck:
                var builderSingleDeckShip = new SingleDeckShipBuilder(shipSettings);
                ship = carpenter.Build(builderSingleDeckShip);
                break;
            case ShipType.DoubleDeck:
                var builderDoubleDeckShip = new DoubleDeckShipBuilder(shipSettings);
                ship = carpenter.Build(builderDoubleDeckShip);
                break;
            case ShipType.ThreeDeck:
                var builderThreeDeckShip = new ThreeDeckShipBuilder(shipSettings);
                ship = carpenter.Build(builderThreeDeckShip);
                break;
            case ShipType.FourDeckShip:
                var builderFourDeckShip = new FourDeckShipBuilder(shipSettings);
                ship = carpenter.Build(builderFourDeckShip);
                break;
        }

        switch (orientation)
        {
            case ShipOrientation.Horizontal:
                result.Orientation = ship.Mask.Horizontal;
                ship.Orientation = ShipOrientation.Horizontal;
                break;
            case ShipOrientation.Vertical:
                result.Orientation = ship.Mask.Vertical;
                ship.Orientation = ShipOrientation.Vertical;
                break;
            default:
                result.Orientation = ship.Mask.Horizontal;
                ship.Orientation = ShipOrientation.Horizontal;
                break;
        }

        result.CoreShip = ship;
        result.Settings = shipSettings;
        result.Player = player;

        return result;
    }
}