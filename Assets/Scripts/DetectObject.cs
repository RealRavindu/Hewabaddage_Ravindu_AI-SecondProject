using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{

    public class DetectObject : ConditionTask
    {

        public LayerMask layerToDetect;
        public float detectionRadius;
        protected override string OnInit()
        {
            return null;
        }

        //Called whenever the condition gets enabled.
        protected override void OnEnable()
        {

        }

        //Called whenever the condition gets disabled.
        protected override void OnDisable()
        {

        }

        //Called once per frame while the condition is active.
        //Return whether the condition is success or failure.
        protected override bool OnCheck()
        {
            Collider[] detections = Physics.OverlapSphere(agent.transform.position, detectionRadius, layerToDetect);
            if (detections.Length > 0)
            {
                Debug.Log("Detected patroller");
                return true;
            }
            else
            {
                Debug.Log("Didnt detect patroller");
                return false;
            }
        }
    }
}