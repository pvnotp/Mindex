using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CodeChallenge.Models
{
    public class ReportingStructure
    {
        public Employee Employee { get; set; }
        public int NumberOfReports { get; set; }


        public ReportingStructure(Employee employee) {
            Employee = employee;
            NumberOfReports = GetNumberOfReports(employee);

        }

        private int GetNumberOfReports(Employee employee) {
            var numberOfReports = employee.DirectReports?.Count ?? 0;

            if (numberOfReports == 0)
            {
                return numberOfReports;
            }
            foreach (var report in employee.DirectReports)
            {
                numberOfReports = numberOfReports + GetNumberOfReports(report);
            }
            return numberOfReports;
        }
    }   
}
