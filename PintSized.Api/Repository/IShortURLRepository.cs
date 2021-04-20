using System.Collections.Generic;
using PintSized.Api.Models;

namespace Repository
{
    public interface IShortURLRepository
    {
        IEnumerable<ShortURLModel> GetCollectionFromDataStore();
        ShortURLModel GetItemFromDataStoreByShortUrl(string shortUrl);
        ShortURLModel GetItemFromDataStoreByLongUrl(string shortUrl);
        ShortURLModel SaveItemToDataStore(ShortURLModel model);
    }
}