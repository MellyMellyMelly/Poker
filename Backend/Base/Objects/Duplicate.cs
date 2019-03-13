using System.Linq;
namespace Base.Objects
{
    internal class PropertyCopier<TParent, TChild> where TParent : class
                                                where TChild : class
    {
        public static void Copy(TParent parent, TChild child)
        {
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();
            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                    {
                        childProperty.SetValue(child, parentProperty.GetValue(parent));
                    }
                }
            }
        }
        public static void UpdateRecord(TParent parent, TChild child)
        {
            string[] properties = new string[]{ "highcard", "highcardWins", "pair", "pairWins", "twopair", "twopairWins", "threekind", "threekindWins", "straight", "straightWins", "flush", "flushWins", "fullhouse", "fullhouseWins", "fourkind", "fourkindWins", "straightflush", "straightflushWins"};
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                if(properties.Contains(parentProperty.Name))
                {
                    var childProperty = childProperties.Where(p => p.Name == parentProperty.Name).FirstOrDefault();
                    int newValue = (int) parentProperty.GetValue(parent) + (int) childProperty.GetValue(child);
                    childProperty.SetValue(child, newValue);
                }
            }
            // var parentProperties = parent.GetType().GetProperties();
            // var childProperties = child.GetType().GetProperties();

            // foreach (var parentProperty in parentProperties)
            // {
            //     foreach (var childProperty in childProperties)
            //     {
            //         if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
            //         {
            //             if(childProperty.PropertyType == typeof(int))
            //             {
            //                 if(childProperty.Name != "wins" && childProperty.Name != "games")
            //                 {
            //                     int newValue = (int) parentProperty.GetValue(parent) + (int) childProperty.GetValue(child);
            //                     childProperty.SetValue(child, newValue);
            //                     break;
            //                 }
            //             }
            //         }
            //     }
            // }
        }
        public static void UpdateHandTotal(TParent parent, TChild child)
        {
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                    {
                        int newValue = (int) parentProperty.GetValue(parent) + (int) childProperty.GetValue(child);
                        childProperty.SetValue(child, newValue);
                        break;
                    }
                }
            }
        }
    }
}