using System;

namespace GenealogicTree.BusinessLayer
{
    /// <summary>
    /// Пользовательское исключение. Появляется когда был ввод некорректных данных
    /// Например: Имя человека, в котором есть цифры
    /// </summary>
    public class IncorrectDataEntry : Exception
    {
        public IncorrectDataEntry(){}

        public IncorrectDataEntry(string message)
            : base(message){}
    }
}
