using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor344.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Blazor344.Services
{
    public class EmployeeService : IEmployeeService
    {
        private HttpClient _httpClient;
        public EmployeeService (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<Employee> Add(Employee employee)
        {
            throw new NotImplementedException();
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
        public async Task <IEnumerable<Employee>> GetAll()
        {
            var results = await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/Employees");
            return results;
        }
        public async Task<Employee> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Employee>($"api/Employees/{id}");
            return result;
        }
        public async Task<Employee> Update(int id, Employee employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Employees/{id}", employee);
            if(response.IsSuccessStatusCode){
                return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
            }
            else{
                throw new Exception("Gagal Update Data Employee");
            }
        }
    }    
}