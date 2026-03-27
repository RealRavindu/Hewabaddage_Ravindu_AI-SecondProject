using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections;

namespace NodeCanvas.Tasks.Actions {

	public class chargeAAAT : ActionTask {

        public BBParameter<GameObject> target;
        public BBParameter<Transform> autoTransform;
        public GameObject autoAttackPrefab;
        private GameObject spawnedAA;
        public Vector3 offset;
        public float growthRate, maxSize;
        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            agent.transform.LookAt(target.value.transform);
            spawnedAA = GameObject.Instantiate(autoAttackPrefab);
            spawnedAA.transform.position = agent.transform.position + offset;
            spawnedAA.transform.localScale = Vector3.zero;
            autoTransform.value = spawnedAA.transform;
        }

        protected override void OnUpdate()
        {
            spawnedAA.transform.localScale += Vector3.one * growthRate * Time.deltaTime;
            if (spawnedAA.transform.localScale.x > maxSize) EndAction(true);
        }

        protected override void OnStop()
        {

        }

        protected override void OnPause()
        {

        }
    }
}