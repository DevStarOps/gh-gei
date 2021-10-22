﻿using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OctoshiftCLI
{
    public class GithubClient
    {
        private readonly HttpClient _httpClient;

        public GithubClient(string githubToken)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("OctoshiftCLI", "0.1"));
            _httpClient.DefaultRequestHeaders.Add("GraphQL-Features", "import_api");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", githubToken);
        }

        public async Task<string> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url.Replace(" ", "%20"));
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAsync(string url, HttpContent body)
        {
            var response = await _httpClient.PostAsync(url.Replace(" ", "%20"), body);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PutAsync(string url, HttpContent body)
        {
            var response = await _httpClient.PutAsync(url.Replace(" ", "%20"), body);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PatchAsync(string url, HttpContent body)
        {
            var response = await _httpClient.PatchAsync(url.Replace(" ", "%20"), body);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url.Replace(" ", "%20"));
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}