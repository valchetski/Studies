using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Shedule.DAL
{
    public static class HTML
    {
        /// <summary>
        /// Открывает и парсит расписание группы на сайте БГУИР
        /// </summary>
        public static List<List<string>> GetShedule(string adress)
        {
            string htmlDocument = OpenShedule(adress);

            //тегов table может быть несколько. Выбираем нужный нам
            htmlDocument = GetContentOfTag("table", htmlDocument).FirstOrDefault(h => h.Contains("Недели"));

            List<string> contentOfRows = GetContentOfTag("tr", htmlDocument);
            string currentDay = "";
            var newShedule = new List<List<string>>();
            foreach (var content in contentOfRows)
            {
                List<string> info = GetInfoFromRow(content);

                if ((info.Count == 1) && (currentDay == "" || currentDay != info[0]))
                {
                    currentDay = info[0];
                }
                else if (info.Count > 1)
                {
                    info.Add(currentDay);
                    newShedule.Add(info);
                }
            }

            return newShedule;
        }

        private static string OpenShedule(string fileName)
        {
            string htmlDocument = "";
            using (var client = new WebClient())
            {
                Stream openRead = client.OpenRead(fileName);
                if (openRead != null)
                {
                    var reader = new StreamReader(openRead);
                    htmlDocument = reader.ReadToEnd();
                }
            }

            if (htmlDocument.Contains("не найдено"))
            {
                throw new FileNotFoundException();
            }
            return htmlDocument;
        }

        private static List<string> GetInfoFromRow(string row)
        {
            List<string> contentsOfRow = GetContentOfTag("td", row);
            if (contentsOfRow.Count == 7)
            {
                //в последней ячейке находится примечание. оно нам ни к чему.
                //вместо него подставим тип занятия
                //а во второй ячейке находится название предмета и его тип
                //нам надо эту инфу разбить на две ячейки

                int lastIndex = contentsOfRow[2].LastIndexOf('(');
                if (contentsOfRow[2].Contains("ФизК"))
                {
                    //физра это нихрена не пз. у этого занятия вообще типа быть не должно
                    //это я делаю для того, чтобы в табличке физкультура выделялась синим
                    //синий цвет означает что на этот предмет вообще можно не ходить
                    contentsOfRow[6] = "";
                }
                else if (contentsOfRow[2].Contains("СпецПодг"))
                {
                    //спецподготовка это военка. и у нее тип тоже нихрена не пз
                    //ты то сидишь на 4 лекциях, то окопы копаешь
                    //это отдельный тип занятий. цвет у него в табличке черный. ходить обязательно
                    contentsOfRow[6] = "вк";
                }
                else
                {
                    contentsOfRow[6] = contentsOfRow[2].Substring(lastIndex + 1, contentsOfRow[2].Length - lastIndex - 2).ToLower();   
                }

                contentsOfRow[2] = contentsOfRow[2].Substring(0, lastIndex).Trim();
                
                //в пятой ячейке находится ссылка на расписание преподавателя
                //нам нужно только его имя. Его мы и получаем
                contentsOfRow[5] = GetContentOfTag("a", contentsOfRow[5]).FirstOrDefault();
            }
            return contentsOfRow;
        }

        /// <summary>
        /// Возвращает содержимое тега
        /// </summary>
        /// <param name="tagName">название тега</param>
        /// <param name="code">кусок кода html страницы, где находится этот тег</param>
        /// <returns></returns>
        private static List<string> GetContentOfTag(string tagName, string code)
        {
            var allContent = new List<string>();
            if (code != null)
            {
                //сюда передается только имя тега. чтобы указать, что это именно тег,
                //добавляю угловую скобку. Т.е. если я сюда передаю table, то поиск может сработать неправильно
                //слово table может встречаться в любом месте. Если добавлю "<"-- то это будет указанием на то
                //что мы ищем тег
                if (!tagName.Contains("<"))
                {
                    tagName = tagName.Insert(0, "<");
                }

                int firstIndex = -1;
                int lastIndex = -1;
                do
                {
                    firstIndex = code.IndexOf(tagName, firstIndex + 1);

                    string endTag = tagName.Insert(1, "/");
                    lastIndex = code.IndexOf(endTag, lastIndex + 1);

                    if (firstIndex != -1 && lastIndex != -1)
                    {
                        string tagContent = code.Substring(firstIndex, lastIndex - firstIndex);
                        tagContent = tagContent.Remove(0, tagContent.IndexOf('>') + 1);
                        tagContent = tagContent.Trim('\n', ' ');

                        allContent.Add(tagContent);
                    }
                } while (firstIndex != -1 && lastIndex != -1);
            }

            return allContent;
        }
    }
}