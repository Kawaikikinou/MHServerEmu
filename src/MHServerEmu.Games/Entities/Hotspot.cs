﻿using MHServerEmu.Games.Dialog;
using MHServerEmu.Games.GameData;
using MHServerEmu.Games.GameData.Prototypes;
using MHServerEmu.Games.Properties;
using MHServerEmu.Games.Common;
using MHServerEmu.Core.VectorMath;

namespace MHServerEmu.Games.Entities
{
    public class Hotspot : WorldEntity
    {
        public bool IsMissionHotspot { get; private set; }
        public HotspotPrototype HotspotPrototype { get => Prototype as HotspotPrototype; }

        private Dictionary<MissionConditionContext, int> ConditionEntityCounter;
        private bool _skipCollide;

        // new
        public Hotspot(Game game) : base(game) { }

        public override bool Initialize(EntitySettings settings)
        {
            base.Initialize(settings);

            _flags |= EntityFlags.IsHotspot;
            if (Prototype.Properties[PropertyEnum.MissionHotspot]) IsMissionHotspot = true;
            _skipCollide = settings.HotspotSkipCollide;

            return true;
        }

        public override bool CanCollideWith(WorldEntity other)
        {
            if (_skipCollide) return false;
            return base.CanCollideWith(other);
        }

        public override void OnEnteredWorld(EntitySettings settings)
        {
            base.OnEnteredWorld(settings);
            var hotspotProto = HotspotPrototype;
            if (hotspotProto.ApplyEffectsDelayMS > 0)
            {
                // TODO ScheduleEntityEvent
            }

            if (hotspotProto.DirectApplyToMissilesData != null)
            {
                // TODO _directApplyToMissileProperties
            }

            if (hotspotProto.UINotificationOnEnter != null)
            {
                // TODO UINotification
            }

            if (IsMissionHotspot)
            {
                ConditionEntityCounter = new();
                MissionEntityTracker();
            }
        }

        public override void OnOverlapBegin(WorldEntity whom, Vector3 whoPos, Vector3 whomPos)
        {
            // TODO trigger
        }

        public override void OnOverlapEnd(WorldEntity whom)
        {
            // TODO trigger
        }

        private void MissionEntityTracker()
        {
            EntityTrackingContextMap involvementMap = new();
            if (GameDatabase.InteractionManager.GetEntityContextInvolvement(this, involvementMap) == false) return;
            foreach (var involment in involvementMap)
            {
                if (involment.Value.HasFlag(EntityTrackingFlag.Hotspot) == false) continue;
                var missionRef = involment.Key;
                var missionProto = GameDatabase.GetPrototype<MissionPrototype>(involment.Key);
                if (missionProto == null) continue;
                var conditionList = missionProto.HotspotConditionList;
                if (conditionList == null) continue;
                foreach(var conditionProto in conditionList)
                    if (EvaluateCondition(missionRef, conditionProto))
                    {
                        var key = new MissionConditionContext(missionRef, conditionProto);
                        ConditionEntityCounter[key] = 0;
                    }
            }

        }

        private bool EvaluateCondition(PrototypeId missionRef, MissionConditionPrototype conditionProto)
        {
            if (conditionProto == null) return false;

            if (conditionProto is MissionConditionHotspotContainsPrototype hotspotContainsProto)
                return hotspotContainsProto.TargetFilter != null && hotspotContainsProto.EntityFilter != null && hotspotContainsProto.EntityFilter.Evaluate(this, new(missionRef));
            if (conditionProto is MissionConditionHotspotEnterPrototype hotspotEnterProto)
                return hotspotEnterProto.TargetFilter != null && hotspotEnterProto.EntityFilter != null && hotspotEnterProto.EntityFilter.Evaluate(this, new(missionRef));
            if (conditionProto is MissionConditionHotspotLeavePrototype hotspotLeaveProto)
                return hotspotLeaveProto.TargetFilter != null && hotspotLeaveProto.EntityFilter != null && hotspotLeaveProto.EntityFilter.Evaluate(this, new(missionRef));
            return false;
        }
    }

    public class MissionConditionContext
    {
        public PrototypeId MissionRef;
        public MissionConditionPrototype ConditionProto;

        public MissionConditionContext(PrototypeId missionRef, MissionConditionPrototype conditionProto)
        {
            MissionRef = missionRef;
            ConditionProto = conditionProto;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var other = (MissionConditionContext)obj;
            return MissionRef.Equals(other.MissionRef) && ConditionProto.Equals(other.ConditionProto);
        }

        public override int GetHashCode()
        {
            return MissionRef.GetHashCode() ^ ConditionProto.GetHashCode();
        }
    }
}
