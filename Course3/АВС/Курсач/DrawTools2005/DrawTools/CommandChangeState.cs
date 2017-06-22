using System.Collections.Generic;
using System.Linq;

namespace DrawTools
{
    /// <summary>
    /// Changing state of existing objects:
    /// move, resize, change properties.
    /// </summary>
    class CommandChangeState : Command
    {
        // Selected object(s) before operation
        readonly List<DrawObject> listBefore;

        // Selected object(s) after operation
        List<DrawObject> listAfter;
        

        // Create this command BEFORE operation.
        public CommandChangeState(GraphicsList graphicsList)
        {
            // Keep objects state before operation.
            FillList(graphicsList, ref listBefore);
        }

        // Call this function AFTER operation.
        public void NewState(GraphicsList graphicsList)
        {
            // Keep objects state after operation.
            FillList(graphicsList, ref listAfter);
        }

        public override void Undo(GraphicsList list)
        {
            // Replace all objects in the list with objects from listBefore
            ReplaceObjects(list, listBefore);
        }

        public override void Redo(GraphicsList list)
        {
            // Replace all objects in the list with objects from listAfter
            ReplaceObjects(list, listAfter);
        }

        // Replace objects in graphicsList with objects from list
        private void ReplaceObjects(GraphicsList graphicsList, List<DrawObject> list)
        {
            for ( int i = 0; i < graphicsList.Count; i++ )
            {
                DrawObject replacement = list.FirstOrDefault(o => o.Id == graphicsList[i].Id);

                if ( replacement != null )
                {
                    graphicsList.Replace(i, replacement);
                }
            }
        }

        // Fill list from selection
        private void FillList(GraphicsList graphicsList, ref List<DrawObject> listToFill)
        {
            if (listToFill != null)
            {
                listToFill = graphicsList.Selection.Select(o => o.Clone()).ToList();
            }
        }
    }
}
