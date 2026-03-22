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
            Debug.Log("Checking");
            if (garbageSpawner.spawnedGarbageList.Count > 0)
            {
                return true;
            }
            else return false;
        }
    }
}