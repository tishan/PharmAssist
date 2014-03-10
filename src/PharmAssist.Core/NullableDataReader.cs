using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PharmAssist.Core
{
    /// <summary>
    /// A datareader that supports nullable data types.
    /// </summary>
    public sealed class NullableDataReader : IDataReader
    {
        /// <summary>
        /// The delegate used to call GetXXX methods of the underlying data reader.
        /// </summary>
        /// <typeparam name="T">The return type of the method.</typeparam>
        /// <param name="ordinal">The position of the column to retrieve.</param>
        /// <returns>The value from the method.</returns>
        private delegate T GetMethod<T>(int ordinal);

        /// <summary>
        /// The underlying datareader.
        /// </summary>
        private readonly IDataReader _reader;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableDataReader"/> class.
        /// </summary>
        /// <param name="reader">The reader.</param>
        public NullableDataReader(IDataReader reader)
        {
            _reader = reader;
        }

        /// <summary>
        /// Gets the value of the specified column as <see cref="Nullable{Int32}"/>.
        /// </summary>
        /// <param name="ordinal">The ordinal of the column.</param>
        /// <returns>The value of the field column.</returns>
        public int? GetNullableInt32(int ordinal)
        {
            return GetNullable<int>(ordinal, GetInt32);
        }

        /// <summary>
        /// Gets the value of the specified column as <see cref="Nullable{Int64}"/>.
        /// </summary>
        /// <param name="ordinal">The ordinal of the column.</param>
        /// <returns>The value of the field column.</returns>
        public long? GetNullableInt64(int ordinal)
        {
            return GetNullable<long>(ordinal, GetInt64);
        }

        /// <summary>
        /// Gets the nullable GUID.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The value of the column</returns>
        public Guid? GetNullableGuid(string name)
        {
            return GetNullableGuid(_reader.GetOrdinal(name));
        }

        /// <summary>
        /// Gets the value of the specified column as <see cref="Nullable{Int32}"/>.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The value of the column</returns>
        public int? GetNullableInt32(string name)
        {
            return GetNullableInt32(_reader.GetOrdinal(name));
        }

        /// <summary>
        /// Gets the nullable GUID.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>The GUID at the specified ordinal.</returns>
        public Guid? GetNullableGuid(int ordinal)
        {
            return GetNullable<Guid>(ordinal, GetGuid);
        }

        /// <summary>
        /// Gets the value of the specified column as <see cref="Nullable{Int64}"/>.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The value of the column</returns>
        public long? GetNullableInt64(string name)
        {
            return GetNullableInt64(_reader.GetOrdinal(name));
        }

        /// <summary>
        /// Gets the value of the specified column as <see cref="Nullable{Decimal}"/>.
        /// </summary>
        /// <param name="ordinal">The ordinal of the column.</param>
        /// <returns>The value of the field column.</returns>
        public decimal? GetNullableDecimal(int ordinal)
        {
            return GetNullable<decimal>(ordinal, GetDecimal);
        }

        /// <summary>
        /// If the value speicfied in the column is null return null, else return the value.
        /// </summary>
        /// <param name="name">The name of the column</param>
        /// <returns>he value of the column</returns>
        public decimal? GetNullableDecimal(string name)
        {
            return GetNullableDecimal(_reader.GetOrdinal(name));
        }

        /// <summary>
        /// Gets the value of the specified column as <see cref="Nullable{Int16}"/>.
        /// </summary>
        /// <param name="ordinal">The ordinal of the column.</param>
        /// <returns>The value of the field column.</returns>
        public short? GetNullableInt16(int ordinal)
        {
            return GetNullable<short>(ordinal, GetInt16);
        }

        /// <summary>
        /// If the value speicfied in the column is null return null, else return the value.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The value of the column.</returns>
        public short? GetNullableInt16(string name)
        {
            return GetNullableInt16(_reader.GetOrdinal(name));
        }

        /// <summary>
        /// Gets the nullable date time.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The value of the column</returns>
        public DateTime? GetNullableDateTime(string name)
        {
            return GetNullableDateTime(_reader.GetOrdinal(name));
        }

        /// <summary>
        /// Gets the nullable date time.
        /// </summary>
        /// <param name="ordinal">The ordinal.</param>
        /// <returns>The value of the column</returns>
        public DateTime? GetNullableDateTime(int ordinal)
        {
            return GetNullable<DateTime>(ordinal, GetDateTime);
        }

        /// <summary>
        /// Gets the value of the specified column as a string.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The value of the column.</returns>
        public string GetString(string name)
        {
            int ordinal = _reader.GetOrdinal(name);
            if (!_reader.IsDBNull(ordinal))
            {
                return _reader.GetString(ordinal);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the value of the specified column as a DateTime.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The value of the column</returns>
        public DateTime GetDateTime(string name)
        {
            return _reader.GetDateTime(_reader.GetOrdinal(name));
        }

        /// <summary>
        /// Gets the value of the specified column as a byte.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The value of the column</returns>
        public byte GetByte(string name)
        {
            return _reader.GetByte(_reader.GetOrdinal(name));
        }

        /// <summary>
        /// Gets the value of the specified column as a int16.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The value of the column</returns>
        public short GetInt16(string name)
        {
            return _reader.GetInt16(_reader.GetOrdinal(name));
        }

        /// <summary>
        /// Gets the value of the specified column as a Int32.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The value of the column</returns>
        public int GetInt32(string name)
        {
            return _reader.GetInt32(_reader.GetOrdinal(name));
        }

        /// <summary>
        /// Gets the value of the specified column as a int64.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The value of the column</returns>
        public long GetInt64(string name)
        {
            return _reader.GetInt64(_reader.GetOrdinal(name));
        }

        /// <summary>
        /// Gets the value of the specified column as a Boolean.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The value of the column.</returns>
        public bool GetBoolean(string name)
        {
            return _reader.GetBoolean(_reader.GetOrdinal(name));
        }

        /// <summary>
        /// Gets the value of the specified column as a float.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The value of the column.</returns>
        public float GetFloat(string name)
        {
            return _reader.GetFloat(_reader.GetOrdinal(name));
        }

        /// <summary>
        /// Gets the value of the specified column as a Decimal.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The value of the column</returns>
        public decimal GetDecimal(string name)
        {
            return _reader.GetDecimal(_reader.GetOrdinal(name));
        }

        /// <summary>
        /// Gets the value of the specified column as a GUID.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The value of the column</returns>
        public Guid GetGuid(string name)
        {
            return _reader.GetGuid(_reader.GetOrdinal(name));
        }

        #region IDataReader Members

        /// <summary>
        /// Closes the <see cref="T:System.Data.IDataReader"/> Object.
        /// </summary>
        public void Close()
        {
            _reader.Close();
        }

        /// <summary>
        /// Gets a value indicating the depth of nesting for the current row.
        /// </summary>
        /// <value></value>
        /// <returns>The level of nesting.</returns>
        public int Depth
        {
            get
            {
                return _reader.Depth;
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.Data.DataTable"/> that describes the column metadata of the <see cref="T:System.Data.IDataReader"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Data.DataTable"/> that describes the column metadata.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Data.IDataReader"/> is closed. </exception>
        public DataTable GetSchemaTable()
        {
            return _reader.GetSchemaTable();
        }

        /// <summary>
        /// Gets a value indicating whether the data reader is closed.
        /// </summary>
        /// <value></value>
        /// <returns>true if the data reader is closed; otherwise, false.</returns>
        public bool IsClosed
        {
            get
            {
                return _reader.IsClosed;
            }
        }

        /// <summary>
        /// Advances the data reader to the next result, when reading the results of batch SQL statements.
        /// </summary>
        /// <returns>
        /// true if there are more rows; otherwise, false.
        /// </returns>
        public bool NextResult()
        {
            return _reader.NextResult();
        }

        /// <summary>
        /// Advances the <see cref="T:System.Data.IDataReader"/> to the next record.
        /// </summary>
        /// <returns>
        /// true if there are more rows; otherwise, false.
        /// </returns>
        public bool Read()
        {
            return _reader.Read();
        }

        /// <summary>
        /// Gets the number of rows changed, inserted, or deleted by execution of the SQL statement.
        /// </summary>
        /// <value></value>
        /// <returns>The number of rows changed, inserted, or deleted; 0 if no rows were affected or the statement failed; and -1 for SELECT statements.</returns>
        public int RecordsAffected
        {
            get
            {
                return _reader.RecordsAffected;
            }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged 
        /// resources.
        /// </summary>
        public void Dispose()
        {
            if (_reader != null)
            {
                _reader.Dispose();
            }
        }

        #endregion

        #region IDataRecord Members

        /// <summary>
        /// Gets the number of columns in the current row.
        /// </summary>
        /// <value></value>
        /// <returns>When not positioned in a valid recordset, 0; otherwise, the number of columns in the
        /// current record. The default is -1.</returns>
        public int FieldCount
        {
            get
            {
                return _reader.FieldCount;
            }
        }

        /// <summary>
        /// Gets the value of the specified column as a Boolean.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>The value of the column.</returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range 
        /// of 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public bool GetBoolean(int ordinal)
        {
            return _reader.GetBoolean(ordinal);
        }

        /// <summary>
        /// Gets the 8-bit unsigned integer value of the specified column.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>
        /// The 8-bit unsigned integer value of the specified column.
        /// </returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range 
        /// of 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public byte GetByte(int ordinal)
        {
            return _reader.GetByte(ordinal);
        }

        /// <summary>
        /// Reads a stream of bytes from the specified column offset into the buffer as an array, 
        /// starting at the given buffer offset.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <param name="fieldOffset">The index within the field from which to start the read operation.
        /// </param>
        /// <param name="buffer">The buffer into which to read the stream of bytes.</param>
        /// <param name="bufferOffset">The index for <paramref name="buffer"/> to start the read operation.
        /// </param>
        /// <param name="length">The number of bytes to read.</param>
        /// <returns>The actual number of bytes read.</returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of 
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public long GetBytes(int ordinal, long fieldOffset, byte[] buffer, int bufferOffset, int length)
        {
            return _reader.GetBytes(ordinal, fieldOffset, buffer, bufferOffset, length);
        }

        /// <summary>
        /// Gets the character value of the specified column.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <returns>
        /// The character value of the specified column.
        /// </returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of 
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public char GetChar(int ordinal)
        {
            return _reader.GetChar(ordinal);
        }

        /// <summary>
        /// Reads a stream of characters from the specified column offset into the buffer as an array
        /// , starting at the given buffer offset.
        /// </summary>
        /// <param name="ordinal">The zero-based column ordinal.</param>
        /// <param name="fieldOffset">The index within the row from which to start the read operation.
        /// </param>
        /// <param name="buffer">The buffer into which to read the stream of bytes.</param>
        /// <param name="bufferOffset">The index for <paramref name="buffer"/> to start the read operation.
        /// </param>
        /// <param name="length">The number of bytes to read.</param>
        /// <returns>The actual number of characters read.</returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of 
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public long GetChars(int ordinal, long fieldOffset, char[] buffer, int bufferOffset, int length)
        {
            return _reader.GetChars(ordinal, fieldOffset, buffer, bufferOffset, length);
        }

        /// <summary>
        /// Returns an <see cref="T:System.Data.IDataReader"/> for the specified column ordinal.
        /// </summary>
        /// <param name="ordinal">The ordinal of the field to find.</param>
        /// <returns>
        /// An <see cref="T:System.Data.IDataReader"/>.
        /// </returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public IDataReader GetData(int ordinal)
        {
            return _reader.GetData(ordinal);
        }

        /// <summary>
        /// Gets the data type information for the specified field.
        /// </summary>
        /// <param name="ordinal">The ordinal of the field to find.</param>
        /// <returns>
        /// The data type information for the specified field.
        /// </returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of 
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public string GetDataTypeName(int ordinal)
        {
            return _reader.GetDataTypeName(ordinal);
        }

        /// <summary>
        /// Gets the date and time data value of the specified field.
        /// </summary>
        /// <param name="ordinal">The ordinal of the field to find.</param>
        /// <returns>
        /// The date and time data value of the specified field.
        /// </returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of 
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public DateTime GetDateTime(int ordinal)
        {
            return _reader.GetDateTime(ordinal);
        }

        /// <summary>
        /// Gets the fixed-position numeric value of the specified field.
        /// </summary>
        /// <param name="ordinal">The ordinal of the field to find.</param>
        /// <returns>
        /// The fixed-position numeric value of the specified field.
        /// </returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public decimal GetDecimal(int ordinal)
        {
            return _reader.GetDecimal(ordinal);
        }

        /// <summary>
        /// Gets the double-precision floating point number of the specified field.
        /// </summary>
        /// <param name="ordinal">The ordinal of the field to find.</param>
        /// <returns>
        /// The double-precision floating point number of the specified field.
        /// </returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public double GetDouble(int ordinal)
        {
            return _reader.GetDouble(ordinal);
        }

		public double GetDouble(string name)
		{
			return _reader.GetDouble(_reader.GetOrdinal(name));
		}

        /// <summary>
        /// Gets the <see cref="T:System.Type"/> information corresponding to the
        /// type of <see cref="T:System.Object"/> that would be returned 
        /// from <see cref="M:System.Data.IDataRecord.GetValue(System.Int32)"/>.
        /// </summary>
        /// <param name="ordinal">The ordinal of the field to find.</param>
        /// <returns>
        /// The <see cref="T:System.Type"/> information corresponding to the type 
        /// of <see cref="T:System.Object"/> that would be returned 
        /// from <see cref="M:System.Data.IDataRecord.GetValue(System.Int32)"/>.
        /// </returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public Type GetFieldType(int ordinal)
        {
            return _reader.GetFieldType(ordinal);
        }

        /// <summary>
        /// Gets the single-precision floating point number of the specified field.
        /// </summary>
        /// <param name="ordinal">The ordinal of the field to find.</param>
        /// <returns>
        /// The single-precision floating point number of the specified field.
        /// </returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public float GetFloat(int ordinal)
        {
            return _reader.GetFloat(ordinal);
        }

        /// <summary>
        /// Returns the GUID value of the specified field.
        /// </summary>
        /// <param name="ordinal">The ordinal of the field to find.</param>
        /// <returns>The GUID value of the specified field.</returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public Guid GetGuid(int ordinal)
        {
            return _reader.GetGuid(ordinal);
        }

        /// <summary>
        /// Gets the 16-bit signed integer value of the specified field.
        /// </summary>
        /// <param name="ordinal">The ordinal of the field to find.</param>
        /// <returns>
        /// The 16-bit signed integer value of the specified field.
        /// </returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>.</exception>
        public short GetInt16(int ordinal)
        {
            return _reader.GetInt16(ordinal);
        }

        /// <summary>
        /// Gets the 32-bit signed integer value of the specified field.
        /// </summary>
        /// <param name="ordinal">The ordinal of the field to find.</param>
        /// <returns>
        /// The 32-bit signed integer value of the specified field.
        /// </returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of 
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public int GetInt32(int ordinal)
        {
            return _reader.GetInt32(ordinal);
        }

        /// <summary>
        /// Gets the 64-bit signed integer value of the specified field.
        /// </summary>
        /// <param name="ordinal">The ordinal of the field to find.</param>
        /// <returns>
        /// The 64-bit signed integer value of the specified field.
        /// </returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of 
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public long GetInt64(int ordinal)
        {
            return _reader.GetInt64(ordinal);
        }

        /// <summary>
        /// Gets the name for the field to find.
        /// </summary>
        /// <param name="ordinal">The ordinal of the field to find.</param>
        /// <returns>
        /// The name of the field or the empty string (""), if there is no value to return.
        /// </returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public string GetName(int ordinal)
        {
            return _reader.GetName(ordinal);
        }

        /// <summary>
        /// Return the ordinal of the named field.
        /// </summary>
        /// <param name="name">The name of the field to find.</param>
        /// <returns>The ordinal of the named field.</returns>
        public int GetOrdinal(string name)
        {
            return _reader.GetOrdinal(name);
        }

        /// <summary>
        /// Gets the string value of the specified field.
        /// </summary>
        /// <param name="ordinal">The ordinal of the field to find.</param>
        /// <returns>The string value of the specified field.</returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public string GetString(int ordinal)
        {
            return _reader.GetString(ordinal);
        }

        /// <summary>
        /// Return the value of the specified field.
        /// </summary>
        /// <param name="ordinal">The ordinal of the field to find.</param>
        /// <returns>
        /// The <see cref="T:System.Object"/> which will contain the field value upon return.
        /// </returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public object GetValue(int ordinal)
        {
            return _reader.GetValue(ordinal);
        }

        /// <summary>
        /// Gets all the attribute fields in the collection for the current record.
        /// </summary>
        /// <param name="values">An array of <see cref="T:System.Object"/> to copy the attribute fields into.
        /// </param>
        /// <returns>
        /// The number of instances of <see cref="T:System.Object"/> in the array.
        /// </returns>
        public int GetValues(object[] values)
        {
            return _reader.GetValues(values);
        }

        /// <summary>
        /// Return whether the specified field is set to null.
        /// </summary>
        /// <param name="ordinal">The ordinal of the field to find.</param>
        /// <returns>
        /// true if the specified field is set to null; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.IndexOutOfRangeException">The ordinal passed was outside the range of
        /// 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception>
        public bool IsDBNull(int ordinal)
        {
            return _reader.IsDBNull(ordinal);
        }

        /// <summary>
        /// Gets the <see cref="System.Object"/> with the specified name.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <value>The object with the given name.</value>
        /// <returns>Returns the name.</returns>
        public object this[string name]
        {
            get
            {
                return _reader[name];
            }
        }

        /// <summary>
        /// Gets the <see cref="System.Object"/> with the specified position.
        /// </summary>
        /// <param name="i">The column position.</param>
        /// <value>The value at the specified position</value>
        /// <returns>Returns the object in specified position.</returns>
        public object this[int i]
        {
            get
            {
                return _reader[i];
            }
        }

        #endregion

        /// <summary>
        /// Gets a nullable value from the underlying data reader.
        /// </summary>
        /// <typeparam name="T">The type of the value to return.</typeparam>
        /// <param name="ordinal">The ordinal of the column.</param>
        /// <param name="method">The delegate representing the method to call in the underlying data reader.
        /// </param>
        /// <returns>The value at the specified position,</returns>
        private Nullable<T> GetNullable<T>(int ordinal, GetMethod<T> method) where T : struct
        {
            Nullable<T> value;
            if (IsDBNull(ordinal))
            {
                value = null;
            }
            else
            {
                value = method(ordinal);
            }

            return value;
        }
    }
}
