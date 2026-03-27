using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class RetreatAT : ActionTask {

        public BBParameter<float> moveSpeed;
        public BBParameter<int> team;
        private Vector3 direction;
        protected override string OnInit()
        {
			Debug.Log("Initializing retreat script");
            direction = (team.value == 0) ? new Vector3(-1,0,0) : new Vector3(1, 0, 0);
            return null;
        }

        protected override void OnExecute() {

		}

		protected override void OnUpdate() {
			Debug.Log("MOVING");
			agent.transform.position += direction * moveSpeed.value * Time.deltaTime;
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}