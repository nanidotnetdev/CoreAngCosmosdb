﻿using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Linq;

namespace CoreAngCosmos.API.Helpers
{
    /// <summary>
    /// Used to group controllers based on Namespace.
    /// </summary>
    public class ApiExplorerGroupPerVersionConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var controllerNamespace = controller.ControllerType.Namespace; // e.g. "Controllers.V1"
            var apiVersion = controllerNamespace.Split('.').Last().ToLower();

            controller.ApiExplorer.GroupName = apiVersion;
        }
    }
}