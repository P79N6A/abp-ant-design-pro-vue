﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Niue.Abp.Abp.Authorization;
using Niue.Abp.Abp.Collections.Extensions;
using Niue.Abp.Abp.Domain.Entities;
using Niue.Abp.Abp.Extensions;
using Niue.Abp.Abp.Localization;
using Niue.Abp.Abp.Runtime.Validation;
using Niue.Abp.Abp.UI;
using Niue.Abp.Abp.Web.Common.Web.Configuration;

namespace Niue.Abp.Abp.Web.Common.Web.Models
{
    //TODO@Halil: I did not like constructing ErrorInfo this way. It works wlll but I think we should change it later...
    internal class DefaultErrorInfoConverter : IExceptionToErrorInfoConverter
    {
        private readonly IAbpWebCommonModuleConfiguration _configuration;
        private readonly ILocalizationManager _localizationManager;

        public IExceptionToErrorInfoConverter Next { set; private get; }

        private bool SendAllExceptionsToClients
        {
            get
            {
                return _configuration.SendAllExceptionsToClients;
            }
        }

        public DefaultErrorInfoConverter(
            IAbpWebCommonModuleConfiguration configuration, 
            ILocalizationManager localizationManager)
        {
            _configuration = configuration;
            _localizationManager = localizationManager;
        }

        public ErrorInfo Convert(Exception exception)
        {
            var errorInfo = CreateErrorInfoWithoutCode(exception);

            if (exception is IHasErrorCode)
            {
                errorInfo.Code = (exception as IHasErrorCode).Code;
            }

            return errorInfo;
        }

        private ErrorInfo CreateErrorInfoWithoutCode(Exception exception)
        {
            if (SendAllExceptionsToClients)
            {
                return CreateDetailedErrorInfoFromException(exception);
            }

            if (exception is AggregateException && exception.InnerException != null)
            {
                var aggException = exception as AggregateException;
                if (aggException.InnerException is UserFriendlyException ||
                    aggException.InnerException is AbpValidationException)
                {
                    exception = aggException.InnerException;
                }
            }

            if (exception is UserFriendlyException)
            {
                var userFriendlyException = exception as UserFriendlyException;
                return new ErrorInfo(userFriendlyException.Message, userFriendlyException.Details);
            }

            if (exception is AbpValidationException)
            {
                return new ErrorInfo(L("ValidationError"))
                {
                    ValidationErrors = GetValidationErrorInfos(exception as AbpValidationException),
                    Details = GetValidationErrorNarrative(exception as AbpValidationException)
                };
            }

            if (exception is EntityNotFoundException)
            {
                var entityNotFoundException = exception as EntityNotFoundException;

                return new ErrorInfo(
                    string.Format(
                        L("EntityNotFound"),
                        entityNotFoundException.EntityType.Name,
                        entityNotFoundException.Id
                    )
                );
            }

            if (exception is AbpAuthorizationException)
            {
                var authorizationException = exception as AbpAuthorizationException;
                return new ErrorInfo(authorizationException.Message);
            }

            return new ErrorInfo(L("InternalServerError"));
        }

        private ErrorInfo CreateDetailedErrorInfoFromException(Exception exception)
        {
            var detailBuilder = new StringBuilder();

            AddExceptionToDetails(exception, detailBuilder);

            var errorInfo = new ErrorInfo(exception.Message, detailBuilder.ToString());

            if (exception is AbpValidationException)
            {
                errorInfo.ValidationErrors = GetValidationErrorInfos(exception as AbpValidationException);
            }

            return errorInfo;
        }

        private void AddExceptionToDetails(Exception exception, StringBuilder detailBuilder)
        {
            //Exception Message
            detailBuilder.AppendLine(exception.GetType().Name + ": " + exception.Message);

            //Additional info for UserFriendlyException
            if (exception is UserFriendlyException)
            {
                var userFriendlyException = exception as UserFriendlyException;
                if (!string.IsNullOrEmpty(userFriendlyException.Details))
                {
                    detailBuilder.AppendLine(userFriendlyException.Details);
                }
            }

            //Additional info for AbpValidationException
            if (exception is AbpValidationException)
            {
                var validationException = exception as AbpValidationException;
                if (validationException.ValidationErrors.Count > 0)
                {
                    detailBuilder.AppendLine(GetValidationErrorNarrative(validationException));
                }
            }

            //Exception StackTrace
            if (!string.IsNullOrEmpty(exception.StackTrace))
            {
                detailBuilder.AppendLine("STACK TRACE: " + exception.StackTrace);
            }

            //Inner exception
            if (exception.InnerException != null)
            {
                AddExceptionToDetails(exception.InnerException, detailBuilder);
            }

            //Inner exceptions for AggregateException
            if (exception is AggregateException)
            {
                var aggException = exception as AggregateException;
                if (aggException.InnerExceptions.IsNullOrEmpty())
                {
                    return;
                }

                foreach (var innerException in aggException.InnerExceptions)
                {
                    AddExceptionToDetails(innerException, detailBuilder);
                }
            }
        }

        private ValidationErrorInfo[] GetValidationErrorInfos(AbpValidationException validationException)
        {
            var validationErrorInfos = new List<ValidationErrorInfo>();

            foreach (var validationResult in validationException.ValidationErrors)
            {
                var validationError = new ValidationErrorInfo(validationResult.ErrorMessage);
                if (validationResult.ErrorMessage == "The EmailAddress field is not a valid e-mail address.")
                {
                    validationError.Message = "Email格式错误。";
                }

                if (validationResult.MemberNames != null && validationResult.MemberNames.Any())
                {
                    validationError.Members = validationResult.MemberNames.Select(m => m.ToCamelCase()).ToArray();
                }

                validationErrorInfos.Add(validationError);
            }

            return validationErrorInfos.ToArray();
        }

        private string GetValidationErrorNarrative(AbpValidationException validationException)
        {
            var detailBuilder = new StringBuilder();
            detailBuilder.AppendLine(L("ValidationNarrativeTitle"));
            
            foreach (var validationResult in validationException.ValidationErrors)
            {
                detailBuilder.AppendFormat(" - {0}", validationResult.ErrorMessage);
                detailBuilder.AppendLine();
            }

            return detailBuilder.ToString();
        }

        private string L(string name)
        {
            try
            {
                return _localizationManager.GetString(AbpWebConsts.LocalizaionSourceName, name);
            }
            catch (Exception)
            {
                return name;
            }
        }
    }
}