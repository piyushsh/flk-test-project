using Fluke_Test_Project.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace Fluke_Test_Project.Repository
{
    public interface IEonetRepo
    {
        IEnumerable<Event> GetEvents(EonetRequestModel request);

        Event GetEvent(string eventId);
    }
    public class EonetRepo : IEonetRepo
    {
        private const string EONET_EVENT_ENDPOINT = "https://eonet.sci.gsfc.nasa.gov/api/v2.1/events";
        private HttpClient _httpClient; 

        public EonetRepo()
        {
            _httpClient = new HttpClient();
        }

        public IEnumerable<Event> GetEvents(EonetRequestModel request)
        {
            var url = $"{EONET_EVENT_ENDPOINT}?" +
                $"{AddQueryString("status", request.Status)}" +
                 (request.Limit > 0 ? AddQueryString("limit", request.Limit.ToString()) : "")  +
                 (request.Days > 0 ? AddQueryString("days", request.Days.ToString()) : "");

            var response = _httpClient.GetAsync(url).Result;
            return GetResult<EonetResponse>(response).Events;
        }

        public Event GetEvent(string eventId)
        {
            var url = $"{EONET_EVENT_ENDPOINT}/{eventId}";
            var response = _httpClient.GetAsync(url).Result;
            return GetResult<Event>(response);
        }

        private TResult GetResult<TResult>(HttpResponseMessage response)
        {
            if(response.IsSuccessStatusCode)
            {
                var contentString = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<TResult>(contentString);
            }
            throw new EonetResponseException($"API request was not successfull. Response ---> {JsonConvert.SerializeObject(response)}");
        }

        private string AddQueryString(string key, 
            string value, 
            bool isLastQueryString = false)
        {
            if(!string.IsNullOrEmpty(value))
            {
                return $"{key}={value}" + (isLastQueryString ? "" : "&");
            }
            return string.Empty;
        }
    }
}
