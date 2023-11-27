using Dapper;
using Libreria.Entidades.Enums;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace Libreria.Repositorios.Handlers
{
    public class DapperBuilderManager
    {
        private static readonly Random _rand = new Random();
        public string TopCondition { get; set; }
        public Dictionary<string, string> InsertConditions { get; set; }
        public List<string> UnionAllConditions { get; set; }
        public List<string> WhereConditions { get; set; }
        public List<string> SetConditions { get; set; }
        public DynamicParameters Parameters { get; set; }

        public DapperBuilderManager()
        {
            this.UnionAllConditions = new List<string>();
            this.Parameters = new DynamicParameters();
            this.WhereConditions = new List<string>();
            this.SetConditions = new List<string>();
            this.InsertConditions = new Dictionary<string, string>();
        }

        #region Top Filter
        public DapperBuilderManager AddTopFilter(string paramName, string sqlCondition, int? value)
        {
            if (value > 0)
            {
                this.Parameters.Add(paramName, value);
                this.TopCondition = sqlCondition;
            }

            return this;
        }

        public void AddTopToSQL(StringBuilder sql, bool clearAfter = false)
        {
            if (Parameters != null && !string.IsNullOrWhiteSpace(TopCondition))
            {
                string auxSql = sql.ToString();
                var regex = new Regex(@"(?<!\p{L})SELECT(?!\p{L})", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));
                sql.Clear();
                sql.Append(regex.Replace(auxSql, $"{SqlType.Select} {TopCondition}", 1));

                if (clearAfter)
                {
                    TopCondition = string.Empty;
                }
            }
        }
        #endregion

        #region Where Filter
        public DapperBuilderManager AddWhereFilter(string parameter, string sqlCondition, string value)
        {
            if (IsValidValue(value))
            {
                AddWhereToProperties(parameter, sqlCondition, value);
            }

            return this;
        }
        public DapperBuilderManager AddWhereFilter(string paramName, string sqlCondition, int? value, bool allowZeroValue = false)
        {
            if (IsValidValue(value, allowZeroValue: allowZeroValue))
            {
                AddWhereToProperties(paramName, sqlCondition, value.ToString());
            }

            return this;
        }
        public DapperBuilderManager AddWhereFilter(string paramName, string sqlCondition, bool? value)
        {
            if (IsValidValue(value))
            {
                AddWhereToProperties(paramName, sqlCondition, value.ToString());
            }

            return this;
        }
        public DapperBuilderManager AddWhereFilter(string paramName, string sqlCondition, object value, bool allowZeroValue = false, bool allowNegativeValue = false)
        {
            if (IsValidValue(value, allowZeroValue, allowNegativeValue))
            {
                AddWhereToProperties(paramName, sqlCondition, value);
            }

            return this;
        }

        public DapperBuilderManager AddWhereConditionalFilter(string paramName, string caseTrueCondition, string caseFalseCondition, bool? value)
        {
            if (value.HasValue)
            {
                string electedCondition = value.Value ? caseTrueCondition : caseFalseCondition;
                AddWhereToProperties(paramName, electedCondition);
            }

            return this;
        }
        public DapperBuilderManager AddWhereBoolFilter(string paramName, string caseTrueCondition, bool? value)
        {
            if (value.HasValue && value.Value)
            {
                AddWhereToProperties(paramName, caseTrueCondition);
            }

            return this;
        }

        public void AddWhereToSQL(StringBuilder sql, bool clearAfter = false)
        {
            if (Parameters != null && WhereConditions.Count > 0)
            {
                sql.Append($"{SqlType.Where} ");
                sql.Append(string.Join($" {SqlType.And} ", WhereConditions.ToArray()));
                sql.AppendLine("");

                if (clearAfter)
                {
                    WhereConditions.Clear();
                }
            }
        }
        private void AddWhereToProperties(string parameter, string sqlCondition, object value = null, DbType? dbType = null)
        {
            Parameters.Add(parameter, value, dbType);
            WhereConditions.Add(sqlCondition);
        }
        #endregion

        #region Set Filter
        public DapperBuilderManager AddSetFilter(string paramName, string sqlCondition, string value, bool allowNull = false, DbType? dbType = null)
        {
            if (IsValidValue(value, allowNullValue: allowNull))
            {
                AddSetToProperties(paramName, sqlCondition, value, dbType);
            }

            return this;
        }
        public DapperBuilderManager AddSetFilter(string paramName, string sqlCondition, int? value, bool allowNull = false, bool allowZeroValue = false, bool allowNegativeValue = false, DbType? dbType = null)
        {
            if (IsValidValue(value, allowNullValue: allowNull, allowZeroValue: allowZeroValue, allowNegativeValue: allowNegativeValue))
            {
                AddSetToProperties(paramName, sqlCondition, value, dbType);
            }

            return this;
        }
        public DapperBuilderManager AddSetFilter(string paramName, string sqlCondition, bool? value, DbType? dbType = null)
        {
            if (IsValidValue(value))
            {
                AddSetToProperties(paramName, sqlCondition, value, dbType);
            }

            return this;
        }
        public DapperBuilderManager AddSetFilter(string paramName, string sqlCondition, DateTime? value, bool allowNull = false, DbType? dbType = null)
        {
            string dateString = value != null && value != DateTime.MinValue ? value?.ToString("yyyyMMdd HH:mm:ss") : null;

            if (allowNull || !string.IsNullOrEmpty(dateString))
            {
                AddSetToProperties(paramName, sqlCondition, dateString, dbType);
            }

            return this;
        }

        public DapperBuilderManager AddExplicitSetFilter(string sqlCondition)
        {
            SetConditions.Add(sqlCondition);
            return this;
        }
        public DapperBuilderManager AddExplicitSetConditionalFilter(string sqlCondition, bool condition)
        {
            if (condition)
            {
                SetConditions.Add(sqlCondition);
            }

            return this;
        }

        private void AddSetToProperties(string paramName, string sqlCondition, object value, DbType? dbType = null)
        {
            Parameters.Add(paramName, value, dbType);
            SetConditions.Add(sqlCondition);
        }

        public void AddUpdateSetWhereToSQL(StringBuilder sql, string sqlTable, bool clearAfter = false)
        {
            if (Parameters != null && SetConditions.Count > 0)
            {
                sql.AppendLine($"UPDATE {sqlTable}");
                sql.AppendLine("SET");
                sql.AppendLine(string.Join($",\n", SetConditions.ToArray()));
                AddWhereToSQL(sql, true);

                if (clearAfter)
                {
                    SetConditions.Clear();
                }
            }
        }
        #endregion

        #region Insert Filter
        public DapperBuilderManager AddInsertFilter(string paramName, string column, string value, bool allowEmptyValue = false, DbType? dbType = null)
        {
            if (IsValidValue(value, allowEmptyValue: allowEmptyValue))
            {
                AddInsertToProperties(paramName, column, value, dbType);
            }

            return this;
        }
        public DapperBuilderManager AddInsertFilter(string paramName, string column, int? value, bool allowZeroValue = false, bool allowNegativeValue = false, DbType? dbType = null)
        {
            if (IsValidValue(value, allowZeroValue: allowZeroValue, allowNegativeValue: allowNegativeValue))
            {
                AddInsertToProperties(paramName, column, value, dbType);
            }

            return this;
        }
        public DapperBuilderManager AddInsertFilter(string paramName, string column, bool? value, DbType? dbType = null)
        {
            if (IsValidValue(value))
            {
                AddInsertToProperties(paramName, column, value, dbType);
            }

            return this;
        }
        public DapperBuilderManager AddInsertFilter(string paramName, string column, DateTime? value, DbType? dbType = null)
        {
            string dateString = value != null ? value?.ToString("yyyyMMdd HH:mm:ss") : null;
            this.AddInsertToProperties(paramName, column, dateString, dbType);

            return this;
        }
        public DapperBuilderManager AddInsertConditionalFilter(string paramName, string column, object valueCaseTrue, object valueCaseFalse, bool? condition)
        {
            if (condition.HasValue)
            {
                var resultingValue = condition == true ? valueCaseTrue : valueCaseFalse;
                AddInsertToProperties(paramName, column, resultingValue);
            }

            return this;
        }
        public DapperBuilderManager AddExplicitInsertParameter(string paramName, string column)
        {
            InsertConditions.Add(column, paramName);
            return this;
        }

        private void AddInsertToProperties(string paramName, string sqlColumn, object value, DbType? dbType = null)
        {
            Parameters.Add(paramName, value, dbType);
            InsertConditions.Add(sqlColumn, paramName);
        }
        public void AddInsertToSQL(StringBuilder sql, bool addScopeId = false, string outputColumn = "", bool clearAfter = false, bool identityInsert = false, string identityInsertTable = null)
        {
            if (Parameters != null && InsertConditions.Count > 0)
            {

                var columns = string.Join($", ", InsertConditions.Keys);
                var parameters = string.Join($", ", InsertConditions.Values.Select(x => $"@{x}"));

                sql.AppendLine($"({columns})");
                if (!string.IsNullOrEmpty(outputColumn))
                {
                    sql.AppendLine($"OUTPUT INSERTED.{outputColumn}");
                }
                sql.AppendLine("VALUES");
                sql.AppendLine($"({parameters})");

                if (addScopeId)
                {
                    sql.AppendLine("SELECT CAST(SCOPE_IDENTITY() as int);");
                }

                if (identityInsert && !string.IsNullOrEmpty(identityInsertTable))
                {
                    sql.Insert(0, $"SET IDENTITY_INSERT {identityInsertTable} ON ");
                    sql.AppendLine($"SET IDENTITY_INSERT {identityInsertTable} OFF ");
                }

                if (clearAfter)
                {
                    InsertConditions.Clear();
                }
            }
        }
        #endregion

        #region Delete Filter
        public void AddDeleteFromWhereToSQL(StringBuilder sql, string sqlTable, bool clearAfter = false)
        {
            if (Parameters != null && WhereConditions.Count > 0)
            {
                sql.AppendLine($"DELETE FROM {sqlTable}");
                AddWhereToSQL(sql, true);

                if (clearAfter)
                {
                    WhereConditions.Clear();
                }
            }
        }
        #endregion

        #region Raw conditions
        public void AddCondition(StringBuilder sql, string condition, string paramName, string value)
        {
            if (IsValidValue(value))
            {
                sql.AppendLine(condition);
                Parameters.Add(paramName, value);
            }
        }

        public void AddCondition(StringBuilder sql, string condition, string paramName, int value)
        {
            if (IsValidValue(value))
            {
                sql.AppendLine(condition);
                Parameters.Add(paramName, value);
            }
        }
        #endregion

        #region Custom
        public void AddIffToSql(StringBuilder sql)
        {
            sql.Insert(0, "SELECT IIF (EXISTS (");
            sql.Append("), 1, 0)");
        }
        public void AddIfExistsToSql(StringBuilder sql, string executonSql, bool ifNotExists = false, string elseExecutionSql = null)
        {
            var existsType = !ifNotExists ? "EXISTS" : "NOT EXISTS";
            sql.Insert(0, $"IF {existsType}(");
            sql.Append(')');
            sql.AppendLine("BEGIN");
            sql = sql.AppendLine(executonSql);
            sql.AppendLine("END");

            if (!string.IsNullOrEmpty(elseExecutionSql))
            {
                sql.AppendLine("ELSE");
                sql.AppendLine("BEGIN");
                sql.AppendLine(elseExecutionSql);
                sql.AppendLine("END");
            }
        }

        public DapperBuilderManager AddSelectUnionAllFilter(List<object> values)
        {
            var parameters = new List<string>();

            foreach (var value in values)
            {
                var paramName = $"{value}{_rand.Next(9999999)}";
                Parameters.Add(paramName, value);
                parameters.Add($"@{paramName}");
            }

            UnionAllConditions.Add(string.Join(",", parameters));

            return this;
        }

        public void AddSelectUnionAllToSQL(StringBuilder sql, bool clearAfter = false)
        {
            if (UnionAllConditions.Count > 0)
            {
                foreach (var condition in UnionAllConditions)
                {
                    var unionAllClause = UnionAllConditions.Last() == condition ? string.Empty : "UNION ALL";
                    sql.AppendLine($"SELECT {condition} {unionAllClause}");
                }
            }
        }
        #endregion

        #region Value validations
        private static bool IsValidValue(object value, bool allowNullValue = false, bool allowZeroValue = false, bool allowNegativeValue = false, bool allowEmptyValue = false)
        {
            switch (value)
            {
                case string stringValue:
                    return IsValidValue(stringValue, allowNullValue, allowEmptyValue);
                case int intValue:
                    return IsValidValue(intValue, allowNullValue, allowZeroValue, allowNegativeValue);
                case bool boolValue:
                    return IsValidValue(boolValue, allowNullValue);
                default: return false;
            }
        }

        private static bool IsValidValue(string value, bool allowNullValue = false, bool allowEmptyValue = false)
        {
            var isValid = false;

            if (allowNullValue && value is null)
            {
                isValid = true;
            }
            else if (allowEmptyValue && value == string.Empty)
            {
                isValid = true;
            }
            else if (!string.IsNullOrEmpty(value))
            {
                isValid = true;
            }

            return isValid;
        }

        private static bool IsValidValue(int? value, bool allowNullValue = false, bool allowZeroValue = false, bool allowNegativeValue = false)
        {
            var isValid = false;

            if (value.HasValue)
            {
                if (allowZeroValue && value.Value == 0)
                {
                    isValid = true;
                }
                else if (allowNegativeValue && value.Value != 0)
                {
                    isValid = true;
                }
                else if (!allowZeroValue && !allowNegativeValue && value.Value > 0)
                {
                    isValid = true;
                }
            }
            else if (allowNullValue)
            {
                isValid = true;
            }

            return isValid;
        }

        private static bool IsValidValue(bool? value, bool allowNullValue = false)
        {
            var isValid = false;

            if (value.HasValue)
            {
                isValid = true;
            }
            else if (allowNullValue)
            {
                isValid = true;
            }

            return isValid;
        }
        #endregion
    }
}
