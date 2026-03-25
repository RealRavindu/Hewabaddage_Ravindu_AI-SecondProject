using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class MoveInRangeAT : ActionTask {
		public BBParameter<Transform> targetTransform;
		private NavMeshAgent navAgent;
		public BBParameter<float> range;
		protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		protected override void OnExecute() {
			if (inRange())
			{
				Debug.Log("Already in range to fire lazer");
				EndAction(true);
			} else
			{
				Debug.Log("Setting destination to player");
				navAgent.SetDestination(targetTransform.value.position);
			}
		}

		protected override void OnUpdate() {
			if (inRange())
            {
                Debug.Log("Now in range to fire lazer");
                EndAction(true);
            }
        }

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}

		private bool inRange()
		{
            if ((agent.transform.position - targetTransform.value.position).magnitude < range.value)
            {
				return true;
            } else
			{
				return false;
			}
        }
	}
}