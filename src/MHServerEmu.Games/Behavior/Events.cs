using MHServerEmu.Games.Entities;
using MHServerEmu.Games.Events;

namespace MHServerEmu.Games.Behavior
{
    public class AIThinkEvent : ScheduledEvent
    {
        public AIController OwnerController;

        public override void OnTriggered()
        {
            OwnerController?.Think();
        }
    }

    public class EntityDeadGameEvent
    {
        public WorldEntity Defender;
    }

    public class AIBroadcastBlackboardGameEvent
    {
        public WorldEntity Broadcaster;
        public BehaviorBlackboard Blackboard;

        public AIBroadcastBlackboardGameEvent(WorldEntity broadcaster, BehaviorBlackboard blackboard)
        {
            Broadcaster = broadcaster;
            Blackboard = blackboard;
        }
    }
}