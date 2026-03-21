using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions
{

    public class DetectedGarbageOnFloorCT : ConditionTask
    {

        public GarbageOnFloor floor;
        private Blackboard blackboard;
        protected override string OnInit()
        {
            blackboard = agent.GetComponent<Blackboard>();
            return null;
        }

        protected override void OnEnable()
        {

        }

        protected override void OnDisable()
        {

        }

        protected override bool OnCheck()
        {
            if (floor.Trash.Count > 1)
            {
                blackboard.SetVariableValue("trash", floor.Trash[0]);
                return true;
            }
            else return false;
        }
    }
}