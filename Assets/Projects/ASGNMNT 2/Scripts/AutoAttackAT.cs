using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class AutoAttackAT : ActionTask
    {
        public BBParameter<GameObject> target;
        public BBParameter<Transform> AATransform;
        private Vector3 startPos;
        public float timeToReachTarget;
        private float time;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            startPos = AATransform.value.position;
            time = 0;
        }

        protected override void OnUpdate()
        {
            time += Time.deltaTime / timeToReachTarget;
            AATransform.value.position = Vector3.Lerp(startPos, target.value.transform.position, time);
            if (time > 1)
            {
                GameObject.Destroy(AATransform.value.gameObject);
                EndAction(true);
            }
        }


        protected override void OnStop()
        {

        }

        protected override void OnPause()
        {

        }
    }
}