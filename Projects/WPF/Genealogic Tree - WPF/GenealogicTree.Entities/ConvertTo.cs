namespace GenealogicTree.Entities
{
    public static class ConvertTo
    {
        public static KindOfRelative KindOfRelative(string str)
        {
            switch (str)
            {
                case "Я":
                    return Entities.KindOfRelative.Me;
                case "Папа":
                case "папу":
                    return Entities.KindOfRelative.Father;
                case "Мама":
                case "маму":
                    return Entities.KindOfRelative.Mother;
                case "Брат":
                case "брата":
                    return Entities.KindOfRelative.Brother;
                case "Сестра":
                case "сестру":
                    return Entities.KindOfRelative.Sister;
                case "Муж":
                case "мужа":
                    return Entities.KindOfRelative.Husband;
                case "Жена":
                case "жену":
                    return Entities.KindOfRelative.Wife;
                case "Дедушка":
                    return Entities.KindOfRelative.Grandfather;
                case "Бабушка":
                    return Entities.KindOfRelative.Grandmother;
                case "Прадедушка":
                    return Entities.KindOfRelative.GreatGrandfather;
                case "Прабабушка":
                    return Entities.KindOfRelative.GreatGrandmother;
                case "Тетя":
                    return Entities.KindOfRelative.Aunt;
                case "Дядя":
                    return Entities.KindOfRelative.Uncle;
                default:
                    return Entities.KindOfRelative.NotRelative;
            }
        }

        public static string String(KindOfRelative kindOfRelative)
        {
            switch (kindOfRelative)
            {
                case Entities.KindOfRelative.Me:
                    return "Я";
                case Entities.KindOfRelative.Father:
                    return "Папа";
                case Entities.KindOfRelative.Mother:
                    return "Мама";
                case Entities.KindOfRelative.Brother:
                    return "Брат";
                case Entities.KindOfRelative.Sister:
                    return "Сестра";
                case Entities.KindOfRelative.Grandfather:
                    return "Дедушка";
                case Entities.KindOfRelative.Grandmother:
                    return "Бабушка";
                case Entities.KindOfRelative.GreatGrandmother:
                    return "Прабабушка";
                case Entities.KindOfRelative.GreatGrandfather:
                    return "Прадедушка";
                case Entities.KindOfRelative.GreatGreatGrandmother:
                    return "Прапрабабушка";
                case Entities.KindOfRelative.GreatGreatGrandfather:
                    return "Прапрадедушка";
                case Entities.KindOfRelative.Aunt:
                    return "Тетя";
                case Entities.KindOfRelative.Uncle:
                    return "Дядя";
                case Entities.KindOfRelative.Husband:
                    return "Муж";
                case Entities.KindOfRelative.Wife:
                    return "Жена";
                case Entities.KindOfRelative.BrotherInLow:
                    return "Зять(муж сестры)";
                default:
                    return "";
            }
        }
    }
}
