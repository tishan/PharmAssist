using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace PharmAssist.Core.Data
{
   internal static class ExceptionHelper
    {
        /// <summary>
        /// Private class containing SQL server error codes.
        /// </summary>
        private static class SqlErrorNumbers
        {
            /// <summary>
            /// The SQL error number representing a constraint violation.
            /// </summary>
            internal const int ConstraintViolation = 2627;

            /// <summary>
            /// The SQL error number representing a constraint conflict.
            /// </summary>
            internal const int ConstraintConflict = 547;

            /// <summary>
            /// The SQL error number representing a unique index/constraint violation.
            /// </summary>
            internal const int UniqueIndexConstraintViolation = 2601;
        }

        /// <summary>
        /// Creates a <see cref="DataException"/> using the information in a given <see cref="SqlException"/>.
        /// </summary>
        /// <param name="sqlException">The <see cref="SqlException"/>.</param>
        /// <returns>The created <see cref="DataException"/>.</returns>
        public static DataException CreateDataException(SqlException sqlException)
        {
            DataException exception;
            switch (sqlException.Number)
            {
                case SqlErrorNumbers.ConstraintViolation:
                case SqlErrorNumbers.ConstraintConflict:
                case SqlErrorNumbers.UniqueIndexConstraintViolation:
                    exception = new ConstraintException(sqlException.Message, sqlException);
                    break;

                default:
                    exception = new DataException(sqlException.Message, sqlException);
                    break;
            }

            return exception;
        }
    }
}
