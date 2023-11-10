﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    interface IHandOfCards : IDeckOfCards
    {

        public int PlayerNumber { get; set; }
        /// <summary>
        /// Add a card to the hand and sorts the hand
        /// </summary>
        /// <param name="card">Card to be added</param>
        public void Add(PlayingCard card);

        /// <summary>
        /// The Higest card in the sorted hand
        /// </summary>
        public PlayingCard Highest { get; }

        /// <summary>
        /// The Lowest card in the sorted hand
        /// </summary>
        public PlayingCard Lowest { get; }

    }
}
