using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class MoveToAT : ActionTask
    {

        public Transform moveToPosition;
        public float speed, detectionRadius;
        public LayerMask interruptionLayer;
        private float t;

        private Vector3 startPos;
        protected override string OnInit()
        {
            
            return null;
        }

        protected override void OnExecute()
        {
            startPos = agent.transform.position;
            t = 0;
        }

        protected override void OnUpdate()
        {

            //checking for collisions with any object in enemy layer
            Collider[] detections = Physics.OverlapSphere(agent.transform.position, detectionRadius, interruptionLayer);
            //end the patrol script if reached destination or detected an interruption
            if (agent.transform.position == moveToPosition.position)
            {
                Debug.Log("Reached destination");
                EndAction(true);
            }
            if (detections.Length > 0)
            {
                Debug.Log("Detected a dude in the way");
                EndAction(false);
                return;
            }
            //lerp the objects transform from it's starting point to selected point
            t += Time.deltaTime * (1 / speed);
            agent.transform.position = Vector3.Lerp(startPos, moveToPosition.position, t);


            
        }

        protected override void OnStop()
        {

        }

        protected override void OnPause()
        {

        }
    }
}