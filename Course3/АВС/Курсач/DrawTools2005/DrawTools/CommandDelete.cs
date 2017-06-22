using System.Collections.Generic;
using System.Linq;

namespace DrawTools
{
    /// <summary>
    /// Delete command
    /// </summary>
    class CommandDelete : Command
    {
        readonly List<DrawObject> cloneList;    // contains selected items which are deleted

        // Create this command BEFORE applying Delete All function.
        public CommandDelete(GraphicsList graphicsList)
        {
            cloneList = new List<DrawObject>();

            // Make clone of the list selection.

            foreach(DrawObject o in graphicsList.Selection)
            {
                cloneList.Add(o.Clone());
            }
        }

        public override void Undo(GraphicsList list)
        {
            list.UnselectAll();

            // Add all objects from cloneList to list.
            foreach(DrawObject o in cloneList)
            {
                list.Add(o);
            }
        }

        public override void Redo(GraphicsList list)
        {
            // Delete from list all objects kept in cloneList
            
            int n = list.Count;

            for ( int i = n - 1; i >= 0; i-- )
            {
                DrawObject objectToDelete = list[i];

                bool toDelete = cloneList.Any(o => objectToDelete.Id == o.Id);

                if ( toDelete )
                {
                    list.RemoveAt(i);
                }
            }
        }
    }
}
