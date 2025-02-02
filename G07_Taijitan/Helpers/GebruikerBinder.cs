﻿using G07_Taijitan.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G07_Taijitan.Helpers {
    public class GebruikerBinder : IModelBinder {
        private readonly ApplicationDbContext _db;
        public GebruikerBinder(ApplicationDbContext db) {
            _db = db;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext) {
            if(bindingContext == null) {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;

            // Try to fetch the value of the argument by name
            var valueProviderResult =
                bindingContext.ValueProvider.GetValue(modelName);

            if(valueProviderResult == ValueProviderResult.None) {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName,
                valueProviderResult);

            var value = valueProviderResult.FirstValue;

            // Check if the argument value is null or empty
            if(string.IsNullOrEmpty(value)) {
                return Task.CompletedTask;
            }

            // Model will be null if not found
            var model = _db.Gebruikers.Find(value);
            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}
