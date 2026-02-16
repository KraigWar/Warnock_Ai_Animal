using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

    public class ArmAnimAT : ActionTask
    {

        private Transform Larm;
        private Transform Rarm;
        public float angle;
        protected override string OnInit()
        {

            Larm = GameObject.FindWithTag("Larm").transform;
            Rarm = GameObject.FindWithTag("Rarm").transform;
            return null;
        }


        protected override void OnExecute()
        {

            Larm.transform.Rotate(new Vector3(Larm.rotation.x, angle, Larm.rotation.z));
            Rarm.transform.Rotate(new Vector3(Rarm.rotation.x, angle, Rarm.rotation.z));
            
        }

        protected override void OnStop()
        {
            Larm.transform.Rotate(new Vector3(Larm.rotation.x, -angle, Larm.rotation.z));
            Rarm.transform.Rotate(new Vector3(Rarm.rotation.x, -angle, Rarm.rotation.z));
        }

    }
}