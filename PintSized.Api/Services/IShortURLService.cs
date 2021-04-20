using System.Collections.Generic;
using PintSized.Api.Models;
using PintSized.Api.Models.Request;
using PintSized.Api.Models.Response;

namespace PintSized.Api.Services
{
    public interface IShortURLService
    {
        IEnumerable<ShortURLModel> GetCollectionFromDataStore();
        ShortURLModel GetItemFromDataStore(string shortUrl);
        ShortURLResponse SaveItemToDataStore(ShortURLRequest model);
    }
}