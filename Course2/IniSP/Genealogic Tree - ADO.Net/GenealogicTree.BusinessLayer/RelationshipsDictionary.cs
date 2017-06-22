using System.Collections.Generic;

namespace GenealogicTree.BusinessLayer
{
    /// <summary>
    /// Словарь родственных отношений
    /// </summary>
    public static class RelationshipsDictionary
    {
        public static KindOfRelative GetKindOfRelative(List<KindOfRelative> kindOfRelatives)
        {
            while (kindOfRelatives.Count > 1)
            {
                kindOfRelatives[0] = Get(kindOfRelatives[0], kindOfRelatives[1]);
                kindOfRelatives.RemoveAt(1);
            }
            return (kindOfRelatives.Count > 0) ? kindOfRelatives[0] : KindOfRelative.NotRelative;
        }

        private static KindOfRelative Get(KindOfRelative kindOfRelative1, KindOfRelative kindOfRelative2)
        {
            if ((kindOfRelative1 == KindOfRelative.Father) && 
                ((kindOfRelative2 == KindOfRelative.Father) || (kindOfRelative2 == KindOfRelative.Mother)))
            {
                return KindOfRelative.Grandfather;
            }
            if ((kindOfRelative1 == KindOfRelative.Mother) &&
                ((kindOfRelative2 == KindOfRelative.Father) || (kindOfRelative2 == KindOfRelative.Mother)))
            {
                return KindOfRelative.Grandmother;
            }
            if ((kindOfRelative1 == KindOfRelative.Husband) && (kindOfRelative2 == KindOfRelative.Sister))
            {
                return KindOfRelative.BrotherInLow;
            }
            return KindOfRelative.NotRelative;
        }
    }
}
