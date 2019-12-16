﻿using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using System.Diagnostics.Contracts;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BlackSlope.Api.Common.Swagger
{
    public class DocumentFilterAddHealth : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            Contract.Requires(swaggerDoc != null);
            swaggerDoc.Paths.Add("/health", HealthPathItem());
        }

        private OpenApiPathItem HealthPathItem()
        {
            var pathItem = new OpenApiPathItem();
            pathItem.AddOperation(OperationType.Get, new OpenApiOperation
            {
                Tags = new List<OpenApiTag>() { new OpenApiTag() { Name = "Health" } },
                OperationId = "Health_Get",
                Responses = new OpenApiResponses()
                {
                    ["200"] = new OpenApiResponse
                    {
                        Description = "OK",
                    },
                },
            });

            return pathItem;
        }
    }
}
