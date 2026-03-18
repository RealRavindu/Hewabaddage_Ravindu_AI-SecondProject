using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class DetectedGarbageOnFloorCT : ConditionTask {

		public GarbageOnFloor floor;
		protected override string OnInit(){
			return null;
		}

		protected override void OnEnable() {
			
		}

		protected override void OnDisable() {
			
		}

		protected override bool OnCheck() {
			if (floor.Trash.Count > 1) return true;
			else return false;
		}
	}
}