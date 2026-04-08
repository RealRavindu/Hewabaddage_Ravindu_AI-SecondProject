using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{

    public class AutoAttackAT : ActionTask
    {
        public BBParameter<Transform> targetTransform;
        public BBParameter<float> attackSpeed;
        public BBParameter<float> attackDamage;
        public GameObject autoPrefab;
        private float timePassed;
        public Slider autoSlider;
        private Material allyMat;
        protected override string OnInit()
        {
            autoSlider = agent.transform.GetChild(0).GetChild(0).GetComponent<Slider>();
            allyMat = agent.GetComponent<MeshRenderer>().material;
            return null;
        }

        protected override void OnExecute()
        {
            timePassed = 0;
            autoSlider.value = 0;
            autoSlider.gameObject.SetActive(true);
        }

        protected override void OnUpdate()
        {
            autoSlider.value = timePassed / 1;
            timePassed += Time.deltaTime * attackSpeed.value;

            if (timePassed  > 1)
            {
                spawnAuto();
                EndAction(true);
            }
        }


        protected override void OnStop()
        {
            autoSlider.gameObject.SetActive(false);
        }

        protected override void OnPause()
        {

        }

        void spawnAuto()
        {
            autoSlider.gameObject.SetActive(false);
            GameObject autoAttackObject = GameObject.Instantiate(autoPrefab);
            AutoAttack autoattack = autoAttackObject.GetComponent<AutoAttack>();
            autoattack.Init(attackSpeed.value, attackDamage.value, targetTransform.value, agent.transform.position, allyMat);
        }
    }
}