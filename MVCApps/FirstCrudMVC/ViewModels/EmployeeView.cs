using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstCrudMVC.ViewModels
{
    public class EmployeeView
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; } 

        public IEnumerable<SelectListItem> Departments { get; set; }
        
    }
}
