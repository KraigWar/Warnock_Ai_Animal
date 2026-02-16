using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PlaySound : ActionTask
	{

		private AudioSource m_Source;
		public AudioClip m_Clip;
		protected override string OnInit()
		{
			m_Source = agent.GetComponent<AudioSource>();

			return null;
		}

		protected override void OnExecute()
		{

			m_Source.clip = m_Clip;
			m_Source.Play();

			EndAction(true);
		}
	}
}