using UnityEngine;

[System.Serializable]
public class GameSettingsModel
{
    public enum BridgeModul
    {
        Moke = 0,
        JavaScript = 1
    }
    [Header("Debug:")]
    [SerializeField] private bool disableUnityLog = false;
    [SerializeField] private bool testAds = false;

    [Header("Level:")]
    [Range(1, 1000)]
    [SerializeField] private int levelCount = 10;
    [Range(1, 1000)]
    [SerializeField] private float checkBallPeriods = 1;

    [Header("Bridge:")]
    [SerializeField] private BridgeModul defaultBridge;
    [SerializeField] private float bridgeWaitTimeMessage;
    [SerializeField] private float sendShotHistoryEverySeconds = 0.5f;

    [Header("Sound:")]
    [SerializeField] private SoundController soundControllerTemplate = null;

    [Header("Prefabs:")]
    [SerializeField] private FacadeBridgeWorker facadeNetworkWorkeradNetwork = null;
    [SerializeField] private GameFieldView fieldTemplate = null;
    [SerializeField] private BallObjectView ballSimpleTemplate = null;
    [SerializeField] private BallObjectView ballBonusesFlashTemplate = null;
    [SerializeField] private BallObjectView ballBonusesFreezesTemplate = null;
    [SerializeField] private BallObjectView ballBonusesBombTemplate = null;
    [SerializeField] private BallObjectView ballBonusesXTemplate = null;

    [Header("Prefabs VFX:")]
    [SerializeField] private LightningVfxView lightingBoltVfxTemplate = null;
    [SerializeField] private WindVfxView windVfxTemplate = null;
    [SerializeField] private BubbleBurstVfxView bubbleBurstVfxTemplate = null;

    public void Initialize(GameSettingsModel obj)
    {
        this.disableUnityLog = obj.DisableUnityLog;
        this.testAds = obj.TestAds;

        this.levelCount = obj.LevelCount;
        this.defaultBridge = obj.DefaultBridge;
        this.bridgeWaitTimeMessage = obj.BridgeWaitTimeMessage;
        this.facadeNetworkWorkeradNetwork = obj.FacadeNetworkWorker;

        this.lightingBoltVfxTemplate = obj.LightingBoltVfxTemplate;
        this.windVfxTemplate = obj.WindVfxTemplate;
        this.bubbleBurstVfxTemplate = obj.BubbleBurstVfxTemplate;

        this.fieldTemplate = obj.FieldTemplate;
        this.ballSimpleTemplate = obj.BallSimpleTemplate;
        this.ballBonusesFlashTemplate = obj.BallBonusesFlashTemplate;
        this.ballBonusesFreezesTemplate = obj.BallBonusesFreezesTemplate;
        this.ballBonusesBombTemplate = obj.BallBonusesBombTemplate;
        this.ballBonusesXTemplate = obj.BallBonusesXTemplate;
        this.sendShotHistoryEverySeconds = obj.SendShotHistoryEverySeconds;
        this.checkBallPeriods = obj.CheckBallPeriodsSecond;

        this.soundControllerTemplate = obj.SoundControllerTemplate;
    }


    public int LevelCount
    {
        get
        {
            return levelCount;
        }
    }

    public BridgeModul DefaultBridge
    {
        get
        {
            return defaultBridge;
        }
    }

    public float BridgeWaitTimeMessage
    {
        get
        {
            return bridgeWaitTimeMessage;
        }
    }

    public FacadeBridgeWorker FacadeNetworkWorker
    {
        get
        {
            return facadeNetworkWorkeradNetwork;
        }
    }

    public LightningVfxView LightingBoltVfxTemplate
    {
        get
        {
            return lightingBoltVfxTemplate;
        }
    }
    
    public WindVfxView WindVfxTemplate
    {
        get
        {
            return windVfxTemplate;
        }
    }

    public BubbleBurstVfxView BubbleBurstVfxTemplate
    {
        get
        {
            return bubbleBurstVfxTemplate;
        }
    }

    public GameFieldView FieldTemplate
    {
        get
        {
            return fieldTemplate;
        }
    }

    public BallObjectView BallSimpleTemplate
    {
        get
        {
            return ballSimpleTemplate;
        }
    }

    public BallObjectView BallBonusesFlashTemplate
    {
        get
        {
            return ballBonusesFlashTemplate;
        }
    }

    public BallObjectView BallBonusesFreezesTemplate
    {
        get
        {
            return ballBonusesFreezesTemplate;
        }
    }

    public BallObjectView BallBonusesBombTemplate
    {
        get
        {
            return ballBonusesBombTemplate;
        }
    }

    public BallObjectView BallBonusesXTemplate
    {
        get
        {
            return ballBonusesXTemplate;
        }
    }

    public float SendShotHistoryEverySeconds 
    {
        get
        {
          return  sendShotHistoryEverySeconds;
        }
    }

    public bool DisableUnityLog 
    { 
        get
        {
            return disableUnityLog;
        }
    }

    public bool TestAds 
    { 
        get
        {
            return testAds;
        }
    }

    public float CheckBallPeriodsSecond
    {
        get
        {
            return checkBallPeriods;
        }
    }

    public SoundController SoundControllerTemplate
    {
        get
        {
            return soundControllerTemplate;
        }
    }
}