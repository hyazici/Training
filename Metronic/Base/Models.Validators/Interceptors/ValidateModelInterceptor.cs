using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.Core.Internal;
using Castle.DynamicProxy;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using Ponera.Base.Models.Validators.Attributes;
using Ponera.Base.Models.Validators.Factories;

using ValidationException = Ponera.Base.ExceptionHandling.Exceptions.ValidationException;

namespace Ponera.Base.Models.Validators.Interceptors
{
    public class ValidateModelInterceptor : IInterceptor
    {
        private readonly ModelValidatorFactory _modelValidatorFactory;

        public ValidateModelInterceptor(ModelValidatorFactory modelValidatorFactory)
        {
            _modelValidatorFactory = modelValidatorFactory;
        }

        public void Intercept(IInvocation invocation)
        {
            MethodInfo targetMethod = invocation.MethodInvocationTarget;
            ParameterInfo[] parameters = targetMethod.GetParameters();

            ValidateModelAttribute validateModelAttribute = targetMethod.GetCustomAttribute<ValidateModelAttribute>();

            if (validateModelAttribute == null)
            {
                invocation.Proceed();
                return;
            }

            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterInfo parameter = parameters[i];
                object argument = invocation.Arguments[i];

                if (!parameter.ParameterType.IsClass)
                {
                    continue;
                }

                if (argument == null)
                {
                    throw new ArgumentNullException(parameter.Name);
                }

                IValidator validator = _modelValidatorFactory.GetValidator(parameter.ParameterType);

                if (validator == null)
                {
                    continue;
                }

                ValidationResult validationResult = validator.Validate(argument);

                if (!validationResult.IsValid)
                {
                    IList<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>();
                    validationResult.Errors.ForEach(failure => keyValuePairs.Add(new KeyValuePair<string, string>(failure.ErrorCode, failure.PropertyName)));

                    throw new ValidationException(GetExceptionMessage(validationResult), keyValuePairs);
                }
            }

            invocation.Proceed();
        }

        private static string GetExceptionMessage(ValidationResult validationResult)
        {
            StringBuilder sb = new StringBuilder();
            validationResult.Errors.Select(failure => failure.ErrorMessage).Distinct().ForEach(message => sb.AppendLine(message));

            return sb.ToString();
        }
    }
}
