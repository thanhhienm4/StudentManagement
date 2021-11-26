using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Undo
{
    public class SUndo
    {
        private int now = - 1;
        public bool Empty()
        {
            return ActionOlds.Count == 0;
        }
        public void Push(ActionUndo actionOld, ActionUndo actionNew)
        {
            if (now < ActionOlds.Count -1)
            {
                ActionOlds.RemoveRange(now + 1, ActionOlds.Count - now - 1);
                ActionNews.RemoveRange(now + 1, ActionNews.Count - now - 1);

            }    
               

            
            ActionNews.Add(actionNew);
            ActionOlds.Add(actionOld);
            now = ActionOlds.Count - 1;
            Console.WriteLine(ActionOlds.Count);
        }
        public ActionUndo After()
        {
            if (now < ActionOlds.Count - 1)
                now = now + 1;
            else
                return null;
            return ActionNews[now];
        }
        public ActionUndo Before()
        {
            if (now > -1)
                now = now - 1;
            else
                return null;
            return ActionOlds[now +1];
        }
        List<ActionUndo> ActionOlds;
        List<ActionUndo> ActionNews;
        public SUndo ()
        {
            ActionOlds = new List<ActionUndo>();
            ActionNews = new List<ActionUndo>();
        }
    }
}
