﻿using G07_Taijitan.Models.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using G07_Taijitan.Models.Domain.Gebruiker;

namespace G07_Taijitan.Helpers {
    public class GebruikerEntityProvider : IModelBinderProvider {
        public IModelBinder GetBinder(ModelBinderProviderContext context) {
            if(context == null) {
                throw new ArgumentNullException(nameof(context));
            }

            if(context.Metadata.ModelType == typeof(Gebruiker)) {
                return new BinderTypeModelBinder(typeof(GebruikerBinder));
            }

            return null;
        }
    }
}

