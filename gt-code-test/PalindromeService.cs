using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace gt_code_test
{
    public class PalindromeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _name = "";
        private readonly string _code = "";
        public PalindromeService(IConfiguration config, HttpClient httpClient)
        {
            var baseUrl = config["BaseURL"];
            var code = config["Code"];
            var name = config["Name"];
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException("Value for parameter Code is missing, please add to appsettings.json");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Value for parameter  Name is missing, please add to appsettings.json");
            }
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException("Base URL is missing, please add to appsettings.json");
            }
            _code = code;
            _name = name;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<IEnumerable<string>> GetTestData()
        {
            var url = $"api/get/{_name}?code={_code}";
            var data = await _httpClient.GetFromJsonAsync<IEnumerable<string>>(url);
            if (data == null )
            {
                throw new Exception("NO DATA");
            }
            return data;
        }

        public PalindromeResult FindPalindromes(IEnumerable<string> data)
        {
            var result = new PalindromeResult
            {
                NonPalindromes = new List<string>(),
                Palindromes = new List<string>()
            };
            foreach (var item in data)
            {
                if (PalindromeChecker.IsPalindrome(item))
                {
                    result.Palindromes.Add(item);
                } 
                else
                {
                    result.NonPalindromes.Add(item);
                }
            }
            return result;
        }

        public async Task<bool> SendResult(PalindromeResult result)
        {
            using StringContent data = new(
                JsonSerializer.Serialize(result),
                Encoding.UTF8,
                "application/json");

            var url = $"api/submit/{_name}?code={_code}";
            var retries = 3;
            bool isSuccess = false;
            var waitTimeInSeconds = 10;
            while (!isSuccess && retries > 0)
            {
                using HttpResponseMessage res = await _httpClient.PostAsync(url, data);
                isSuccess = res.IsSuccessStatusCode;
                if (!isSuccess)
                {
                    Console.WriteLine("No good, retrying.", res.StatusCode);
                }
                retries--;
                await Task.Delay(TimeSpan.FromSeconds(waitTimeInSeconds));
                waitTimeInSeconds += 2;
            }           
            return isSuccess;
        }
    }
}
