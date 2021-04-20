using System;
using System.Collections.Generic;
using PintSized.Api.Models;

namespace Repository
{
    public class ShortURLRepository : BaseMongoRepository<ShortURLModel>, IShortURLRepository
    {

        public ShortURLRepository(string mongoDBConnectionString, string dbName, string collectionName) : base(mongoDBConnectionString, dbName, collectionName)
        {

        }
        public IEnumerable<ShortURLModel> GetCollectionFromDataStore()
        {
            return GetList();
        }

        public ShortURLModel GetItemFromDataStoreByShortUrl(string shortUrl)
        {
            return GetBy(c => c.ShortURL == shortUrl);
        }


        public ShortURLModel GetItemFromDataStoreByLongUrl(string longUrl)
        {
            return GetBy(c => c.LongURL == longUrl);
        }

        public ShortURLModel SaveItemToDataStore(ShortURLModel model)
        {
            try
            {
                this.Create(model);
            }
            catch (Exception)
            {
                return null;
            }

            return model;
        }
    }
}