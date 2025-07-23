using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace financeManager.Application.DTOs
{
    public class OperationResultNoData
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }

        public static OperationResultNoData Ok() => new() { Success = true };
        public static OperationResultNoData Fail(string? error = null) => new() { Success = false, ErrorMessage = error };
    }
}