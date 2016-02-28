using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Ponera.Base.ExceptionHandling.Exceptions;
using Ponera.Base.ExceptionHandling.Exceptions.DataAccess;
using Ponera.Base.ExceptionHandling.Handlers;

namespace Ponera.Base.ExceptionHandling
{
    public static class ExceptionHandlingConfiguration
    {
        public static void Configure()
        {
            ConfigurationSourceBuilder configBuilder = new ConfigurationSourceBuilder();

            configBuilder
                .ConfigureExceptionHandling()
                .GivenPolicyWithName("PoneraAdmin")
                    .ForExceptionType<Exception>()
                        .HandleCustom<DataLoggingHandler>()
                        .ThenDoNothing()
                    .ForExceptionType<BaseUserLevelException>()
                        .ThenDoNothing()
                .GivenPolicyWithName("Business")
                    .ForExceptionType<Exception>()
                        .HandleCustom<DataLoggingHandler>()
                        .ReplaceWith<UnhandledUserLevelException>()
                        .ThenThrowNewException()
                    .ForExceptionType<BaseException>()
                        .HandleCustom<DataLoggingHandler>()
                        .ReplaceWith<UnhandledUserLevelException>()
                        .ThenThrowNewException()
                    .ForExceptionType<UserLevelException>()
                        .ThenNotifyRethrow()
                    .ForExceptionType<CriticalUserLevelException>()
                        .HandleCustom<DataLoggingHandler>()
                        .ThenNotifyRethrow()
                .GivenPolicyWithName("DataAccess")
                    .ForExceptionType<Exception>()
                        .HandleCustom<DataLoggingHandler>()
                        .WrapWith<DataAccessLayerException>()
                        .ThenThrowNewException()
                    .ForExceptionType<DataAccessLayerException>()
                        .ThenThrowNewException();

            var configSource = new DictionaryConfigurationSource();
            configBuilder.UpdateConfigurationWithReplace(configSource);
            ExceptionPolicy.SetExceptionManager(new ExceptionPolicyFactory(configSource).CreateManager());
        }
    }
}
