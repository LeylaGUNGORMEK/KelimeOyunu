using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Models
{
    [System.Serializable]
    public class Letter
    {

        public int x{ get; set; }
        public int y{ get; set; }
        public GameObject letterBox;

       
    }
   /* public class LetterList
    {
        List<Letter> selectedLetters = new List<Letter>();
        public void selectedLettersAdd(Letter letter)
        {
            selectedLetters.Add(letter);
        }
        public IEnumerator GetEnumerator()
        {
            return selectedLetters.GetEnumerator();
        }
    }*/
}
