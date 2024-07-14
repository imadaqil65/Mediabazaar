using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Converters
{
    public class EmployeeConverter
    {
        public Employee ConvertToEmployee(UpdateUserDTO updateUserDTO, Contract employeeContract)
        {
            Employee employee = new Employee(updateUserDTO.firstName, updateUserDTO.lastName, updateUserDTO.Adress);
            foreach (var property in typeof(UpdateUserDTO).GetProperties())
            {
                var value = property.GetValue(updateUserDTO, null);
                var targetProperty = typeof(Employee).GetProperty(property.Name);

                if (targetProperty != null)
                {
                    if (targetProperty.PropertyType == typeof(string) && value is string)
                    {
                        targetProperty.SetValue(employee, value);
                    }
                    if (targetProperty.PropertyType == typeof(int) && value is string stringValue)
                    {
                        if (int.TryParse(stringValue, out int intValue))
                        {
                            targetProperty.SetValue(employee, intValue);
                        }
                    }
/*                    if (targetProperty.PropertyType == typeof(DateTime) && value is DateTime)
                    {
                        targetProperty.SetValue(employee, value);
                    }*/
                }
            }

            employee.SetNewContract(employeeContract);

            return employee;
        }
    }
}
