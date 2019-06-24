using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitDrnk.Models
{
    public class Game
    {
        [BsonId]
        public string Id;
        public IEnumerable<Player> Players;
    }
}
