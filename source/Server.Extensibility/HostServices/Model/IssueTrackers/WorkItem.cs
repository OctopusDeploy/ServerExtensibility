using System.Collections.Generic;

namespace Octopus.Server.Extensibility.HostServices.Model.IssueTrackers
{
    public class WorkItem
    {
        public string Id { get; set; }
        public string IssueTrackerId { get; set; }
        public string LinkUrl { get; set; }
        public string LinkText { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as WorkItem;
            return item != null &&
                   Id == item.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<string>.Default.GetHashCode(Id);
        }
    }
}