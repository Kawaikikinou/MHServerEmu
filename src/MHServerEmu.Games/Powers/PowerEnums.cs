﻿using MHServerEmu.Games.GameData.Calligraphy.Attributes;

namespace MHServerEmu.Games.Powers
{
    [Flags]
    public enum PowerActivationSettingsFlags
    {
        None    = 0,
        Flag0   = 1 << 0,
        Flag1   = 1 << 1,
        Flag2   = 1 << 2,
        Flag3   = 1 << 3,
        Flag4   = 1 << 4,
        Flag5   = 1 << 5,
        Flag6   = 1 << 6,
        Flag7   = 1 << 7,
    }

    [Flags]
    public enum EndPowerFlags
    {
        None                = 0,
        ExplicitCancel      = 1 << 0,
        Flag1               = 1 << 1,
        Flag2               = 1 << 2,
        Interrupting        = 1 << 3,
        Flag4               = 1 << 4,
        Flag5               = 1 << 5,
        Flag6               = 1 << 6,
        Flag7               = 1 << 7,
        Force               = 1 << 8,
        PowerEventAction    = 1 << 9
    }

    [Flags]
    public enum PowerResultFlags    // PowerResults::getStringForFlag()
    {
        None            = 0,
        Hostile         = 1 << 0,
        Proc            = 1 << 1,
        OverTime        = 1 << 2,
        Critical        = 1 << 3,
        Dodged          = 1 << 4,
        Resisted        = 1 << 5,
        Blocked         = 1 << 6,
        SuperCritical   = 1 << 7,   // Brutal Strike
        Unaffected      = 1 << 8,
        Teleport        = 1 << 9,
        NoDamage        = 1 << 10,
        Resurrect       = 1 << 11,
        InstantKill     = 1 << 12
    }

    public enum PowerActivationPhase
    {
        Inactive,
        Active,
        Charging,
        ChannelStarting,
        Channeling,
        MinTimeEnding,
        LoopEnding
    }

    public enum PowerPositionSweepResult
    {
        Error,
        Success,
        TargetPositionInvalid,
        Clipped,
    };

    public enum RangeCheckType
    {
        Activation,
        Application
    }

    public enum PowerUseResult
    {
        Success = 0,
        Cooldown = 1,
        RestrictiveCondition = 2,
        BadTarget = 3,
        AbilityMissing = 4,
        TargetIsMissing = 5,
        InsufficientCharges = 6,
        InsufficientEndurance = 7,
        InsufficientSecondaryResource = 8,
        PowerInProgress = 9,
        OutOfPosition = 10,
        SummonSimultaneousLimit = 11,
        SummonLifetimeLimit = 12,
        WeaponMissing = 13,
        RegionRestricted = 14,
        NoFlyingUse = 15,
        ExtraActivationFailed = 16,
        GenericError = 17,
        OwnerNotSimulated = 18,
        OwnerDead = 19,
        ItemUseRestricted = 20,
        MinimumReactivateTime = 21,
        DisabledByLiveTuning = 22,
        NotAllowedByTransformMode = 23,
        FullscreenMovie = 24,
        ForceFailed = 25,
    }

    [AssetEnum((int)Physical)]
    public enum DamageType
    {
        Physical = 0,
        Energy = 1,
        Mental = 2,
        Any = 4,
    }

    [AssetEnum((int)MoveIntoRange)]
    public enum WhenOutOfRangeType
    {
        MoveIntoRange = 0,
        DoNothing = 1,
        ActivateInDirection = 2,
        MoveIfTargetingMOB = 3,
        ActivateComboMovementPower = 4,
    }

    [AssetEnum((int)None)]
    public enum PowerActivationType
    {
        None = 0,
        Passive = 1,
        Instant = 2,
        InstantTargeted = 3,
        TwoStageTargeted = 4,
    }

    [AssetEnum((int)None)]
    public enum PowerCategoryType
    {
        None = 0,
        ComboEffect = 1,
        EmotePower = 2,
        GameFunctionPower = 3,
        HiddenPassivePower = 4,
        HotspotEffect = 5,
        ItemPower = 6,
        MissileEffect = 7,
        NormalPower = 8,
        ProcEffect = 9,
        ThrowableCancelPower = 10,
        ThrowablePower = 11,
    }

    [AssetEnum((int)AllowProcChanceMultiplier)]
    public enum ProcChanceMultiplierBehaviorType
    {
        AllowProcChanceMultiplier = 0,
        IgnoreProcChanceMultiplier = 1,
        IgnoreProcChanceMultiplierUnlessZero = 2,
    }

    [AssetEnum((int)None)]
    public enum TeleportMethodType
    {
        None = 0,
        Teleport = 1,
        Phase = 2,
    }

    [AssetEnum((int)None)]
    public enum PowerEventType
    {
        None = 0,
        OnContactTime = 1,
        OnCriticalHit = 2,
        OnHitKeyword = 3,
        OnPowerApply = 4,
        OnPowerStopped = 24,
        OnPowerEnd = 5,
        OnPowerLoopEnd = 26,
        OnPowerHit = 6,
        OnPowerStart = 7,
        OnPowerToggleOn = 22,
        OnPowerToggleOff = 23,
        OnProjectileHit = 8,
        OnStackCount = 9,
        OnTargetKill = 10,
        OnSummonEntity = 11,
        OnHoldBegin = 12,
        OnMissileHit = 13,
        OnMissileKilled = 14,
        OnHotspotNegated = 15,
        OnHotspotNegatedByOther = 16,
        OnHotspotOverlapBegin = 17,
        OnHotspotOverlapEnd = 18,
        OnRemoveCondition = 19,
        OnRemoveNegStatusEffect = 20,
        OnExtraActivationCooldown = 25,
        OnPowerPivot = 21,
        OnSpecializationPowerAssigned = 27,
        OnSpecializationPowerUnassigned = 28,
        OnEntityControlled = 29,
        OnOutOfRangeActivateMovementPower = 30,
    }

    [AssetEnum((int)None)]
    public enum PowerEventActionType
    {
        None = 0,
        BodySlide = 1,
        CancelScheduledActivation = 2,
        CancelScheduledActivationOnTriggeredPower = 3,
        ContextCallback = 4,
        ControlAgentAI = 21,
        CooldownEnd = 25,
        CooldownModifySecs = 26,
        CooldownModifyPct = 27,
        CooldownStart = 24,
        DespawnTarget = 5,
        EndPower = 23,
        ChargesIncrement = 6,
        InteractFinish = 7,
        RemoveAndKillControlledAgentsFromInv = 22,
        RestoreThrowable = 9,
        ScheduleActivationAtPercent = 10,
        ScheduleActivationInSeconds = 11,
        RescheduleActivationInSeconds = 8,
        ShowBannerMessage = 12,
        SpawnLootTable = 13,
        SwitchAvatar = 14,
        ToggleOnPower = 15,
        ToggleOffPower = 16,
        TeamUpAgentSummon = 28,
        TeleportToPartyMember = 20,
        TransformModeChange = 17,
        TransformModeStart = 18,
        UsePower = 19,
        TeleportToRegion = 29,
        StealPower = 30,
        PetItemDonate = 31,
        MapPowers = 32,
        UnassignMappedPowers = 33,
        RemoveSummonedAgentsWithKeywords = 34,
        SpawnControlledAgentWithSummonDuration = 35,
        LocalCoopEnd = 36,
    }

    [AssetEnum((int)None)]
    public enum TargetingShapeType
    {
        None = 0,
        ArcArea = 1,
        BeamSweep = 2,
        CapsuleArea = 3,
        CircleArea = 4,
        RingArea = 5,
        Self = 6,
        TeamUp = 7,
        SingleTarget = 8,
        SingleTargetOwner = 9,
        SingleTargetRandom = 10,
        SkillShot = 11,
        SkillShotAlongGround = 12,
        WedgeArea = 13,
    }

    [AssetEnum((int)_0)]
    public enum AOEAngleType
    {
        _0 = 0,
        _1 = 1,
        _10 = 2,
        _30 = 3,
        _45 = 4,
        _60 = 5,
        _90 = 6,
        _120 = 7,
        _180 = 8,
        _240 = 9,
        _300 = 10,
        _360 = 11,
        // Not found in client
        _20 = 0
    }

    [AssetEnum((int)Alive)]
    public enum EntityHealthState
    {
        Alive = 0,
        Dead = 1,
        AliveOrDead = 2,
    }

    [AssetEnum((int)All)]
    public enum TargetingHeightType
    {
        All = 0,
        GroundOnly = 1,
        SameHeight = 2,
        FlyingOnly = 3,
    }

    [AssetEnum((int)None)]
    public enum SubsequentActivateType
    {
        None = 0,
        DestroySummonedEntity = 1,
        RepeatActivation = 2,
    }

    [AssetEnum((int)None)]
    public enum TargetRestrictionType
    {
        None = 0,
        HealthGreaterThanPercentage = 1,
        HealthLessThanPercentage = 2,
        EnduranceGreaterThanPercentage = 3,
        EnduranceLessThanPercentage = 4,
        HealthOrEnduranceGreaterThanPercentage = 5,
        HealthOrEnduranceLessThanPercentage = 6,
        SecondaryResourceLessThanPercentage = 7,
        HasKeyword = 8,
        DoesNotHaveKeyword = 9,
        HasAI = 10,
        IsPrototypeOf = 11,
        HasProperty = 12,
        DoesNotHaveProperty = 13,
    }
}
