using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{

    public class DetectedGarbageOnFloorCT : ConditionTask
    {
        public GarbageSpawner garbageSpawner;
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
            if (garbageSpawner.spawnedGarbageList.Count > 0)
            {
                Vector3 position = garbageSpawner.spawnedGarbageList[0].position;
                position.y = 0;
                blackboard.SetVariableValue("trashPosition", position);
                return true;
            }
            else return false;
        }
    }
}