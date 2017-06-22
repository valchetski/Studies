using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GenealogicTree.DAL
{
    public class ADO_DAL
    {
        private readonly SqlConnection sqlConnection;

        public ADO_DAL()
        {
            sqlConnection = new SqlConnection
            {
                ConnectionString =
                    "Persist Security Info=False;Integrated Security=true;Database=Persons;server=VOLANDER-PC\\SQLEXPRESS"
            };
        }

        private bool OpenConnection()
        {
            try
            {
                sqlConnection.Open();
                return true;
            }
            catch (SqlException)
            {
                CloseConnection();
                return false;
            }
            catch (InvalidOperationException)
            {
                CloseConnection();
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                sqlConnection.Close();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public string Add(Dictionary<string, string> dictionary, string tableName)
        {
            string resultOfAdd = "Добавление выполнено успешно";
            if (OpenConnection())
            {
                #region ok

                var toSql = String.Format("INSERT INTO {0} (ID, ) VALUES({1}, )", tableName, GetMaxId(tableName));

                dictionary.Remove(dictionary.FirstOrDefault(e => e.Key == "ID" || e.Key == "Id").Key ?? "");//т.к. ID посчитали выше, то тот ID, что передался, нам не нужен
                var parametrNamesPosition = toSql.IndexOf(',') + 1;
                var valuesNamesPosition = toSql.LastIndexOf(',') + 1;
                string insertString;
                foreach (var elementOfDictionary in dictionary)
                {
                    //вставляется в список параметров
                    insertString = String.Format("{0}, ", elementOfDictionary.Key);
                    toSql = toSql.Insert(parametrNamesPosition + 1, insertString);
                    parametrNamesPosition += insertString.Length;
                    valuesNamesPosition += insertString.Length;

                    //вставляется в список добавляемых значений
                    insertString = String.Format("\'{0}\', ", elementOfDictionary.Value);
                    toSql = toSql.Insert(valuesNamesPosition + 1, insertString);
                    valuesNamesPosition += insertString.Length;
                }
                toSql = toSql.Remove(valuesNamesPosition - 1, 2);
                toSql = toSql.Remove(parametrNamesPosition - 1, 2);
                using (var sqlCommand = new SqlCommand(toSql, sqlConnection))
                {
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        resultOfAdd = "Ошибка при добавлении";
                    }
                }

                #endregion
                if (!CloseConnection())
                {
                    resultOfAdd = "Ошибка при закрытии соединения";
                }

            }
            else
            {
                resultOfAdd = "Не удалось установить соединение с базой";
            }
            return resultOfAdd;
        }

        private int GetMaxId(string tableName)
        {
            int id = 1;
            using (var command = new SqlCommand("SELECT MAX(ID) FROM " + tableName, sqlConnection))
            {
                try { id = (int)command.ExecuteScalar() + 1; }
                catch (InvalidCastException) { }
            }
            return id;
        }

        #region Search
        public List<List<string>> Search(Dictionary<string, string> searchStringsDictionary, string tableName)
        {
            List<List<string>> resultOfSearch;
            if (searchStringsDictionary.Count > 0)
            {
                var searchString = "SELECT * FROM " + tableName + " WHERE ";
                foreach (var elementDictionary in searchStringsDictionary)
                {
                    searchString += String.Format("{0}='{1}' && ", elementDictionary.Key, elementDictionary.Value);
                }
                searchString = searchString.Remove(searchString.Length - 4, 4);
                resultOfSearch = Read(searchString);
            }
            else
            {
                resultOfSearch = new List<List<string>>();
            }
            return resultOfSearch;
        }

        public List<string> SearchById(int id, string tableName)
        {
            var searchString = String.Format("SELECT * FROM " + tableName + " WHERE ID={0}", id);
            return Read(searchString).FirstOrDefault();
        }

        public List<string> SearchMe(string tableName)
        {
            string searchString = "SELECT * FROM " + tableName + " WHERE IsItMe=\'True\'";
            return Read(searchString).FirstOrDefault();
        }
        #endregion

        #region Read
        private List<List<string>> Read(string commandString)
        {
            var list = new List<List<string>>();
            if (OpenConnection())
            {
                SqlDataReader reader = null;
                using (var command = new SqlCommand(commandString, sqlConnection))
                {
                    try
                    {
                        reader = command.ExecuteReader();
                    }
                    catch (SqlException)
                    {
                        list = new List<List<string>>();
                    }
                }
                List<string> element;
                object value;
                try
                {
                    while ((reader != null) && (reader.Read()))
                    {
                        element = new List<string>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            value = reader.GetValue(i);
                            element.Add((value is DateTime) ? String.Format("{0:dd/MM/yyyy}", value) : value.ToString());
                        }
                        list.Add(element);
                    }
                }
                catch (SqlException)
                {
                    list = new List<List<string>>();
                }
                if(reader != null)
                    reader.Close();

                if (!CloseConnection())
                {
                    list = new List<List<string>>();
                }
            }
            return list;
        }

        public List<List<string>> ReadAll(string tableName)
        {
            return Read("SELECT * FROM " + tableName);
        }
        #endregion

        public string Delete(int id, string personTableName, string relativeTableName)
        {
            string resultOfOperation;
            if (OpenConnection())
            {
                try
                {
                    var command =
                        new SqlCommand(String.Format("DELETE FROM {0} WHERE IdPerson={1}", relativeTableName, id),
                            sqlConnection);
                    command.ExecuteNonQuery();
                    command =
                        new SqlCommand(String.Format("DELETE FROM {0} WHERE IdHisRelative={1}", relativeTableName, id),
                            sqlConnection);
                    command.ExecuteNonQuery();
                    command = new SqlCommand(String.Format("DELETE FROM {0} WHERE ID={1}", personTableName, id),
                        sqlConnection);
                    command.ExecuteNonQuery();
                    resultOfOperation = "Удаление выполнено успешно";
                    command.Dispose();
                }
                catch (SqlException)
                {
                    resultOfOperation = "Ошибка при удалении";
                }

                if (!CloseConnection())
                {
                    resultOfOperation += " Ошибка при закрытии соединения с сервером";
                }
            }
            else
            {
                resultOfOperation = "Не удалось установить соединение с сервером";
            }
            return resultOfOperation;
        }

        public string Update(Dictionary<string, string> dictionary, string tableName)
        {
            string resultOfOperation = "";
            if (OpenConnection())
            {
                var toSql = String.Format("UPDATE {0} SET ", tableName);
                var firstElement = dictionary.FirstOrDefault();
                string whereId = String.Format("WHERE {0}={1}", firstElement.Key, firstElement.Value);
                dictionary.Remove(firstElement.Key);
                foreach (var elementOfDictionary in dictionary)
                {
                    int cha;
                    if (int.TryParse(elementOfDictionary.Value, out cha))
                    {
                        toSql += String.Format("{0}={1}, ", elementOfDictionary.Key, elementOfDictionary.Value);
                    }
                    else
                    {
                        toSql += String.Format("\'{0}\'={1}, ", elementOfDictionary.Key, elementOfDictionary.Value);
                    }
                }
                toSql = toSql.Remove(toSql.LastIndexOf(','), 1);
                toSql += whereId;
                using (var sqlCommand = new SqlCommand(toSql, sqlConnection))
                {
                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        resultOfOperation = "Ошибка при обновлении";
                    }
                }

                if (!CloseConnection())
                {
                    resultOfOperation += " Ошибка при закрытии соединения";
                }
            }
            else
            {
                resultOfOperation = "Не удалось установить соединение с базой";
            }

            return resultOfOperation;
        }

        public bool IsRegistrated(string tableName)
        {
            bool isRegistrated = false;
            if (OpenConnection())
            {
                string commandString = String.Format("SELECT COUNT(IsItMe) FROM {0} WHERE IsItMe = \'true\'", tableName);
                using (var command = new SqlCommand(commandString, sqlConnection))
                {
                    int count = 0;
                    try
                    {
                        count = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (SqlException) { }
                    isRegistrated = (count > 0);
                }

                if (!CloseConnection())
                {
                    isRegistrated = false;
                }
            }
            return isRegistrated;
        }

        public Dictionary<List<string>, string> GetImmediateRelatives(int id, string tablePersonName,
            string tableRelativesName)
        {
            var relatives = new Dictionary<List<string>, string>();
            var personRelatives = Read(String.Format("SELECT * FROM {0} WHERE IdPerson={1}", tableRelativesName, id));
            try
            {
                foreach (var relative in personRelatives)
                {
                    var myRelative = SearchById(Convert.ToInt32(relative[2]), tablePersonName);
                    if (myRelative != null)
                    {
                        relatives.Add(myRelative, relative[3]);
                    }
                }
            }
            catch (FormatException) { }
            return relatives;
        }
    }
}
