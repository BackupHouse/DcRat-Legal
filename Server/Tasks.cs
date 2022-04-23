using System.Text;

namespace Server
{
    internal class Tasks
    {

        public static string  GetTasks()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var task in Settings.clientTasks)
            {
                sb.Append(task.Name+"-=>"+ task.status + "-=>" + task.triggerType + "-=>");
            }
            return sb.ToString();
        }
    }
}