using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Applications.Application.Interface;
using API.Applications.Application.Service;
using API.Domains.Domain.Core.Repositories;
using API.Domains.Domain.Core.Services;
using API.Domains.Domain.Services.Services;
using API.Infra.Infra.CrossCutting.Adapter.Interface;
using API.Infra.Infra.CrossCutting.Adapter.Map;
using API.Infra.Infra.Data.Repository;

namespace API.Infra.Infra.CrossCutting.IOC.InversionOfControl
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection LoadDI(this IServiceCollection services)
        {
            #region Registers IOC

            #region IOC Application
                services.AddScoped<IApplicationServiceClientes, ApplicationServiceClientes>();
            #endregion

            #region IOC Services
                services.AddScoped<IServiceCliente, ServiceClientes>();
            #endregion

            #region IOC RepositorySQL
                services.AddScoped<IRepositoryClientes, RepositoryClientes>();
            #endregion

            #region IOC Mapper
                services.AddScoped<IMapperCliente, MapperCliente>();
            #endregion
            
            #endregion

            return services;
        }
    }
}