using DatabaseLayer.Context;
using DatabaseLayer.Models;
using DTOs;
using ServiceLayer.Implementations;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolOperationsApi.Common
{
    public class MessageLogging
    {
        private readonly IApiLogService ApiLogService;

        public MessageLogging()
        {
            ApiLogService = new ApiLogService();
        }

        public void IncomingMessageAsync(ApiLogDTO apiLog)
        {
            apiLog.RequestType = "Request";
            
            ApiLogService.AddApiLogAsync(apiLog);
            
        }

        public void OutgoingMessageAsync(ApiLogDTO apiLog)
        {
            apiLog.RequestType = "Response";

            ApiLogService.AddApiLogAsync(apiLog);
        }
    }
}