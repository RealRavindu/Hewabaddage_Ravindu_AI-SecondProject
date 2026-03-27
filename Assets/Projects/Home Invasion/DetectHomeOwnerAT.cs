using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

    public class DetectHomeOwnerAT : ActionTask
    {

        public BBParameter<Transform> homeOwnerTransform;
        public int homeOwnerLayer;
        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            RaycastHit hit;
            Vector3 direction = (homeOwnerTransform.value.position - agent.transform.position).normalized;
            Physics.Raycast(agent.transform.position, direction, out hit);

            Debug.Log(hit.collider.name);
            if (hit.collider.gameObject.layer == homeOwnerLayer)
            {
                EndAction(true);
                Debug.Log("PLAYER IS SEEING ME!!!!");
            }
            else
            {
                EndAction(false);
                Debug.Log("IM HIDDEN!!!!");
            }
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {

        }

        //Called when the task is disabled.
        protected override void OnStop()
        {

        }

        //Called when the task is paused.
        protected override void OnPause()
        {

        }
    }
}