using Moq;
using StaffApi.Models;

namespace StaffTesting;

public class UnitTest1
{
    Mock<IStaffRepository> mock;
    StaffsContext staffsContext;

    IStaffRepository employeeRepository;
    public static List<Employee> list { get; set; }

    public UnitTest1()
    {
        mock = new Mock<IStaffRepository>();
        staffsContext = new StaffsContext();
        employeeRepository = new StaffRepository(staffsContext);

        list = new List<Employee>();
        list.Add(new Employee()
        {
            EmployeeId = 1,
            FirstName = "Cao",
            LastName = "Dat",
            DateofBirth = new DateTime(2004, 05, 25),
            Email = "dat@gmail.com",
            DepartmentId = 1,
            GenderId = 1
        });
        list.Add(new Employee()
        {
            EmployeeId = 2,
            FirstName = "Le",
            LastName = "Bao",
            DateofBirth = new DateTime(2004, 05, 31),
            Email = "bao@gmail.com",
            DepartmentId = 2,
            GenderId = 1
        });
    }

    [Fact]
    public async void GetStaff()
    {
        var staff = from e in list
                    where e.EmployeeId == 1
                    select e;

        var expect = (staff == null) ? null : staff.FirstOrDefault();

        mock.Setup(x => x.GetEmployee(1)).ReturnsAsync(expect);
        var rs = await employeeRepository.GetEmployee(1);

        Assert.Equal(expect.EmployeeId, rs.EmployeeId);
    }

    [Fact]
    public async void AddStaff()
    {

        Employee staff = new Employee()
        {
            EmployeeId = 3,
            FirstName = "Phan",
            LastName = "Bao",
            DateofBirth = new DateTime(2004, 08, 22),
            Email = "bao@gmail.com",
            DepartmentId = 2,
            GenderId = 1
        };

        mock.Setup(x => x.AddEmployee(staff)).ReturnsAsync(staff);

        // var result = await employeeRepository.AddEmployee(staff);
        var result = await mock.Object.AddEmployee(staff);

        Assert.NotNull(result);
        Assert.Equal(staff.EmployeeId, result.EmployeeId);
        Assert.Equal(staff.FirstName, result.FirstName);
        Assert.Equal(staff.LastName, result.LastName);
    }

    [Fact]
    public async Task GetAllStaffs()
    {

        mock.Setup(x => x.GetAllEmployees()).ReturnsAsync(list);

        List<Employee> result = (List<Employee>)await employeeRepository.GetAllEmployees();

        Assert.Equal(list.Count, result.Count());
        for (int i = 0; i < list.Count; i++)
        {
            Assert.Equal(list[i].EmployeeId, result[i].EmployeeId);
            Assert.Equal(list[i].FirstName, result[i].FirstName);
        }

    }

    [Fact]
    public async void UpdateStaff()
    {
        Employee employee = new Employee();
        employee.EmployeeId = 2;
        employee.FirstName = "Le";
        employee.LastName = "Gia Bao";
        employee.DateofBirth = new DateTime(2004, 05, 31);
        employee.DepartmentId = 2;
        employee.GenderId = 1;
        employee.Email = "giabao@tester.com";

        mock.Setup(x => x.UpdateEmployee(employee)).ReturnsAsync(employee);
        var result = await employeeRepository.UpdateEmployee(employee);

        Assert.Equal(employee.EmployeeId, result.EmployeeId);
        Assert.Equal(employee.FirstName, result.FirstName);
        Assert.Equal(employee.LastName, result.LastName);

    }


    [Fact]
    public async void DeleteStaff()
    {

        var listBeforeDeletion = new List<Employee>
   {
       new Employee
       {
           EmployeeId = 1,
           FirstName = "Cao",
           LastName = "Dat",
           DateofBirth = new DateTime(2004, 05, 25),
           Email = "dat@gmail.com",
           DepartmentId = 1,
           GenderId = 1
       },
       new Employee
       {
           EmployeeId = 2,
           FirstName = "Le",
           LastName = "Bao",
           DateofBirth = new DateTime(2004, 05, 31),
           Email = "bao@gmail.com",
           DepartmentId = 2,
           GenderId = 1
       },
       new Employee
       {
           EmployeeId = 3,
           FirstName = "Phan",
           LastName = "Bao",
           DateofBirth = new DateTime(2004, 08, 22),
           Email = "bao@gmail.com",
           DepartmentId = 2,
           GenderId = 1
       }
   };

        var listAfterDeletion = listBeforeDeletion
        .Where(e => e.EmployeeId != 3)
        .ToList();

        const int employeeIdToDelete = 3;

        var setupSequence = mock.Setup(x => x.GetAllEmployees());
        setupSequence.ReturnsAsync(listBeforeDeletion);
        setupSequence.ReturnsAsync(listAfterDeletion);

        // var employeeToDelete = listBeforeDeletion.First(e => e.EmployeeId == employeeIdToDelete);
        // mock.Setup(x => x.DeleteEmployee(employeeIdToDelete))
        //     .ReturnsAsync(employeeToDelete);

        await employeeRepository.DeleteEmployee(employeeIdToDelete);
        var result = await employeeRepository.GetAllEmployees();

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Equal(listAfterDeletion.Count, result.Count());
        Assert.DoesNotContain(result, e => e.EmployeeId == employeeIdToDelete);

    }


    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public async void GetStaffById(int id)
    {

        var expect = list.FirstOrDefault(e => e.EmployeeId == id);

        mock.Setup(x => x.GetEmployee(id)).ReturnsAsync(expect);


        var result = await mock.Object.GetEmployee(id);

        if (expect == null)
        {
            Assert.Null(result);
        }
        else
        {
            Assert.NotNull(result);
            Assert.Equal(result.EmployeeId, expect.EmployeeId);
        }

    }
}