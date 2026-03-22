using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PickUpAT : ActionTask {

		public float grabDistance, holdDistance;
		public GarbageSpawner garbageSpawner;
		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
            if (garbageSpawner.spawnedGarbageList.Count < 1 || garbageSpawner.spawnedGarbageList[0] == null) EndAction(false);
			Transform garbage = garbageSpawner.spawnedGarbageList[0];
			float distanceToGarbage = (garbage.position - agent.transform.position).magnitude;

			if (distanceToGarbage > grabDistance) EndAction(false);
			else
			{
				garbage.position = agent.transform.position + agent.transform.forward * holdDistance;
                garbage.parent = agent.transform;
				garbageSpawner.spawnedGarbageList.Remove(garbage);
				EndAction(true);
            }
		}

		protected override void OnUpdate() {
			
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}