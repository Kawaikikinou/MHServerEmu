using MHServerEmu.Games.GameData.Prototypes;

namespace MHServerEmu.Games.Missions.Conditions
{
    public class MissionConditionItemCollect : MissionPlayerCondition
    {
        private MissionConditionItemCollectPrototype _proto;
        protected override long RequiredCount => _proto.Count;

        public MissionConditionItemCollect(Mission mission, IMissionConditionOwner owner, MissionConditionPrototype prototype) 
            : base(mission, owner, prototype)
        {
            _proto = prototype as MissionConditionItemCollectPrototype;
        }
    }
}
