using MHServerEmu.Games.GameData;
using MHServerEmu.Games.GameData.Prototypes;
using MHServerEmu.Games.Regions;

namespace MHServerEmu.Games.Missions.Conditions
{
    public class MissionConditionRegionLeave : MissionPlayerCondition
    {
        private MissionConditionRegionLeavePrototype _proto;
        private Action<PlayerLeftRegionGameEvent> _playerLeftRegionAction;

        public MissionConditionRegionLeave(Mission mission, IMissionConditionOwner owner, MissionConditionPrototype prototype) 
            : base(mission, owner, prototype)
        {
            _proto = prototype as MissionConditionRegionLeavePrototype;
            _playerLeftRegionAction = OnPlayerLeftRegion;
        }

        public override bool OnReset()
        {
            bool leave = true;
            foreach (var player in Mission.GetParticipants())
            {
                var region = player.CurrentAvatar?.Region;
                if (region != null && region.FilterRegion(_proto.RegionPrototype, _proto.RegionIncludeChildren, null))
                {
                    leave = false;
                    break;
                }
            }

            SetCompletion(leave);
            return true;
        }

        private void OnPlayerLeftRegion(PlayerLeftRegionGameEvent evt)
        {
            var player = evt.Player;
            var regionRef = evt.RegionRef;
            if (player == null || IsMissionPlayer(player) == false) return;
            var regionProto = GameDatabase.GetPrototype<RegionPrototype>(regionRef);
            if (regionProto.FilterRegion(_proto.RegionPrototype, _proto.RegionIncludeChildren, null) == false) return;

            UpdatePlayerContribution(player);
            SetCompleted();
        }

        public override void RegisterEvents(Region region)
        {
            EventsRegistered = true;
            region.PlayerLeftRegionEvent.AddActionBack(_playerLeftRegionAction);
        }

        public override void UnRegisterEvents(Region region)
        {
            EventsRegistered = false;
            region.PlayerLeftRegionEvent.RemoveAction(_playerLeftRegionAction);
        }
    }
}
