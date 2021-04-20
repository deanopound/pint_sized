using System;
using PintSized.Api.Models;
using PintSized.Api.Models.Request;

namespace PintSized.Api.Services.Utilities
{
    public class ShortURLMapper
    {
        public static ShortURLModel MapRequestModelToDBModel(ShortURLRequest requestModel)
        {
            var shortURLToken = TokenGenerator.GenerateShortURL();

            ShortURLModel result = new ShortURLModel
            {
                CreatedAt = DateTime.Now,
                LongURL = requestModel.LongURL,
                ShortURL = shortURLToken,
            };

            return result;
        }
    }
}