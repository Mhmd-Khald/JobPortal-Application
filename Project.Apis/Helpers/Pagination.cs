using Project.Apis.Dto;
using System.Collections;
using System.Collections.Generic;


namespace Project.Apis.Helpers
{
    public class Pagination<T>
    {
        public Pagination(  string token ,IEnumerable<T> data , int count )
        {
            Token = token;
            Data = data; 
            Count = count;
            
        }

        public int Count { get; set; }
        public string Token { get; set; }
        public IEnumerable<T> Data { get; set; } 
    
    }
}
