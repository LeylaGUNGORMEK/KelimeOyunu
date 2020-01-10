using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Models
{
    [System.Serializable]
    public class PuzzleData
    {
        public string topic;
        public string[] words;
        public int rewardCoin;
        public BoardList board;
        /*public PuzzleData(string topic, string[] words,int rewardCoin, BoardList board)
        {
            this.topic = topic;
            this.words = words;
            this.rewardCoin = rewardCoin;
            this.board = board;
        }*/
    }
}
