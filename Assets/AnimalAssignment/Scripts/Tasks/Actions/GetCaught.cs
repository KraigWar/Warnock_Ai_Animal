using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class GetCaught : ActionTask {

		//setting up the prefab and the variable to store it in
        public GameObject pokeball;
        private GameObject spawnedBall;

		//timing for the ending of the animal
        private float destroyTimer;

        protected override string OnInit() {
			return null;
		}

		
		protected override void OnExecute() {

			
			//at the begining, spawn the poke ball where the animal was and make it float in the air to be clearly visible
			//also make the animal extremely small to make sure the audio plays entirely
            spawnedBall = GameObject.Instantiate(pokeball);
            spawnedBall.transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y + 1, agent.transform.position.z);
			agent.transform.localScale = new Vector3(0,0,0);
            
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//increase the timer untill the animal is destroyed so the audio player can keep going, THEN destroy it cause its caught
			destroyTimer += Time.deltaTime;
			if(destroyTimer > 4)
			{
				GameObject.Destroy(agent.gameObject);
			}
		}
	}
}