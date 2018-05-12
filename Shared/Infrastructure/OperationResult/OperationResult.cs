using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.OperationResult
{
    public class OperationResult<T>
    {
        #region Properties

        private bool checkedForValidity = false;

        private T data;

        public T Data
        {
            get
            {
                if (checkedForValidity)
                {
                    return this.data;
                }
                else
                {
                    throw new Exception("Call IsValid first");
                }
            }
        }

        private String message;

        public String Message { get { return this.message; }  }

        private OperationResultType resultType;

        #endregion Properties

        #region Ctor

        private OperationResult(T data, String message, OperationResultType resultType)
        {
            this.data = data;
            this.message = message;
            this.resultType = resultType;
        }

        #endregion Ctor

        #region Factory

        public static OperationResult<T> CreateSuccessResult(T data, String message)
        {
            return new OperationResult<T>(data, message, OperationResultType.Success);
        }

        public static OperationResult<T> CreateFailureResult(T data, String message)
        {
            return new OperationResult<T>(data, message, OperationResultType.Failure);
        }

        public static OperationResult<T> CreateErrorResult(T data, String message)
        {
            return new OperationResult<T>(data, message, OperationResultType.Error);
        }

        #endregion

        public bool IsValid()
        {
            checkedForValidity = true;
            return this.resultType == OperationResultType.Success;
        }

        public bool HasException()
        {
            return this.resultType == OperationResultType.Error;
        }

        public bool HasFailed()
        {
            return this.resultType == OperationResultType.Failure;
        }
    }
}
