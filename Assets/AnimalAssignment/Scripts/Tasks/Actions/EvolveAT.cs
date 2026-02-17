using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class EvolveAT : ActionTask {

		//boolean to check if hes done evolving
		public BBParameter<bool> finishedEvo;
		//the timer set for the entire audio to play
		private float timeForEvolve;

		protected override string OnInit() {
			return null;
		}


		protected override void OnExecute() {
			//increase the size of the animal
			agent.transform.localScale = agent.transform.localScale + new Vector3(2, 2, 2) / 4;

			
		}


		protected override void OnUpdate()
		{
			//increase the time so the entire plays and when its dine (3 seconds), set the boolean to know its done evolving for state transitions
			timeForEvolve += Time.deltaTime;
			if (timeForEvolve > 3f)
			{
				finishedEvo.value = true;
            }
		}
	}
}