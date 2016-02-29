using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class CharacterDetailsPanel : MonoBehaviour
    {
        public void LoadPerson(Person person)
        {
            var text = GetComponentInChildren<Text>();
            text.text = person.Name;
        }
    }
}
