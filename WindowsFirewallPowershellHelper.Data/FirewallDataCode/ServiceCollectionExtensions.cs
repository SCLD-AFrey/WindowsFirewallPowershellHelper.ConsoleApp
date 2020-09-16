﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using WindowsFirewallPowershellHelper.Data.FirewallHelper;
namespace WindowsFirewallPowershellHelper.Data.FirewallHelper
{
    public partial class FirewallHelperUnitOfWork : UnitOfWork
    {
        public FirewallHelperUnitOfWork() : base() { }
        public FirewallHelperUnitOfWork(DevExpress.Xpo.Metadata.XPDictionary dictionary) : base(dictionary) { }
        public FirewallHelperUnitOfWork(IDataLayer layer, params IDisposable[] disposeOnDisconnect) : base(layer, disposeOnDisconnect) { }
        public FirewallHelperUnitOfWork(IObjectLayer layer, params IDisposable[] disposeOnDisconnect) : base(layer, disposeOnDisconnect) { }
    }
}
namespace Microsoft.Extensions.DependencyInjection
{
    public static class FirewallHelperXpoServiceCollectionExtensions
    {
        public static IServiceCollection AddFirewallHelperAsXpoDefaultUnitOfWork(this IServiceCollection serviceCollection, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultUnitOfWork(useDataLayerAsSingletone, optionsBuilder);
        }
        public static IServiceCollection AddFirewallHelperAsXpoDefaultSession(this IServiceCollection serviceCollection, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultSession(useDataLayerAsSingletone, optionsBuilder);
        }
        public static IServiceCollection AddFirewallHelperUnitOfWork(this IServiceCollection serviceCollection, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoCustomSession<FirewallHelperUnitOfWork>(useDataLayerAsSingletone, optionsBuilder);
        }
        public static IServiceCollection AddFirewallHelperXpoDefaultDataLayer(this IServiceCollection serviceCollection, ServiceLifetime lifetime, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultDataLayer(lifetime, customDataLayerOptionsBuilder);
        }
        public static IServiceCollection AddFirewallHelperAsXpoDefaultUnitOfWork(this IServiceCollection serviceCollection, IConfiguration configuration, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultUnitOfWork(useDataLayerAsSingletone, o => { o.UseConnectionStringForFirewallHelper(configuration); optionsBuilder(o); });
        }
        public static IServiceCollection AddFirewallHelperAsXpoDefaultSession(this IServiceCollection serviceCollection, IConfiguration configuration, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultSession(useDataLayerAsSingletone, o => { o.UseConnectionStringForFirewallHelper(configuration); optionsBuilder(o); });
        }
        public static IServiceCollection AddFirewallHelperUnitOfWork(this IServiceCollection serviceCollection, IConfiguration configuration, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoCustomSession<FirewallHelperUnitOfWork>(useDataLayerAsSingletone, o => { o.UseConnectionStringForFirewallHelper(configuration); optionsBuilder(o); });
        }
        public static IServiceCollection AddFirewallHelperXpoDefaultDataLayer(this IServiceCollection serviceCollection, IConfiguration configuration, ServiceLifetime lifetime, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultDataLayer(lifetime, o => { o.UseConnectionStringForFirewallHelper(configuration); optionsBuilder(o); });
        }
        public static DataLayerOptionsBuilder UseConnectionStringForFirewallHelper(this DataLayerOptionsBuilder options, IConfiguration configuration)
        {
            return options.UseConnectionString(configuration.GetConnectionString(ConnectionHelper.ConnectionStringName));
        }
        static Action<DataLayerOptionsBuilder> CreateDataLayerOptionsBuilder(Action<DataLayerOptionsBuilder> injectCustomDataLayerOptionsBuilder)
        {
            return (options) =>
            {
                if (injectCustomDataLayerOptionsBuilder != null)
                {
                    injectCustomDataLayerOptionsBuilder(options);
                }
            };
        }
    }
}
