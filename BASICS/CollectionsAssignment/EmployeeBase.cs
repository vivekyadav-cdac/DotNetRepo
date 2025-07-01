namespace CollectionsAssignment
{
    public class EmployeeBase
    {
        public int DeptNum
        {
            set
            {
                if (value > 0)
                {
                    deptNum = value;
                }
                else
                {
                    throw new EmployeeException("department number cannot be less than 1");
                }
            }
            get { return deptNum; }
        }

        public string EmpName
        {
            set
            {
                if (value != null)
                {
                    empName = value;
                }
                else
                {
                    throw new EmployeeException("name cannot be null");
                }
            }
            get { return empName; }
        }

        public int EmpNum
        {
            get { return empNum; }
        }

        public decimal Salary
        {
            set
            {
                if (value > 100000)
                {
                    salary = value;
                }
                else
                {
                    throw new EmployeeException("salary should be greater than 100000");
                }
            }
            get { return salary; }
        }

        public override string ToString()
    }
}