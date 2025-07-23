using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace financeManager.Application.DTOs
{
    public class OperationResult<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }

        public static OperationResult<T> Ok(T data) => new() { Success = true, Data = data };
        public static OperationResult<T> Fail(string error) => new() { Success = false, ErrorMessage = error };
    }
}