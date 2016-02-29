using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class HumanSpawner : MonoBehaviour
    {
        public GameObject CharacterDetailsPanel;
        public GameObject ManPrefab;

        public void Start()
        {
            string[] names = {
                                 "Aaron", 
                                 "Abel", 
                                 "Abihu", 
                                 "Abimelech", 
                                 "Abner", 
                                 "Abraham", 
                                 "Abram", 
                                 "Absalom", 
                                 "Achish", 
                                 "Adam",
                                 "Adonijah",
                                 "Agag", 
                                 "Balaam",
                                 "Barack",
                                 "Cain",
                                 "Caleb",
                                 "Dan",
                                 "Daniel",
                                 "Elam",
                                 "Eli",
                                 "Gad",
                                 "Gideon",
                                 "Ham",
                                 "Hiram",
                                 "Isaac",
                                 "Ishmael",
                                 "Jacob",
                                 "Japheth", 
                                 "Kish",
                                 "Levi",
                                 "Lot",
                                 "Mahlon",
                                 "Mordecai",
                                 "Nathan",
                                 "Nimrod",
                                 "Obed", 
                                 "Og",
                                 "Phineas",
                                 "Reuben",
                                 "Samuel",
                                 "Seth",
                                 "Uriah",
                                 "Zadok",
                                 "Zebulun",
                             };

            for (var i = 0; i < 2; i++)
            {
                var man = Instantiate(ManPrefab);
                var x = Random.Range(-2.75f, 2.75f);
                var y = Random.Range(-1.5f, 1.5f);
                man.transform.position = new Vector3(x, y);
                
                var person = man.GetComponent<Person>();
                person.CharacterDetailsPanel = CharacterDetailsPanel;
                person.Name = names[Random.Range(0, names.Length)];

                if (Random.Range(0, 2) == 0)
                {
                    person.Sit();
                }
            }
        }
    }
}
