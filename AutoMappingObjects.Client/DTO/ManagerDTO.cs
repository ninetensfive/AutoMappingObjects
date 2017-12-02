using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappingObjects.Client.DTO
{
    public class ManagerDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SubordinatesCount
        {
            get
            {
                return this.Subordinates.Count;
            }
        }

        public ICollection<EmployeeDTO> Subordinates { get; set; } = new HashSet<EmployeeDTO>();
    }
}
