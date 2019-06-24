using GitDrnk.Models;
using GitDrnk.Services.Data.Interface;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GitDrnk.Services.Data
{
    public class GameRepository : IRepository<Game>
    {
        private readonly IMongoDatabase _database;
        private readonly IOptions<Settings> _settings;
        private IMongoCollection<Game> _gameCollection;
        public GameRepository(IMongoDatabase database, IOptions<Settings> settings)
        {
            this._database = database;
            this._settings = settings;
            var client = new MongoClient(_settings.Value.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(_settings.Value.Database);
                Initialize();
            } else
            {
                throw new MongoClientException("Could not create mongo client");
            }
        }

        public void Initialize()
        {
            if (_database != null)
                _gameCollection = _database.GetCollection<Game>("Game");

            if (_gameCollection == null)
                throw new MongoClientException("Collection Game not found");
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            return await _gameCollection.FindAsync<Game>(new BsonDocument()).Result.ToListAsync<Game>();
        }

        public async Task<Game> GetById(string id)
        {
            return await _gameCollection.FindAsync<Game>(x => x.Id == id).Result.FirstOrDefaultAsync<Game>();
        }

        public async Task<IEnumerable<Game>> GetSubSet(Expression<Func<Game, bool>> filter)
        {
            var subSetFilter = Builders<Game>.Filter.Where(filter);
            return await _gameCollection.FindAsync<Game>(subSetFilter).Result.ToListAsync<Game>();
        }

        public void Seed()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Upsert(Game entry)
        {
            var updateOptions = new UpdateOptions { IsUpsert = true };
            var result = await _gameCollection.ReplaceOneAsync<Game>(x => x.Id == entry.Id, entry, updateOptions);
            return result.IsAcknowledged;    
        }
    }
}
