using Commands;
using Commands.SceneCommands;
using Commands.UICommands;
using Mediators;
using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;

public class MainContextRoot : MVCSContext
{
    public MainContextRoot(MonoBehaviour contextView) : base(contextView, ContextStartupFlags.MANUAL_MAPPING)
    {
    }

    // CoreComponents
    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>(); //Unbind to avoid a conflict!
        injectionBinder.Bind<ICommandBinder>().To<EventCommandBinder>().ToSingleton();
        injectionBinder.Bind<IExecutor>().To<CoroutineExecutor>().ToSingleton();
        injectionBinder.Bind<IBridgeExecutor>().To<BridgeExecutor>().ToSingleton();
        injectionBinder.Bind<ITimerExecutor>().To<TimerExecutor>().ToSingleton();
        injectionBinder.Bind<ISoundExecutor>().To<SoundExecutor>().ToSingleton();


        injectionBinder.Bind<GameSettingsModel>().ToSingleton();
        injectionBinder.Bind<SceneModel>().ToSingleton();
        injectionBinder.Bind<PlayersHolderModel>().ToSingleton();
        injectionBinder.Bind<GameModel>().ToSingleton();
        injectionBinder.Bind<OnStartModel>().ToSingleton();
        injectionBinder.Bind<PoolBridgeContract>().ToSingleton();
        injectionBinder.Bind<UnityInstanceModel>().ToSingleton();
        injectionBinder.Bind<CanvasNativeModel>().ToSingleton();
        injectionBinder.Bind<ScreenModel>().ToSingleton();
        injectionBinder.Bind<LevelSettingsModel>().ToSingleton();
        injectionBinder.Bind<GameBallObjectPool<BallObjectView>>().ToSingleton();
        injectionBinder.Bind<CurrentPlatformModel>().ToSingleton();
        injectionBinder.Bind<CanvasScreenEffectModel>().ToSingleton();
        injectionBinder.Bind<GameBallVfxPool>().ToSingleton();
        injectionBinder.Bind<BetweenLevelModel>().ToSingleton();
        injectionBinder.Bind<BallsShowLimitModel>().ToSingleton();
        injectionBinder.Bind<NextLevelModel>().ToSingleton();
    }

    // Commands and Bindings
    protected override void mapBindings()
    {
        base.mapBindings();

        //Scene Mediator
        mediationBinder.BindView<StartScreenView>().ToMediator<StartScreenMediator>();
        mediationBinder.BindView<PregameSceneStartView>().ToMediator<PregameStartMediator>();
        mediationBinder.BindView<GameSceneStartView>().ToMediator<GameSceneStartMediator>();
        mediationBinder.BindView<LevelSceneStartView>().ToMediator<LevelSceneStartMediator>();
        mediationBinder.BindView<LevelSceneLoadingView>().ToMediator<LevelSceneLoadingMediator>();

        // Other Mediator
        mediationBinder.BindView<CameraControlsView>().ToMediator<CameraControlsMediator>();
        mediationBinder.BindView<FindEnemySceneStartView>().ToMediator<FindEnemySceneStartMediator>();
        mediationBinder.BindView<GameFieldTopPanelView>().ToMediator<GameFieldTopPanelMediator>();


        //Bridge Mediator
        mediationBinder.BindView<MockTransportBridgeView>().ToMediator<MockTransportBridgeMediator>();
        mediationBinder.BindView<JavaScriptTransportBridgeView>().ToMediator<JavaScriptTransportBridgeMediator>();

        //UI Mediators
        mediationBinder.BindView<CanvasPregameView>().ToMediator<CanvasPregameMediator>();
        mediationBinder.BindView<PortrainPregameView>().ToMediator<PortrainPregameMediator>();
        mediationBinder.BindView<LandscapePregameView>().ToMediator<LandscapePregameMediator>();
        mediationBinder.BindView<CanvasInGameView>().ToMediator<CanvasInGameMediator>();
        mediationBinder.BindView<PlayerInGameView>().ToMediator<PlayerInGameMediator>();
        mediationBinder.BindView<PortrainInGameView>().ToMediator<PortrainInGameMediator>();
        mediationBinder.BindView<LandscapeInGameView>().ToMediator<LandscapeInGameMediator>();
        mediationBinder.BindView<YouWinScreenView>().ToMediator<YouWinScreenMediator>();
        mediationBinder.BindView<YouLossScreenView>().ToMediator<YouLossScreenMediator>();
        mediationBinder.BindView<TieScreenView>().ToMediator<TieScreenMediator>();
        mediationBinder.BindView<CanvasNativeView>().ToMediator<CanvasNativeMediator>();
        mediationBinder.BindView<CanvasDebugView>().ToMediator<CanvasDebugMediator>();
        mediationBinder.BindView<LevelPlayDebugView>().ToMediator<LevelPlayDebugMediator>();
        mediationBinder.BindView<CanvasScreenEffectView>().ToMediator<CanvasScreenEffectMediator>();
        mediationBinder.BindView<NextLevelLoadingView>().ToMediator<NextLevelLoadingMediator>();

        //FieldObject Mediator
        mediationBinder.BindView<FieldObjectView>().ToMediator<FieldObjectMediator>();
        mediationBinder.BindView<BallObjectView>().ToMediator<BallObjectMediator>();
        mediationBinder.BindView<BallSimpleView>().ToMediator<BallSimpleMediator>();
        mediationBinder.BindView<BallFlashView>().ToMediator<BallFlashMediator>();
        mediationBinder.BindView<BallFreezesView>().ToMediator<BallFreezesMediator>();
        mediationBinder.BindView<BallScoreView>().ToMediator<BallScoreMediator>();
        mediationBinder.BindView<BallWindView>().ToMediator<BallBombMediator>();
        mediationBinder.BindView<CustomAnimationView>().ToMediator<CustomAnimationMediator>();
        mediationBinder.BindView<CustomVfxView>().ToMediator<CustomVfxMediator>();
        mediationBinder.BindView<LightningVfxView>().ToMediator<LightningVfxMediator>();
        mediationBinder.BindView<WindVfxView>().ToMediator<WindVfxMediator>();
        mediationBinder.BindView<BubbleBurstVfxView>().ToMediator<BubbleBurstVfxMediator>();

        // FieldObjectComponnet Mediator
        mediationBinder.BindView<FieldObjectComponentView>().ToMediator<FieldObjectComponentMediator>();
        mediationBinder.BindView<FieldObjectMoveComponentView>().ToMediator<FieldObjectMoveComponentMediator>();
        mediationBinder.BindView<SingleClickShotComponentView>().ToMediator<SingleClickShotComponentMediator>();
        mediationBinder.BindView<FieldObjectContentComponentView>().ToMediator<FieldObjectContentComponentMediator>();

        // System Commands
        commandBinder.Bind(ContextEvent.START)
        .To<AppStartCommand>()
        .To<SetupCurrentPlatformCommand>()
        .To<UnityInstanceCommand>()
        .To<LoadGameSettingsCommand>()
        .To<DisableUnityLogCommand>()
        .To<InitializeNetworkExecutorCommand>()
        .To<InitializeSoundExecutorCommand>()
        .To<SetupCanvasNativeCommand>()
        .To<SetupScreenModelCommand>()
        .To<BridgeWaitLoadCommand>()
        .To<BridgeConnectCommand>()
        .To<BridgeSendVideoFrameCommand>()
        .To<BridgeSendReadyCommand>()
        .To<SetupCanvasDebugCommand>()
        .To<BridgeMockJsonOnStartCommand>()
        .To<GameStatusPrepareIsReadyCommand>()
        .To<NextPregameSceneCommand>()
        .Pooled()
        .InSequence()
        .Once();

        //Screen
        commandBinder.Bind(EventGlobal.E_ScreenSizeChanged).To<DispatchScreenSizeChangeCommand>().InSequence().Pooled();
        commandBinder.Bind(EventGlobal.E_YouWonEndGame).To<UIYouWonScreenShowCommand>().InSequence().Pooled();
        commandBinder.Bind(EventGlobal.E_YouLossEndGame).To<UIYouLossScreenShowCommand>().InSequence().Pooled();
        commandBinder.Bind(EventGlobal.E_TieEndGame).To<UITieScreenShowCommand>().InSequence().Pooled();

        //Scene
        commandBinder.Bind(EventGlobal.E_PregameSceneStart).To<GameStatusPreGameCommand>()
                                                           .To<PlayMusicCommand>()
                                                           .To<DispatchScreenSizeChangeNextFrameCommand>()
                                                           .InSequence().Pooled();


        commandBinder.Bind(EventGlobal.E_WaitEnemySceneStart).To<PregameSyncWithEnemyPlayerLoopCommand>()
                                                             .InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_IterSyncStartLevel).To<BridgeSendMainPlayerPlayCommand>()   // отправляем свои даные
                                                            .To<NeedSendPlayerHasEnemyDataCommand>() // уведомить противника, если получили его
                                                            .To<CheckStopSyncStartLevelCommand>()
                                                            .InSequence().Pooled();


        commandBinder.Bind(EventGlobal.E_StopPreGameSyncStartLevel).To<StopSyncStartLevelCommand>()
                                                                   .To<LoadSceneLoadingScreenCommand>()
                                                                   .InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_StopInGameSyncStartLevel).To<StopSyncStartLevelCommand>()
                                                                  .To<GameStatusPrepareIsReadyCommand>()
                                                                  .To<UINextLevelTimeShowCommand>()
                                                                  .InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_LoadDelayComplete).To<HideNativeButtonsCommand>()
                                                           .To<LoadCurrentLevelSceneCommand>().InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_LevelSceneStart).To<UnPauseMusicCommand>()
                                                         .To<SetupLevelSettingsCommand>()
                                                         .To<PlayerInGameUICommand>()
                                                         .To<GameStatusInGameCommand>()
                                                         .To<MainPlayerSetupGameFieldViewCommand>()
                                                         .To<LoadBallByBallSettingsIntoPoolCommand>()
                                                         //.To<LoadBallByLevelSettingsIntoPoolCommand>()
                                                         .To<PreCacheBallVfxCommand>()
                                                         .To<SetupSortingOrderCommand>()
                                                         .To<SetupBallNumberCommand>()
                                                         .To<SetupBallScaleCommand>()
                                                         .To<BallShowMaxLimitCommand>()
                                                         .To<ReturnAllBallsToPoolCommand>()
                                                         .To<SetupCanvasScreenEffectCommand>()
                                                         .To<DispatchScreenSizeChangeCommand>()
                                                         .To<DispatchLevelStartCommand>()
                                                         .To<StartTimeoutCommand>()
                                                        // .To<BridgeMockJsonEnemyScoreCommand>()
                                                         .To<BridgeMockEnemyShotHistoryCommand>()
                                                         .To<LifecircleSendShotHistoryCommand>()
                                                         .To<LifecircleBallPeriodsCommand>()
                                                         .InSequence().Pooled();


        //Bridge Receive
        commandBinder.Bind(EventGlobal.E_BridgeReceiveOnStartJson).To<BridgeReceivOnStartJsonCommand>().InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_BridgeReceiveOnStartContract).To<BridgeOnStartAddToPoolCommand>()
                                                                      .To<CheckPoolHasOnStartDataCommand>()
                                                                      .To<BridgeExecuteOnStartCommand>()
                                                                      .To<SetNativeButtonPositionByAdsCommand>()
                                                                      .To<CreateMainPlayerCommand>()
                                                                      .To<CreateEnemyPlayerCommand>()
                                                                      .To<NextPregameSceneCommand>()
                                                                      .InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_BridgeReceiveGameEventJson).To<BridgeReceivGameEventJsonCommand>().InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_BridgeReceivPlayerHasEnemyDataContract).To<BridgePlayerHasEnemyDataAddToPoolCommand>().InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_BridgeReceivStartPlayContract).To<BridgeStartPlayAddToPoolCommand>().InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_BridgeReceivShotContract).To<BridgeShotDataAddToPoolCommand>()
                                                                  .To<CheckPoolShotDataCommand>()
                                                                  .To<BridgeExecuteShotDataCommand>().InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_BridgeReceivEndGameContract).To<BridgeEndGameDataAddToPoolCommand>()
                                                                     .To<CheckPoolEndGameDataCommand>()
                                                                     .To<BridgeExecuteEndGameDataCommand>()
                                                                     .To<CalculateEndGameCommand>().InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_PreEndGame).To<UpdateTotalScoreCommand>()
                                                    .InSequence().Pooled();


        commandBinder.Bind(EventGlobal.E_EndGame).To<ShowNativeButtonsCommand>()
                                                 .To<DisableTimeoutCommand>()
                                                 .To<CalculateNextLevelCommand>().InSequence().Pooled();


        commandBinder.Bind(EventGlobal.E_NextLevel).To<NextLevelPauseCommand>()
                                                   .To<UpdateStartForNextLevelCommand>()
                                                   .To<ClearModelForNextLevelCommand>()
                                                   .To<CreateMainPlayerCommand>()
                                                   .To<CreateEnemyPlayerCommand>()
                                                   .To<BridgeMockEnemyIngameSyncCommand>()
                                                   .To<IngameSyncWithEnemyPlayerLoopCommand>()
                                                   .InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_NextLevelTimerComplete).To<HideNativeButtonsCommand>()
                                                                .To<LoadCurrentLevelSceneCommand>()
                                                                .To<DispatchScreenSizeChangeNextFrameCommand>().InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_BridgeReceivShotHistoryContract).To<BridgeShotHistoryDataAddToPoolCommand>()
                                                                         .To<CheckPoolShotHistoryDataCommand>()
                                                                         .To<BridgeExecuteShotHistoryDataCommand>().InSequence().Pooled();

        //Bridge Executor
        commandBinder.Bind(EventGlobal.E_PlayClick).To<LoadWaitEnemySceneCommand>()
                                                   .InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_BridgeAgainCommand).To<BridgeSendAgainCommand>().InSequence().Pooled();
        commandBinder.Bind(EventGlobal.E_BridgeHomeCommand).To<BridgeSendHomeCommand>().InSequence().Pooled();

        #region Shot Main Player 

        commandBinder.Bind(EventGlobal.E_MainPlayerRootShot).To<BallLockClickCommand>()
                                                            .To<AddMainPlayerIfNeedCommand>()
                                                            .To<BallLifeTimeCommand>()
                                                            .To<AddShotTimeCommand>()
                                                            .To<AddTreeShotHistoryForPlayerCommand>()
                                                            .To<MainPlayerBallTranslatorCommand>()
                                                            .InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_MainPlayerShot).To<BallLockClickCommand>()
                                                        .To<AddMainPlayerIfNeedCommand>()
                                                        .To<BallLifeTimeCommand>()
                                                        .To<AddShotTimeCommand>()
                                                        .To<MainPlayerBallTranslatorCommand>()
                                                        .InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_MainPlayerShotBallSimple).To<AddShotToHistoryCommand>()
                                                                  .To<MainPlayerAddScoreCommand>()
                                                                  .To<MainPlayerUpdateBallPanelCommand>()
                                                                  .To<BubbleBurstVfxCommand>()
                                                                  .To<BallFadeAnimationCommand>()
                                                                  .To<ClearBallRuntimeEffectCommand>()
                                                                  .To<ReturnObjectToPoolCommand>()
                                                                  .To<LoadObjectFromPoolByTypeCommand>().InSequence().Pooled();


        commandBinder.Bind(EventGlobal.E_MainPlayerShotBallFlash).To<AddShotToHistoryCommand>()
                                                                 .To<MainPlayerAddScoreCommand>()
                                                                 .To<BallFlashMechanicMainPlayerCommand>()
                                                                 .To<BubbleBurstVfxCommand>()
                                                                 .To<BallFadeAnimationCommand>()
                                                                 .To<MainPlayerUpdateBallPanelCommand>()
                                                                 .To<ReturnObjectToPoolCommand>()
                                                                 .To<LoadObjectFromPoolByTypeCommand>().InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_MainPlayerShotBallFreezes).To<AddShotToHistoryCommand>()
                                                                   .To<MainPlayerAddScoreCommand>()
                                                                   .To<BallFreezesMechanicCommand>()
                                                                   .To<MainPlayerUpdateBallPanelCommand>()
                                                                   .To<BubbleBurstVfxCommand>()
                                                                   .To<BallFadeAnimationCommand>()
                                                                   .To<ClearBallRuntimeEffectCommand>()
                                                                   .To<ReturnObjectToPoolCommand>()
                                                                   .To<LoadObjectFromPoolByTypeCommand>().InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_MainPlayerShotBallWind).To<AddShotToHistoryCommand>()
                                                                .To<MainPlayerAddScoreCommand>()
                                                                .To<MainPlayerUpdateBallPanelCommand>()
                                                                .To<BubbleBurstVfxCommand>()
                                                                .To<BallWindMechanicCommand>()
                                                                .To<ClearBallRuntimeEffectCommand>()
                                                                .To<ReturnObjectToPoolCommand>()
                                                                .To<LoadObjectFromPoolByTypeCommand>().InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_MainPlayerShotBallScore).To<AddShotToHistoryCommand>()
                                                                 .To<MainPlayerAddScoreCommand>()
                                                                 .To<BallScoreMechanicCommand>()
                                                                 .To<EnableBallScoreXMechanicCommand>()
                                                                 .To<MainPlayerUpdateBallPanelCommand>()
                                                                 .To<BubbleBurstVfxCommand>()
                                                                 .To<BallFadeAnimationCommand>()
                                                                 .To<ClearBallRuntimeEffectCommand>()
                                                                 .To<ReturnObjectToPoolCommand>()
                                                                 .To<LoadObjectFromPoolByTypeCommand>().InSequence().Pooled();
        #endregion

        #region Shot Enemy Player 
        commandBinder.Bind(EventGlobal.E_EnemyPlayerShot).To<BallLockClickCommand>()
                                                         .To<AddEnemyPlayerIfNeedCommand>()
                                                         .To<EnemyPlayerBallTranslatorCommand>()
                                                         .InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_EnemyPlayerShotBallSimple).To<BubbleBurstVfxCommand>()
                                                                   .To<BallFadeAnimationCommand>()
                                                                   .To<ClearBallRuntimeEffectCommand>()
                                                                   .To<ReturnObjectToPoolCommand>()
                                                                   .To<LoadObjectFromPoolByTypeCommand>().InSequence().Pooled();


        commandBinder.Bind(EventGlobal.E_EnemyPlayerShotBallFlash).To<BubbleBurstVfxCommand>()
                                                                  .To<BallFlashMechanicEnemyPlayerCommand>()
                                                                  .To<BallFadeAnimationCommand>()
                                                                  .To<ReturnObjectToPoolCommand>()
                                                                  .To<LoadObjectFromPoolByTypeCommand>().InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_EnemyPlayerShotBallFreezes).To<BallFreezesMechanicCommand>()
                                                                    .To<BubbleBurstVfxCommand>()
                                                                    .To<BallFadeAnimationCommand>()
                                                                    .To<ClearBallRuntimeEffectCommand>()
                                                                    .To<ReturnObjectToPoolCommand>()
                                                                    .To<LoadObjectFromPoolByTypeCommand>().InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_EnemyPlayerShotBallWind).To<BubbleBurstVfxCommand>()
                                                                 .To<BallWindMechanicCommand>()
                                                                 .To<ClearBallRuntimeEffectCommand>()
                                                                 .To<ReturnObjectToPoolCommand>()
                                                                 .To<LoadObjectFromPoolByTypeCommand>().InSequence().Pooled();

        commandBinder.Bind(EventGlobal.E_EnemyPlayerShotBallScore).To<BubbleBurstVfxCommand>()
                                                                  .To<BallFadeAnimationCommand>()
                                                                  .To<ClearBallRuntimeEffectCommand>()
                                                                  .To<ReturnObjectToPoolCommand>()
                                                                  .To<LoadObjectFromPoolByTypeCommand>().InSequence().Pooled();

        #endregion


        commandBinder.Bind(EventGlobal.E_SyncShotHistory).To<SetupSendShotHistoryCommand>()
                                                         .To<BridgeSendShotHistoryDataCommand>()
                                                         .To<ClearAfterSendShotHistoryCommand>().InSequence().Pooled();

        //End game
        commandBinder.Bind(EventGlobal.E_TimeoutEnd).To<GameStatusGameEndCommand>()
                                                    .To<MainPlayerSetupEndGameCommand>()
                                                    .To<LockBallShotCommand>()
                                                    .To<LockBallMoveCommand>()
                                                    .To<BridgeSendEndGameDataCommand>()
                                                    .To<BridgeMockJsonEndGameCommand>()
                                                    .To<CalculateEndGameCommand>().InSequence().Pooled();

        //Vfx
        commandBinder.Bind(EventGlobal.E_DisableScoreXEffect).To<DisableBallScoreXMechanicCommand>().InSequence().Pooled();
        commandBinder.Bind(EventGlobal.E_FadeAnimationShotBall).To<BallFadeAnimationCommand>().InSequence().Pooled();

        //Debug
        commandBinder.Bind(EventGlobal.E_DebugPlayLevel).To<DisableTimeoutCommand>()
                                                        .To<DebugPlayLevelCommand>()
                                                        .To<GameStatusPrepareIsReadyCommand>()
                                                        .To<NextPregameSceneCommand>()
                                                        .To<DispatchScreenSizeChangeNextFrameCommand>().InSequence().Pooled();
    }
}