using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Models
{
    [System.Serializable]
    public class BoardList
    {
        public int boardRow;
        public int boardCol;
        public Letters[] letters;

    }
}
