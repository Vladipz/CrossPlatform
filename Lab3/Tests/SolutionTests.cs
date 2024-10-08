using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using App;

namespace Tests
{
    public class DepartmentServiceTests
    {
        private readonly ITestOutputHelper _output;

        public DepartmentServiceTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void SolveSimpleTreeReturnsCorrectLCA()
        {
            // Arrange
            int n = 5;
            List<int> numbersOfDepartments = new List<int> { 4, 5 };
            List<int> connections = new List<int> { 1, 1, 2, 2 };

            // Act
            int result = DepartmetnsService.Solve(n, numbersOfDepartments, connections);

            // Output
            _output.WriteLine($"Input: n={n}, departments={string.Join(", ", numbersOfDepartments)}, connections={string.Join(", ", connections)}");
            _output.WriteLine($"Result: {result}");
            _output.WriteLine("passed");

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void SolveLinearTreeReturnsCorrectLCA()
        {
            // Arrange
            int n = 5;
            List<int> numbersOfDepartments = new List<int> { 1, 5 };
            List<int> connections = new List<int> { 1, 2, 3, 4 };

            // Act
            int result = DepartmetnsService.Solve(n, numbersOfDepartments, connections);

            // Output
            _output.WriteLine($"Input: n={n}, departments={string.Join(", ", numbersOfDepartments)}, connections={string.Join(", ", connections)}");
            _output.WriteLine($"Result: {result}");
            _output.WriteLine("passed");

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void SolveSameDepartmentReturnsItself()
        {
            // Arrange
            int n = 3;
            List<int> numbersOfDepartments = new List<int> { 2, 2 };
            List<int> connections = new List<int> { 1, 1 };

            // Act
            int result = DepartmetnsService.Solve(n, numbersOfDepartments, connections);

            // Output
            _output.WriteLine($"Input: n={n}, departments={string.Join(", ", numbersOfDepartments)}, connections={string.Join(", ", connections)}");
            _output.WriteLine($"Result: {result}");
            _output.WriteLine("passed");

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void SolveNullNumbersOfDepartmentsThrowsArgumentNullException()
        {
            // Arrange
            int n = 3;
            List<int> connections = new List<int> { 1, 1 };

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => DepartmetnsService.Solve(n, null, connections));

            // Output
            _output.WriteLine($"Input: n={n}, departments=null, connections={string.Join(", ", connections)}");
            _output.WriteLine($"Exception message: {exception.Message}");
            _output.WriteLine("passed");
        }

        [Fact]
        public void SolveNullConnectionsThrowsArgumentNullException()
        {
            // Arrange
            int n = 3;
            List<int> numbersOfDepartments = new List<int> { 2, 3 };

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => DepartmetnsService.Solve(n, numbersOfDepartments, null));

            // Output
            _output.WriteLine($"Input: n={n}, departments={string.Join(", ", numbersOfDepartments)}, connections=null");
            _output.WriteLine($"Exception message: {exception.Message}");
            _output.WriteLine("passed");
        }
    }
}