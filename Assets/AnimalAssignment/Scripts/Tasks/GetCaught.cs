using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class GetCaught : ActionTask {

        public GameObject pokeball;
        private GameObject spawnedBall;

        private float destroyTimer;

        protected override string OnInit() {
			return null;
		}

		
		protected override void OnExecute() {

			

            spawnedBall = GameObject.Instantiate(pokeball);
            spawnedBall.transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y + 1, agent.transform.position.z);
			agent.transform.localScale = new Vector3(0,0,0);
            
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			destroyTimer += Time.deltaTime;
			if(destroyTimer > 4)
			{
				GameObject.Destroy(agent.gameObject);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}