using MHServerEmu.Games.GameData.Prototypes;

namespace MHServerEmu.Games.Missions.Conditions
{
    public class MissionConditionMetaGameComplete : MissionPlayerCondition
    {
        protected MissionConditionMetaGameCompletePrototype Proto => Prototype as MissionConditionMetaGameCompletePrototype;
        protected override long MaxCount => Proto.Count;

        public MissionConditionMetaGameComplete(Mission mission, IMissionConditionOwner owner, MissionConditionPrototype prototype) 
            : base(mission, owner, prototype)
        {
        }
    }
}
