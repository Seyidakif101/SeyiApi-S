using Seyid.Core.Entities.Common;

namespace Seyid.Core.Entities
{
    public class Department:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public List<Employee> Employees { get; set; } = [];
    }
}
