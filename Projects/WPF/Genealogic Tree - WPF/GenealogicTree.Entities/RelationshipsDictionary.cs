using System.Collections.Generic;
using System.Linq;

namespace GenealogicTree.Entities
{
    /// <summary>
    /// Словарь родственных отношений
    /// </summary>
    public static class RelationshipsDictionary
    {
        public static KindOfRelative GetKindOfRelative(List<KindOfRelative> kindOfRelatives)
        {
            if (kindOfRelatives.Count > 1)
            {
                kindOfRelatives = kindOfRelatives.Where(k => k != KindOfRelative.Me).ToList();
            }
            while (kindOfRelatives.Count > 1)
            {
                kindOfRelatives[kindOfRelatives.Count - 2] = Get(kindOfRelatives[kindOfRelatives.Count - 2], kindOfRelatives[kindOfRelatives.Count - 1]);
                kindOfRelatives.RemoveAt(kindOfRelatives.Count - 1);
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
            if ((kindOfRelative1 == KindOfRelative.Father) &&
                ((kindOfRelative2 == KindOfRelative.Grandfather) || (kindOfRelative2 == KindOfRelative.Grandmother)))
            {
                return KindOfRelative.GreatGrandfather;
            }
            if ((kindOfRelative1 == KindOfRelative.Father) &&
                ((kindOfRelative2 == KindOfRelative.GreatGrandfather) || (kindOfRelative2 == KindOfRelative.GreatGrandmother)))
            {
                return KindOfRelative.GreatGreatGrandfather;
            }

            if ((kindOfRelative1 == KindOfRelative.Mother) &&
                ((kindOfRelative2 == KindOfRelative.Father) || (kindOfRelative2 == KindOfRelative.Mother)))
            {
                return KindOfRelative.Grandmother;
            }
            if ((kindOfRelative1 == KindOfRelative.Mother) &&
                ((kindOfRelative2 == KindOfRelative.Grandfather) || (kindOfRelative2 == KindOfRelative.Grandmother)))
            {
                return KindOfRelative.GreatGrandmother;
            }
            if ((kindOfRelative1 == KindOfRelative.Mother) &&
                ((kindOfRelative2 == KindOfRelative.GreatGrandfather) || (kindOfRelative2 == KindOfRelative.GreatGrandmother)))
            {
                return KindOfRelative.GreatGreatGrandmother;
            }

            if ((kindOfRelative1 == KindOfRelative.Sister) && (kindOfRelative2 == KindOfRelative.Sister))
            {
                return KindOfRelative.Sister;
            }
            if ((kindOfRelative1 == KindOfRelative.Brother) && (kindOfRelative2 == KindOfRelative.Brother))
            {
                return KindOfRelative.Brother;
            }
            if ((kindOfRelative1 == KindOfRelative.Brother) && (kindOfRelative2 == KindOfRelative.Sister))
            {
                return KindOfRelative.Brother;
            }
            if ((kindOfRelative1 == KindOfRelative.Sister) && (kindOfRelative2 == KindOfRelative.Brother))
            {
                return KindOfRelative.Sister;
            }

            if ((kindOfRelative1 == KindOfRelative.Sister) &&
                ((kindOfRelative2 == KindOfRelative.Mother) || (kindOfRelative2 == KindOfRelative.Father)))
            {
                return KindOfRelative.Aunt;
            }

            if ((kindOfRelative1 == KindOfRelative.Brother) &&
                ((kindOfRelative2 == KindOfRelative.Mother) || (kindOfRelative2 == KindOfRelative.Father)))
            {
                return KindOfRelative.Uncle;
            }

            if ((kindOfRelative1 == KindOfRelative.Brother) && (kindOfRelative2 == KindOfRelative.Aunt))
            {
                return KindOfRelative.Uncle;
            }

            if ((kindOfRelative1 == KindOfRelative.Husband) && (kindOfRelative2 == KindOfRelative.Sister))
            {
                return KindOfRelative.BrotherInLow;
            }
            return KindOfRelative.NotRelative;
        }
    }
}
