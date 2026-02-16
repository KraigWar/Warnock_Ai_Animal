using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class EatingFoodAT : ActionTask {

		public GameObject fruitPrefab;
		private float destroyTimer;
		private GameObject spawnedFruit;

		public BBParameter<float> fruitEaten;

		public BBParameter<bool> hasEaten; 
		protected override string OnInit() {
			return null;
		}

		
		protected override void OnExecute() {

            fruitEaten.value++;

			destroyTimer = 0;
			hasEaten.value = false;
			spawnedFruit = GameObject.Instantiate(fruitPrefab);
			spawnedFruit.transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y +2, agent.transform.position.z);

            
		}


		protected override void OnUpdate()
		{
			destroyTimer += Time.deltaTime;
			if (destroyTimer > 5)
			{
				GameObject.Destroy(spawnedFruit);
                hasEaten.value = true;
                
            }
		}
	}
}