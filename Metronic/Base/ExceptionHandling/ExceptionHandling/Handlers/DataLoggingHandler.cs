using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using PetaPoco;
using Ponera.Base.Entities;

namespace Ponera.Base.ExceptionHandling.Handlers
{
    public class DataLoggingHandler : IExceptionHandler
    {
        private readonly NameValueCollection _attributes;

        public DataLoggingHandler(NameValueCollection attributes)
        {
            _attributes = attributes;
        }

        public Exception HandleException(Exception exception, Guid handlingInstanceId)
        {
            // TODO : @deniz DI'a geçildiğinde değiştirilecek
            Database database = new Database("PoneraIntranet");

            StringBuilder sb = new StringBuilder();

            string exceptionInstanceId = exception.Data.Contains("HandlingInstanceId") ? exception.Data["HandlingInstanceId"].ToString() : handlingInstanceId.ToString();

            using (StringWriter sw = new StringWriter(sb))
            {
                TextExceptionFormatter exceptionFormatter = new TextExceptionFormatter(sw, exception, Guid.Parse(exceptionInstanceId));
                exceptionFormatter.Format();
            }

            SetCurrentUrlToException(exception);

            string message = sb.ToString();

            ErrorLog errorLog = new ErrorLog()
            {
                ExceptionType = exception.GetType().FullName,
                ExceptionDetail = message,
                HandlingInstanceId = Guid.Parse(exceptionInstanceId),
                PageName = exception.Data["AbsolutePath"].ToString(),
                CreateDate = DateTime.Now,
                UserId = 0 // TODO : @deniz userId
            };

            database.Insert(errorLog);

            if (!exception.Data.Contains("HandlingInstanceId"))
            {
                exception.Data.Add("HandlingInstanceId", exceptionInstanceId);
            }

            return exception;
        }

        private void SetCurrentUrlToException(Exception exception)
        {
            if (HttpContext.Current != null)
            {
                string absolutePath = HttpContext.Current.Request.Url.AbsolutePath;

                if (!exception.Data.Contains("AbsolutePath"))
                {
                    exception.Data.Add("AbsolutePath", absolutePath);
                }
            }
        }
    }
}
