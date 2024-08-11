﻿using MHServerEmu.Games.Entities;
using MHServerEmu.Games.GameData.Prototypes;
using MHServerEmu.Games.Regions;

namespace MHServerEmu.Games.Missions.Conditions
{
    public class MissionConditionHotspotContains : MissionConditionContains
    {
        private MissionConditionHotspotContainsPrototype _proto;
        private Action<EntityEnteredMissionHotspotGameEvent> _entityEnteredMissionHotspotAction;
        private Action<EntityLeftMissionHotspotGameEvent> _entityLeftMissionHotspotAction;
        private Action<EntityDeadGameEvent> _entityDeadAction;

        public MissionConditionHotspotContains(Mission mission, IMissionConditionOwner owner, MissionConditionPrototype prototype) 
            : base(mission, owner, prototype)
        {
            _proto = prototype as MissionConditionHotspotContainsPrototype;
            _entityEnteredMissionHotspotAction = OnEntityEnteredMissionHotspot;
            _entityLeftMissionHotspotAction = OnEntityLeftMissionHotspot;
            _entityDeadAction = OnEntityDeadAction;
        }

        protected override long CountMin => _proto.CountMin;
        protected override long CountMax => _proto.CountMax;

        protected override bool Contains()
        {
            if (_proto.TargetFilter != null)
                foreach(var hotspot in Mission.GetMissionHotspots())
                    if (EvaluateEntityFilter(_proto.EntityFilter, hotspot))
                        return true;

            return false;
        }

        public override bool OnReset()
        {
            long count = 0;
            if (_proto.TargetFilter != null) 
            {
                var missionRef = Mission.PrototypeDataRef;
                foreach (var hotspot in Mission.GetMissionHotspots())
                    if (EvaluateEntityFilter(_proto.EntityFilter, hotspot))
                        count += hotspot.GetMissionConditionCount(missionRef, _proto);
            }

            SetCount(count);
            return true;
        }

        private bool EvaluateEntity(WorldEntity target, Hotspot hotspot)
        {
            if (target == null || hotspot == null) return false;
            if (EvaluateEntityFilter(_proto.EntityFilter, hotspot) == false) return false;
            if (target is Hotspot || target is Missile) return false;
            if (EvaluateEntityFilter(_proto.TargetFilter, target) == false) return false;

            return true;
        }

        private void OnEntityEnteredMissionHotspot(EntityEnteredMissionHotspotGameEvent evt)
        {
            if (EvaluateEntity(evt.Target, evt.Hotspot))
                Count++;
        }

        private void OnEntityLeftMissionHotspot(EntityLeftMissionHotspotGameEvent evt)
        {
            if (EvaluateEntity(evt.Target, evt.Hotspot))
                Count--;
        }

        private void OnEntityDeadAction(EntityDeadGameEvent evt)
        {
            var entity = evt.Defender;
            if (entity == null) return;

            foreach (var hotspot in Mission.GetMissionHotspots())
                if (EvaluateEntityFilter(_proto.EntityFilter, hotspot))
                {
                    if (hotspot.Physics.IsOverlappingEntity(entity.Id) && EvaluateEntity(entity, hotspot))
                        Count--;
                    return;
                }
        }

        public override void RegisterEvents(Region region)
        {
            EventsRegistered = true;
            region.EntityEnteredMissionHotspotEvent.AddActionBack(_entityEnteredMissionHotspotAction);
            region.EntityLeftMissionHotspotEvent.AddActionBack(_entityLeftMissionHotspotAction);
            region.EntityDeadEvent.AddActionBack(_entityDeadAction);
        }

        public override void UnRegisterEvents(Region region)
        {
            EventsRegistered = false;
            region.EntityEnteredMissionHotspotEvent.RemoveAction(_entityEnteredMissionHotspotAction);
            region.EntityLeftMissionHotspotEvent.RemoveAction(_entityLeftMissionHotspotAction);
            region.EntityDeadEvent.RemoveAction(_entityDeadAction);
        }
    }
}
